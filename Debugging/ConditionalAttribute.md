# ConditionalAttribute

The ConditionalAttribute can used instead of the #if directive when you want
to execute/skip an entire method, e.g. when you only want to execute a logging
method when in debug.

  

static void Main(string[] args)

{

    LogStuff();

    Console.ReadKey();

}

  

[Conditional("DEBUG")]

static void LogStuff()

{

    Console.WriteLine("Debugging!");

}

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-11-09 20:17:00  
>Last Evernote Update Date: 2016-11-09 20:20:46  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  
<!--stackedit_data:
eyJoaXN0b3J5IjpbMzIyNTAxMjk1XX0=
-->