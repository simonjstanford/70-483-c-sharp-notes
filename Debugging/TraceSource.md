# TraceSource

TraceSource was added in .NET 2.0 and should be used instead of the static Trace class. TraceSource is a way to output info from an application to a logging mechanism (a log file, Windows Event Viewer, etc.) while the application is running. This helps to debug an application in release mode.

Firstly, a System.Diagnostics section is added to the App.config file. The listener type is defined as a TextWriterTraceListener object which will output the logging to a file called myListener.log in the bin folder. The listener is waiting for all TraceEventTypes but you can be more specific. You can create as many sources as you like, e.g. one for each application layer and they could all output in different ways.

    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
      </startup>
    
      <system.diagnostics>
        <sources>
          <source name="Log" switchValue="All" switchType="System.Diagnostics.SourceSwitch">
            <listeners>
              <add name="myListener"/>
              <remove name="Default"/>
            </listeners>
          </source>
        </sources>
        <sharedListeners>
          <add name="myListener"
               type="System.Diagnostics.TextWriterTraceListener"
               initializeData="myListener.log">
          </add>
        </sharedListeners>
      </system.diagnostics>
    </configuration>

  

Then call the TraceSource object from code when you need it:

    using System;
    using System.Diagnostics;
    
    namespace DebugExample
    {
        class Program
        {
            private static TraceSource traceSource = new TraceSource("Log");
    
            static void Main(string[] args)
            {
                //'1' here is the event ID number - it has no inferred meaning so can be used to logically group your events
                traceSource.TraceData(TraceEventType.Information, 1, "Logged!");
    
                //make sure the trace gets written
                traceSource.Flush();
                traceSource.Close();
    
                Console.Read();
            }
        }
    }

  

To turn off logging you can just update the app.config file:



A trace source can can use more than one listener. The following configuration
outputs all traces to the log file in the bin folder and adds critical events
to the Windows Event Viewer:

  

<?xml version="1.0" encoding="utf-8" ?>

<configuration>

  <startup>

    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />

  </startup>

  

  <system.diagnostics>

    <sources>

      <source name="Log" switchValue="All" switchType="System.Diagnostics.SourceSwitch">

        <listeners>

          <add name="eventLogListener"

               type="System.Diagnostics.EventLogTraceListener"

               initializeData="TraceListenerLog">

            <filter type="System.Diagnostics.EventTypeFilter"

                    initializeData="Critical"/>

          </add>

  

          <add name="myListener"/>

          <remove name="Default"/>

        </listeners>

      </source>

    </sources>

    <sharedListeners>

      <add name="myListener"

           type="System.Diagnostics.TextWriterTraceListener"

           initializeData="myListener.log">

      </add>

    </sharedListeners>

  </system.diagnostics>

</configuration>

  

  

You can output more detailed information:

  

traceSource.TraceInformation("Tracing application...");

traceSource.TraceEvent(TraceEventType.Critical, 0, "Critical trace");

traceSource.TraceData(TraceEventType.Information, 1, new Person() { FirstName
= "Simon", LastName = "Stanford" });

  

//make sure the trace gets written

traceSource.Flush();

traceSource.Close();

  

There are several options in the TraceEventType enum:

  *  **Critical** : most severe option, used for serious errors.
  *  **Error**
  *  **Warning**
  *  **Information**
  *  **Verbose:**  General output that may appear in vast quantities, e.g. tracking the progress of a method.
  *  **Stop, Start, Suspend, Resume, Transfer** : Logs application flow

  

There are other TraceListeners that can be used, but you can also define your
own trace listeners by inheriting from the TraceListener base class and
specifying your own implementation for the trace methods.

  

 **Name**

|

 **Output**  
  
---|---  
  
ConsoleTraceListener

|

Standard output or error stream  
  
DelimitedListTraceListener

|

TextWriter  
  
EventLogTraceListener

|

EventLog  
  
EventSchemaTraceListener

|

XML-encoded, schema compliant log file  
  
TextWriterTraceListener

|

TextWriter  
  
XmlWriterTraceListener

|

Xml-encoded data to a TextWriter or stream  
  
  

You can also create your own TraceListener by deriving from the TraceListener
base class.

![noteattachment1][718cc81ef7829f1fc4c8a01b63fb2278]  


---
### ATTACHMENTS
[718cc81ef7829f1fc4c8a01b63fb2278]: media/EmailTraceListener.cs
[EmailTraceListener.cs](media/EmailTraceListener.cs)
>hash: 718cc81ef7829f1fc4c8a01b63fb2278  
>source-url: file://C:\TFS\DEV\Tersus\Client\Shell\Shell\Helpers\Trace Listeners\EmailTraceListener.cs  
>file-name: EmailTraceListener.cs  
>attachment: true  

---
### NOTE ATTRIBUTES
>Created Date: 2016-11-12 12:17:24  
>Last Evernote Update Date: 2016-11-14 17:35:33  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  


<!--stackedit_data:
eyJoaXN0b3J5IjpbMjUwNzA4NDQxXX0=
-->