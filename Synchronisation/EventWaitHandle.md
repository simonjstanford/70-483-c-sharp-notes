# EventWaitHandle

Synchronisation events are objects that can be in one of two states: signaled and nonsignaled. If a thread needs something to be done by another thread, it can use a synchronisation event and interrogate the state of the event as a communication mechanism. If it is signaled, it continues the execution. If not, it blocks the execution waiting for the event to be signalled. Synchronisation events are implemented by two classes: EventWaitHandle and CountdownEvent.

## EventWaitHandle
This represents a thread synchronisation event.



Example of usage:

```csharp
private static void Test()
{
    double result = 0d;

    //we this event to signal when the thread is done executing
    //the handle is created in the non-signalled state
    EventWaitHandle calculationDone = new EventWaitHandle(false, EventResetMode.ManualReset);

    //Create a work item to read from I/O
    ThreadPool.QueueUserWorkItem((x) =>
    {
        result += DoStuff();
        calculationDone.Set();
    });

    //block access to the resource until the thread above has finished
    //comment this out and see what happends
    calculationDone.WaitOne();

    result++;
    Console.WriteLine(result);
    Console.Read();
}

private static double DoStuff()
{
    Thread.Sleep(1000);
    return 1;
}
```

There are two classes that inherit from `EventWaitHandle`: `AutoResetEvent` and `ManualResetEvent`. They just create an `EventWaitHandle` object with the mode as `EventResetMode.AutoReset` or `EventResetMode.ManualReset` accordingly.

<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE4NjE3MzcxOTksMTA4OTk5Nzg5OF19
-->