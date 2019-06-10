# ThreadPool

A Thread object is disposed when execution finishes. You can use a thread pool
instead to store threads and reuse them. The advantage is that work items are
added to the queue and executed when a thread becomes available. This means
that the number of concurrent threads is managed and e.g. a web server will
not crash if inundated with requests. Note that local state is shared between
uses of a thread. However, you won't know when each operation finishes and
what the return value is.

  

ThreadPool.QueueUserWorkItem((s) =>

{

    Console.WriteLine( "Working on a thread from threadpool" );

});

  

You can also pass in a state object to QueueUserWorkItem. This is an object
that the thread can work with. Note that you need to be careful with for loops
- if you don't copy the for variable then each thread will have the same value
for i:

  

for (int i = 0; i < 10; ++i)

{

    // Closure extends to here.  
    var copy = i;  
  
    // **copy** is captured

    ThreadPool.QueueUserWorkItem(delegate { DoWork("closure", copy); });

}

<http://stackoverflow.com/questions/12977838/queueuserworkitem-with-delegate-
does-not-work-but-waitcallback-does-work>

  

<https://msdn.microsoft.com/en-us/library/4yd16hza(v=vs.110).aspx>

  

![noteattachment1][ff6a2c19d772a36e9bc4b49e673a7dfc]

![noteattachment2][427cb26c983496ce5b308ed12c4af8bd]  

<https://msdn.microsoft.com/en-us/library/02x3daw5(v=vs.110).aspx>

  

  * All threads in the thread pool are background threads.
  * A thread in the thread pool can't be interrupted.
  * You can't join a thread from a thread pool.
  * You can't set the priority of threads in a thread pool.

  

Normally, the thread pool isn't used directly. Instead, you would use
something that sits on top of it:

  

  * task parallel library: <https://msdn.microsoft.com/en-us/library/dd460717(v=vs.110).aspx> 
  * asynchronous pattern model: <https://msdn.microsoft.com/en-us/library/ms228963(v=vs.110).aspx> 
  * event based asynchronous pattern: <https://msdn.microsoft.com/en-us/library/ms228969(v=vs.110).aspx> 
  * task based asynchronous pattern model:  <https://msdn.microsoft.com/en-us/library/hh873175(v=vs.110).aspx> 
  * async/await.


---
### ATTACHMENTS
[ff6a2c19d772a36e9bc4b49e673a7dfc]: media/1.PNG
[1.PNG](media/1.PNG)
>hash: ff6a2c19d772a36e9bc4b49e673a7dfc  
>source-url: file://C:\Users\simon\Desktop\1.PNG  
>file-name: 1.PNG  

[427cb26c983496ce5b308ed12c4af8bd]: media/2.PNG
[2.PNG](media/2.PNG)
>hash: 427cb26c983496ce5b308ed12c4af8bd  
>source-url: file://C:\Users\simon\Desktop\2.PNG  
>file-name: 2.PNG  

---
### NOTE ATTRIBUTES
>Created Date: 2016-11-18 12:55:23  
>Last Evernote Update Date: 2017-02-13 22:20:06  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-url: http://stackoverflow.com/questions/12977838/queueuserworkitem-with-delegate-does-not-work-but-waitcallback-does-work  
>source-application: evernote.win32  
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE0NTAzNzMxNTVdfQ==
-->