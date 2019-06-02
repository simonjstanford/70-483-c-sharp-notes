# Lock-Free Alternatives/Interlocked

**Interlocked**

 **  
**

This object ensures atomic operations on variables shared by multiple threads.
Used to prevent the Windows scheduler switching threads midway through a
sequence of common operations:

  

![noteattachment1][74ee15cf103beb238eddb452b6c73bef]  

  

Example of usage:

 **  
**

public static void InterlockedExample()

{

int n = 0;

  

//Interlocked ensures incrementing a value is an atomic action,

var up = Task.Run(() =>

{

for (int i = 0; i < [1000000](tel:1000000); i++)

{

Interlocked.Increment(ref n);

}

});

  

for (int i = 0; i < [1000000](tel:1000000); i++)

{

Interlocked.Decrement(ref n);

}

  

up.Wait();

  

Console.WriteLine(n);

Console.ReadKey();

  

//you can also switch two values

int previousNumber = Interlocked.Exchange(ref n, 6);

  

//this checks the value before changing it

int previousNumber2 = Interlocked.CompareExchange(ref n, 7, 6);

  

Console.WriteLine(n);

Console.ReadKey();

}

 **  
**

<https://msdn.microsoft.com/en-
us/library/system.threading.interlocked(v=vs.110).aspx>  

  


---
### ATTACHMENTS
[74ee15cf103beb238eddb452b6c73bef]: media/Lock-Free_AlternativesInterlocked.png
[Lock-Free_AlternativesInterlocked.png](media/Lock-Free_AlternativesInterlocked.png)
---
### NOTE ATTRIBUTES
>Created Date: 2016-11-18 13:00:14  
>Last Evernote Update Date: 2017-01-22 17:09:41  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  