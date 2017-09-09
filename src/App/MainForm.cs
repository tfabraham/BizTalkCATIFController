// BizTalk CAT Instrumentation Framework Controller
// Copyright (C) 2010-Present Thomas F. Abraham. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BizTalkCatInstrumentationController
{
    /// <summary>
    /// The application's main user interface form.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Indictates whether to skip saving settings on application exit.
        /// </summary>
        private bool _doNotSaveSettings = false;

        /// <summary>
        /// Indicates if a trace is running.
        /// </summary>
        private bool _traceRunning = false;

        /// <summary>
        /// Used to hold the last state of the filter list view toggle button.
        /// </summary>
        private bool _lastDetailToggle = false;

        /// <summary>
        /// Indicates whether command line tool output will be logged to a file.
        /// </summary>
        private bool _logToolOutputToFile = false;

        private string _debugViewPath = null;
        private string _textEditorPath = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AddVersionToTitle();

            // Check for the external tools that we need to function.
            if (!CheckForRequiredFiles())
            {
                _doNotSaveSettings = true;
                this.Close();
                return;
            }

            // Load per-user settings.
            LoadSettings();
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            if (!_traceRunning)
            {
                if (!VerifyStartConditions())
                {
                    return;
                }

                StartTrace();
            }
            else
            {
                StopTrace();
            }

            _traceRunning = !_traceRunning;

            // Reconfigure the GUI for the new state.
            if (_traceRunning)
            {
                this.startStopButton.Text = "Stop Trace";
            }
            else
            {
                this.startStopButton.Text = "Start Trace";
            }

            SetControlStates(!_traceRunning);
        }

        /// <summary>
        /// Verify that settings are valid for a trace to begin.
        /// </summary>
        /// <returns>True if OK, False otherwise</returns>
        private bool VerifyStartConditions()
        {
            if (!logToFileCheckBox.Checked && !logToDebugViewCheckBox.Checked)
            {
                MessageBox.Show(
                    this,
                    "Please check at least one of the debug output options.",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (filterListView.CheckedItems.Count == 0)
            {
                MessageBox.Show(
                    this,
                    "Please check at least one of the trace filter options.",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (overrideCustomGuidCheckBox.Checked && string.IsNullOrEmpty(customComponentGuidTextBox.Text))
            {
                MessageBox.Show(
                    this,
                    "Please enter a custom component GUID or uncheck the override checkbox.",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toggleSelectionButton_Click(object sender, EventArgs e)
        {
            // Toggles all of the trace filter checkboxes on or off
            _lastDetailToggle = !_lastDetailToggle;

            foreach (ListViewItem lvi in filterListView.Items)
            {
                lvi.Checked = _lastDetailToggle;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm of = new OptionsForm();

            of.LogToolOutputToFile = _logToolOutputToFile;
            of.DebugViewPath = _debugViewPath;
            of.TextEditorPath = _textEditorPath;

            if (of.ShowDialog() == DialogResult.OK)
            {
                _logToolOutputToFile = of.LogToolOutputToFile;
                _debugViewPath = of.DebugViewPath;
                _textEditorPath = of.TextEditorPath;
            }
        }

        private void launchDebugViewButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_debugViewPath))
            {
                MessageBox.Show(
                    this,
                    "Please specify the path to DbgView.exe in the File/Options dialog.",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // If DebugView is already running, then activate and show the first instance,
            // otherwise start up a new instance.
            Process[] dbgViewProcesses = Process.GetProcessesByName("dbgview");

            if (dbgViewProcesses.Length == 0)
            {
                Process.Start(_debugViewPath);
            }
            else
            {
                Microsoft.VisualBasic.Interaction.AppActivate(dbgViewProcesses[0].Id);
                SafeNativeMethods.ShowWindow(dbgViewProcesses[0].MainWindowHandle, 9);
            }
        }

        private void launchTextEditorButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_textEditorPath))
            {
                MessageBox.Show(
                    this,
                    "Please specify the path to your preferred text editor in the File/Options dialog.",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Process.Start(_textEditorPath, "\"" + TraceManager.GetFormattedTraceFileName(traceNameTextBox.Text) + "\"");
        }

        private void overrideCustomGuidCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            customComponentGuidTextBox.Enabled = overrideCustomGuidCheckBox.Checked;
        }

        private void SetControlStates(bool enabled)
        {
            foreach (Control c in this.Controls)
            {
                if (c != startStopButton && c != launchDebugViewButton)
                {
                    c.Enabled = enabled;
                }
            }

            Application.DoEvents();
        }

        /// <summary>
        /// Verify that all of the required external tools are present.
        /// </summary>
        /// <returns>True if OK, False otherwise</returns>
        private bool CheckForRequiredFiles()
        {
            if (!CheckForRequiredFile("ETWTools\\tracefmt.exe"))
            {
                return false;
            }

            if (!CheckForRequiredFile("ETWTools\\tracelog.exe"))
            {
                return false;
            }

            if (!CheckForRequiredFile("ETWTools\\traceprt.dll"))
            {
                return false;
            }

            if (!CheckForRequiredFile("ETWTools\\Default.tmf"))
            {
                return false;
            }

            return true;
        }

        private bool CheckForRequiredFile(string filename)
        {
            if (!File.Exists(filename))
            {
                MessageBox.Show(
                    this,
                    "Cannot find " + filename + ".",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Add version number to the form's title.
        /// </summary>
        private void AddVersionToTitle()
        {
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
            this.Text = this.Text.Replace("{Version}", "V" + version);
        }

        private void LoadSettings()
        {
            logToDebugViewCheckBox.Checked = Properties.Settings.Default.LogToDebugView;
            logToFileCheckBox.Checked = Properties.Settings.Default.LogToFile;
            detailLevelComboBox.SelectedItem = Properties.Settings.Default.DetailLevel;
            traceNameTextBox.Text = Properties.Settings.Default.TraceLogName;
            _debugViewPath = Properties.Settings.Default.DebugViewPath;
            _textEditorPath = Properties.Settings.Default.TextEditorPath;

            if (Properties.Settings.Default.FilterSelections == null)
            {
                Properties.Settings.Default.FilterSelections = new System.Collections.Specialized.StringCollection();
            }
            else
            {
                foreach (string guid in Properties.Settings.Default.FilterSelections)
                {
                    // Search for a list view item with a matching GUID in the second column.
                    ListViewItem lvi = filterListView.FindItemWithText(guid, true, 0);

                    if (lvi != null)
                    {
                        lvi.Checked = true;
                    }
                }
            }
        }

        private void SaveSettings()
        {
            if (_doNotSaveSettings)
            {
                return;
            }

            Properties.Settings.Default.LogToDebugView = logToDebugViewCheckBox.Checked;
            Properties.Settings.Default.LogToFile = logToFileCheckBox.Checked;
            Properties.Settings.Default.DetailLevel = detailLevelComboBox.SelectedItem.ToString();
            Properties.Settings.Default.TraceLogName = traceNameTextBox.Text;
            Properties.Settings.Default.DebugViewPath = _debugViewPath;
            Properties.Settings.Default.TextEditorPath = _textEditorPath;

            Properties.Settings.Default.FilterSelections.Clear();
            foreach (ListViewItem lvi in filterListView.Items)
            {
                if (lvi.Checked)
                {
                    Properties.Settings.Default.FilterSelections.Add(lvi.SubItems[1].Text);
                }
            }
            
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Begin an ETW trace.
        /// </summary>
        private void StartTrace()
        {
            string traceLogName = traceNameTextBox.Text;
            string detailLevel = detailLevelComboBox.SelectedItem.ToString();
            bool enableRealTime = logToDebugViewCheckBox.Checked;
            bool enableLogFile = logToFileCheckBox.Checked;

            List<string> guidsToTrace = new List<string>();
            foreach (ListViewItem lvi in filterListView.CheckedItems)
            {
                if (string.Compare((string)lvi.Tag, "Custom", true) == 0)
                {
                    // If the override checkbox was checked, then we replace the normal GUID
                    // for Custom (in the ListView) with the one specified by the user.
                    if (overrideCustomGuidCheckBox.Checked)
                    {
                        guidsToTrace.Add(customComponentGuidTextBox.Text);
                    }
                    else
                    {
                        guidsToTrace.Add(lvi.SubItems[1].Text);
                    }
                }
                else
                {
                    guidsToTrace.Add(lvi.SubItems[1].Text);
                }
            }

            TraceManager.StartTrace(
                this.Handle, traceLogName, detailLevel, enableRealTime, enableLogFile, guidsToTrace, _logToolOutputToFile);
        }

        /// <summary>
        /// End an ETW trace.
        /// </summary>
        private void StopTrace()
        {
            string traceLogName = traceNameTextBox.Text;
            bool enableRealTime = logToDebugViewCheckBox.Checked;
            bool enableLogFile = logToFileCheckBox.Checked;

            TraceManager.StopTrace(this.Handle, traceLogName, enableRealTime, enableLogFile, _logToolOutputToFile);
        }
    }
}
