# The Garbage Collector

  * GC.Collect() - forces garbage collection to occur
  * GC.WaitForPendingFinalizers() - waits for finalizers to finish
  * GC.SuppressFinalize() - prevent a finaliser being executed. This is done in Dispose() and stops the object being placed in the finalise queue.
  * GC.ReRegisterForFinalize() - requests that the system call the finalizer for the specified object.
  * GC.AddMemoryPressure() - Informs the runtime of a large allocation of unmanaged memory that should be taken into account when scheduling garbage collection.
  * GC.RemoveMemoryPressure() - Informs the runtime that unmanaged memory has been released
  * GC.RegisterForFullGCNotification - specifies that a garbage collection notification should be raised when conditions favour full garbage collection and when the collection has been completed
  * GC.CancelFullGCNotification() - cancels the registration of a garbage collection notification
  * TryStartNoGCRegion() - attempts to disallow garbage collection during the execution of a critical path if a specified amount of memory is available.
  * WaitForFullGCApproach() - returns the status of a registered notification for determining if full, blocking garbage collection is imminent.
  * WaitForFullGCComplete() - returns the status of a registered notification for determining if full, blocking garbage collection has completed 
  * WaitForPendingFinalizers() - suspends the current thread until the thread that is processing the queue of finalizers has emptied that queue.

  

<https://msdn.microsoft.com/en-US/library/system.gc(v=vs.110).aspx>


---
### NOTE ATTRIBUTES
>Created Date: 2017-01-10 19:43:15  
>Last Evernote Update Date: 2017-02-05 14:07:46  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-url: https://msdn.microsoft.com/en-US/library/system.gc(v=vs.110).aspx  
>source-application: evernote.win32  