# The Debug Class

  * Tracing is a way to monitor the execution of an application while it's running.
  * Logging is always enabled and is used for error reporting and can be configured to to collect data in a particular way, e.g. send an email.
  * The `Debug` class: 
    * Can be used for basic logging and execution assertions. 
    * Can only be used in a debug build. This happens because the `Debug` class has a [ConditionalAttribute](ConditionalAttribute.md) with a value of DEBUG is applied to the class. 

  

The following will only execute if the application is in debug mode. This means that you can indicate a bug in an application during development:  

```csharp
Debug.WriteLine("Starting application");
Debug.Indent();
int i = 1 + 2;
Debug.Assert(i == 1); //displays an error message asking you to retry/abort/ignore
Debug.WriteLineIf(i > 0, "i is greater than 0");
```

Both the Debug and Trace classes have a Listeners collection that holds references to listener objects. Initially, they hold a reference to a DefaultTraceListener object, but you can add other classes:

  * `ConsoleTraceListener`
  * `EventLogTraceListener`
  * `TextWriterTraceListener` - sends output to a stream

```csharp
Stream traceStream = File.Create("TraceFile.txt");

TextWriterTraceListener traceListener = new TextWriterTraceListener(traceStream);

Debug.Listeners.Add(traceListener);
Trace.Listeners.Add(traceListener);

Debug.WriteLine("Trace started: " + DateTime.Now);

Debug.Flush();
```

<https://msdn.microsoft.com/en-us/library/ttcc4x86.aspx>
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE0MTU5MjI3NzYsMTE4MTY5NDM5XX0=
-->