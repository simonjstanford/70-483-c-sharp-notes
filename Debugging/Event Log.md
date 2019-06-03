# Event Log

  * Aside from entering info into the Windows Event Viewer via a TraceListener (See [TraceSource](TraceSource.md)), you can also do it programmatically.
  * Note that you need Administrator privileges to read some of the event logs.
  * After execution, the 'MyLog' log appears in the 'Applications and Services Logs' section of the Event Viewer.

```csharp
if (!EventLog.SourceExists("MySource"))
{
    EventLog.CreateEventSource("MySource", "MyLog");
}

EventLog myLog = new EventLog();
myLog.Source = "MySource";
myLog.WriteEntry("Something happened!");
```

And to read the event log:

    EventLog log = new EventLog("MyLog");
    Console.WriteLine("Total entries: " + log.Entries.Count);
    EventLogEntry last = log.Entries[log.Entries.Count - 1];
    
    Console.WriteLine("Index:   " + last.Index);
    Console.WriteLine("Source:  " + last.Source);
    Console.WriteLine("Type:    " + last.EntryType);
    Console.WriteLine("Time:    " + last.TimeWritten);
    Console.WriteLine("Message: " + last.Message);
    
    Console.ReadKey();


  

Or you could subscribe to an event that fires when a new entry is put in the log:

    static void Main(string[] args)
    {
        if (!EventLog.SourceExists("MySource"))
        {
            EventLog.CreateEventSource("MySource", "MyLog");
        }
    
        EventLog myLog = new EventLog();
        myLog.Source = "MySource";
        myLog.WriteEntry("Something happened!");
    
        EventLog log = new EventLog("MyLog", "Simon-Laptop", "MySource");
        log.EntryWritten += Log_EntryWritten;
        log.EnableRaisingEvents = true;
        log.WriteEntry("Help!", EventLogEntryType.Error);
    
        Console.ReadKey();
    }
    
    private static void Log_EntryWritten(object sender, EntryWrittenEventArgs e)
    {
        Console.WriteLine("Event received:");
        Console.WriteLine("Index:   " + e.Entry.Index);
        Console.WriteLine("Source:  " + e.Entry.Source);
        Console.WriteLine("Type:    " + e.Entry.EntryType);
        Console.WriteLine("Time:    " + e.Entry.TimeWritten);
        Console.WriteLine("Message: " + e.Entry.Message);
    }


<https://msdn.microsoft.com/en-us/library/system.diagnostics.eventlog.aspx>
<https://msdn.microsoft.com/en-us/library/2awhba7a.aspx>


<!--stackedit_data:
eyJoaXN0b3J5IjpbMTM2MzUzNDc1NiwxNzQ2NTMzMzAwLC03NT
A4MzA4MDRdfQ==
-->