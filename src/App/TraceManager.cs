// BizTalk CAT Instrumentation Framework Controller
// Copyright (C) 2010-Present Thomas F. Abraham. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace BizTalkCatInstrumentationController
{
    /// <summary>
    /// TraceManager encapsulates the external tools used to start and stop ETW traces.
    /// </summary>
    internal class TraceManager
    {
        private static BackgroundWorker _realTimeFormattingWorker;

        static TraceManager()
        {
            BackgroundWorker worker = new BackgroundWorker();
            ConfigureRealTimeFormattingWorker(worker);
            _realTimeFormattingWorker = worker;
        }

        internal static string GetFormattedTraceFileName(string traceName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), traceName + ".txt");
        }

        internal static string GetBinaryTraceFileName(string traceName)
        {
            return traceName + ".bin";
        }

        /// <summary>
        /// Start an ETW trace.
        /// </summary>
        /// <param name="parentWindowHandle">Handle of the parent window in order to associate an error dialog box</param>
        /// <param name="traceName">Name of the trace</param>
        /// <param name="detailLevel">Trace detail level -- Any, None, etc.</param>
        /// <param name="enableRealTime">True to enable real-time tracing, when formatting can occur on the fly</param>
        /// <param name="enableLogFile">True to trace to a log file on disk</param>
        /// <param name="guidsToTrace">List of trace GUIDs to enable</param>
        /// <param name="logOutputToFile">True to log external app output to Debug.txt, False otherwise</param>
        internal static void StartTrace(
            IntPtr parentWindowHandle,
            string traceName, string detailLevel, bool enableRealTime, bool enableLogFile, List<string> guidsToTrace, bool logOutputToFile)
        {
            ProcessStartInfo psi = CreateProcessStartInfo("ETWTools\\tracelog.exe", parentWindowHandle);

            string traceLogFileName = GetBinaryTraceFileName(traceName);

            // Get a StreamWriter for our debugging log file (may be null, but using checks for null)
            using (StreamWriter logFileStream = InitLogFile(logOutputToFile))
            {
                // Start the ETW trace
                psi.Arguments =
                    string.Format(
                        "-cir 1000 -start \"{0}\" -flags {1} {2} -guid #{3} -b 128 -max 100 {4}",
                        traceName,
                        ConvertTraceLevel(detailLevel),
                        enableLogFile ? "-f \"" + traceLogFileName + "\"" : string.Empty,
                        guidsToTrace[0].Replace("-", ","),
                        enableRealTime ? "-rt" : string.Empty);
                RunProcessAndWait(psi, logFileStream);

                // Enable additional trace providers within the trace session (identified by GUIDs)
                for (int index = 1; index < guidsToTrace.Count; index++)
                {
                    psi.Arguments =
                        string.Format(
                            "-enable \"{0}\" -flags {1} -guid #{2}",
                            traceName,
                            ConvertTraceLevel(detailLevel),
                            guidsToTrace[index].Replace("-", ","));
                    RunProcessAndWait(psi, logFileStream);
                }
            }

            // Start real-time debug output formatting, if desired
            if (enableRealTime)
            {
                StartRealTimeFormatting(traceName);
            }
        }

        /// <summary>
        /// Stop an ETW trace.
        /// </summary>
        /// <param name="parentWindowHandle">Handle of the parent window in order to associate an error dialog box</param>
        /// <param name="traceName">Name of the trace</param>
        /// <param name="enableLogFile">True to trace to a log file on disk</param>
        internal static void StopTrace(
            IntPtr parentWindowHandle, string traceName, bool enableRealTime, bool enableLogFile, bool logOutputToFile)
        {
            ProcessStartInfo psi = CreateProcessStartInfo("ETWTools\\tracelog.exe", parentWindowHandle);

            string traceLogFileName = GetBinaryTraceFileName(traceName);

            // Stop real-time debug output formatting
            if (enableRealTime)
            {
                StopRealTimeFormatting();
            }

            // Get a StreamWriter for our debugging log file (may be null, but using checks for null)
            using (StreamWriter logFileStream = InitLogFile(logOutputToFile))
            {
                // Flush the trace logs
                psi.Arguments = string.Format("-flush \"{0}\"", traceName);
                RunProcessAndWait(psi, logFileStream);

                // Stop the trace session
                psi.Arguments = string.Format("-stop \"{0}\"", traceName);
                RunProcessAndWait(psi, logFileStream);

                // If logging to disk is enabled, convert the binary log file to a human-readable text file
                if (enableLogFile)
                {
                    psi.FileName = "ETWTools\\tracefmt.exe";
                    psi.Arguments =
                        string.Format("\"{0}\" -o \"{1}.txt\" -tmf \"ETWTools\\Default.tmf\" -v", traceLogFileName, traceName);
                    RunProcessAndWait(psi, logFileStream);
                }
            }
        }

        /// <summary>
        /// Set up a BackgroundWorker for use by the real-time debugger formatting process.
        /// </summary>
        /// <param name="worker">BackgroundWorker to be configured</param>
        private static void ConfigureRealTimeFormattingWorker(BackgroundWorker worker)
        {
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = false;
            worker.DoWork += RunTraceFmtInRealTimeMode;
        }

        /// <summary>
        /// Start tracefmt.exe in real-time mode with formatting to OutputDebugString() for DebugView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// In this mode, tracefmt.exe will remain running for the duration of the trace session. For that reason,
        /// we need to run it in a background thread so as not to lock up our main window. Normally, when the trace
        /// session ends, tracefmt.exe exits immediately.
        /// </remarks>
        static void RunTraceFmtInRealTimeMode(object sender, DoWorkEventArgs e)
        {
            ProcessStartInfo psi = CreateProcessStartInfo("ETWTools\\tracefmt.exe", IntPtr.Zero);
            psi.Arguments =
                string.Format("-rt \"{0}\" -ods -displayonly -v -tmf \"ETWTools\\Default.tmf\"", (string)e.Argument);

            // Tracefmt.exe normally exits immediately when the trace session stops.
            // Just to be sure that it does, wait until the main window requests a stop, then verify
            // that it has exited.  If it hasn't, then explicitly kill the process.
            Process p = Process.Start(psi);

            while (!_realTimeFormattingWorker.CancellationPending)
            {
                Thread.Sleep(2000);
            }

            if (!p.HasExited)
            {
                try
                {
                    p.Kill();
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// Start the external formatter utility that provides real-time formatting into OutputDebugString().
        /// </summary>
        /// <param name="traceName">Name of the trace</param>
        private static void StartRealTimeFormatting(string traceName)
        {
            // Start the background thread and continue execution without waiting.
            _realTimeFormattingWorker.RunWorkerAsync(traceName);
        }

        /// <summary>
        /// Stop the external formatter utility that provides real-time formatting into OutputDebugString().
        /// </summary>
        private static void StopRealTimeFormatting()
        {
            // Request the background thread to stop and continue execution without waiting.
            _realTimeFormattingWorker.CancelAsync();
        }

        private static ProcessStartInfo CreateProcessStartInfo(string fileName, IntPtr parentWindowHandle)
        {
            ProcessStartInfo psi = new ProcessStartInfo(fileName);
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.LoadUserProfile = false;
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;

            if (parentWindowHandle != null)
            {
                psi.ErrorDialog = true;
                psi.ErrorDialogParentHandle = parentWindowHandle;
            }

            return psi;
        }

        /// <summary>
        /// Run the specified process and wait for it to exit before returning.
        /// </summary>
        /// <param name="psi">ProcessStartInfo instance describing the process to start</param>
        /// <param name="logFileStream">StreamWriter to capture the process output, or null</param>
        private static void RunProcessAndWait(ProcessStartInfo psi, StreamWriter logFileStream)
        {
            string output = null;

            Process p = Process.Start(psi);

            if (logFileStream != null)
            {
                logFileStream.WriteLine(psi.FileName + " " + psi.Arguments);
                output = p.StandardOutput.ReadToEnd();
            }
            
            p.WaitForExit(10000);

            if (logFileStream != null)
            {
                logFileStream.WriteLine(output);
            }
        }

        /// <summary>
        /// Initializes a StreamWriter for Debug.txt if logging is enabled
        /// </summary>
        /// <param name="logOutputToFile">True if logging is enabled, False otherwise</param>
        /// <returns>StreamWriter instance if logging is enabled, null otherwise</returns>
        private static StreamWriter InitLogFile(bool logOutputToFile)
        {
            if (!logOutputToFile)
            {
                return null;
            }

            return new StreamWriter("Debug.txt", false);
        }

        private static string ConvertTraceLevel(string detailLevel)
        {
            switch (detailLevel.ToLower())
            {
                case "none":
                    return "0x0";
                case "low":
                    return "0x1";
                case "medium":
                    return "0x3";
                case "high":
                    return "0x7";
                case "all":
                    return "0x7FFFFFFF";
                default:
                    throw new ArgumentException("Unrecognized detail level '" + detailLevel + "'", "detailLevel");
            }
        }
    }
}
