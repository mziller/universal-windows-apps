# Logging sample

This sample shows how to use the Logging APIs in the
Windows.Foundation.Diagnostics namespace, including LoggingChannel,
LoggingActivity, LoggingSession, and FileLoggingSession. These classes are
designed for diagnostic logging within a modern application. These APIs were
added in Windows 8.1. The LoggingChannel and LoggingActivity APIs have been
extended in Windows 10 to support writing complex events using TraceLogging
event encoding.

- **LoggingChannel:** The LoggingChannel class is used to generate events.
  The core LoggingChannel APIs can create simple events - events with
  a name and a string value, or events with a name, a string value, and an
  integer value. Starting with Windows 10, the LoggingChannel class can use
  TraceLogging event encoding to create complex events with arbitrary
  structured data.
- **LoggingActivity:** The LoggingActivity class is used to encapsulate an
  activity by writing a Start event when the activity is created and a Stop
  event when the activity is closed. Starting with Windows 10, the
  LoggingActivity class can use TraceLogging event encoding to write
  complex events associated with the activity and to support nested activities.
- **LoggingSession:** The LoggingSession class captures events into an
  in-memory circular buffer with the ability to save the buffer contents to a
  log file on-demand.
- **FileLoggingSession:** The FileLoggingSession class captures events directly
  to a sequence of log files, switching to a new log file when the maximum file
  size is reached.

The Logging classes are based on Windows ETW APIs. Events from these classes
can be captured using ETW tools such as xperf. The log files are generated in
ETL format so they can be viewed and processed by the Windows Performance
Toolkit (WPT), as well as utilities such as tracerpt.exe or xperf.exe.

**Note** The Windows universal samples require Visual Studio 2015 to build and Windows 10 to execute.
 
To obtain information about Windows 10, go to [Windows 10](http://go.microsoft.com/fwlink/?LinkID=532421)

To obtain information about Microsoft Visual Studio 2015 and the tools for developing Windows apps, go to [Visual Studio 2015](http://go.microsoft.com/fwlink/?LinkID=532422)

## Related topics

### Samples

[Logging Sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Logging)

### Reference

<!-- Add links to related API -->

[LoggingChannel](https://msdn.microsoft.com/en-us/library/windows/apps/windows.foundation.diagnostics.loggingchannel.aspx)

[LoggingActivity](https://msdn.microsoft.com/en-us/library/windows/apps/windows.foundation.diagnostics.loggingactivity.aspx)

[LoggingSession](https://msdn.microsoft.com/en-us/library/windows/apps/windows.foundation.diagnostics.loggingsession.aspx)

[FileLoggingSession](https://msdn.microsoft.com/en-us/library/windows/apps/windows.foundation.diagnostics.fileloggingsession.aspx)

## System requirements

**Client:** Windows 10 Technical Preview

**Server:** Windows 10 Technical Preview

**Phone:**  Windows 10 Technical Preview

## Build the sample

1. Start Microsoft Visual Studio 2015 and select **File** \> **Open** \> **Project/Solution**.
2. Go to the directory to which you unzipped the sample. Then go to the subdirectory containing the sample in the language you desire - either C++, C#, or JavaScript. Double-click the Visual Studio 2015 Solution (.sln) file. 
3. Press Ctrl+Shift+B, or select **Build** \> **Build Solution**. 

## Run the sample

The next steps depend on whether you just want to deploy the sample or you want to both deploy and run it.

### Deploying the sample

- Select Build > Deploy Solution. 

### Deploying and running the sample

- To debug the sample and then run it, press F5 or select Debug >  Start Debugging. To run the sample without debugging, press Ctrl+F5 or selectDebug > Start Without Debugging. 
