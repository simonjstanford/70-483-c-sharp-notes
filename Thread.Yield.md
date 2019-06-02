#  Thread.Yield()

Thread.Sleep(0) relinquishes the thread's time slice immediately, voluntarily
handing over the CPU to other threads. Thread.Yield() does the same thing, but
only relinquishes control to threads running on the same processor. While
waiting on Sleep() a thread is blocked.

  

From MSDN, the argument in Thread.Sleep() is:

  

The number of milliseconds for which the thread is suspended. If the value of
the millisecondsTimeout argument is zero, the thread relinquishes the
remainder of its time slice to any thread of equal priority that is ready to
run. If there are no other threads of equal priority that are ready to run,
execution of the current thread is not suspended.

  

<https://msdn.microsoft.com/en-us/library/d00bd51t(v=vs.110).aspx>

  

From MSDN, the function of Thread.Yield() is:

  

Causes the calling thread to yield execution to another thread that is ready
to run on the current processor. The operating system selects the thread to
yield to. If this method succeeds, the rest of the thread's current time slice
is yielded. The operating system schedules the calling thread for another time
slice, according to its priority and the status of other threads that are
available to run. Yielding is limited to the processor that is executing the
calling thread. The operating system will not switch execution to another
processor, even if that processor is idle or is running a thread of lower
priority. If there are no other threads that are ready to execute on the
current processor, the operating system does not yield execution, and this
method returns false.

  

<https://msdn.microsoft.com/en-us/library/system.threading.thread.yield.aspx>


---
### NOTE ATTRIBUTES
>Created Date: 2017-01-30 19:55:26  
>Last Evernote Update Date: 2017-01-30 20:00:43  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-url: https://msdn.microsoft.com/en-us/library/d00bd51t(v=vs.110).aspx  
>source-application: evernote.win32  