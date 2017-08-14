# BizTalk CAT Instrumentation Framework Controller
The BizTalk CAT Instrumentation Framework Controller is an easy-to-use GUI for the BizTalk CAT Instrumentation Framework. The Controller lets you start and stop a trace, adjust filter options, log to a file and/or enable real-time tracing to DebugView!

The BizTalk CAT Instrumentation Framework is a high performance tracing/logging framework for BizTalk that builds upon the Event Tracing for Windows (ETW) infrastructure. It was created by Microsoft's BizTalk Customer Advisory Team (CAT). Microsoft used essentially the same framework to instrument BizTalk itself, as well as many recently released adapters.

The BizTalk CAT team has posted several blog entries about the Framework. Get the BizTalk CAT Instrumentation Framework here.

The downside of the CAT Instrumentation Framework is that starting and stopping traces requires running command-line scripts, and by default the log data is viewable in a text file only after a trace is stopped. Many BizTalk developers are accustomed to using Trace.WriteLine() or Debug.WriteLine() in combination with the Microsoft SysInternals DebugView tool to see diagnostic messages in real time.

Enter the BizTalk CAT Instrumentation Framework Controller. **The Controller is an easy-to-use GUI for the BizTalk CAT Instrumentation Framework.** The Controller lets you start and stop a trace and adjust filter options. It can easily enable real-time tracing to Microsoft SysInternals DebugView (or other debuggers), to a log file or to both at the same time.

The Controller is designed for use both on development machines and production servers. Unlike Trace.WriteLine() or Debug.WriteLine(), with the BizTalk CAT I.F. you can enable tracing on a production server with only a negligible impact on performance (when tracing to a file).

## License

Copyright (c) Thomas F. Abraham. All rights reserved.

Licensed under the [MIT](LICENSE.txt) License.
