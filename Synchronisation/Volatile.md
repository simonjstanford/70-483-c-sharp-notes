# Volatile

The volatile keywod is used with objects that are accessed by multiple
threads. It stops compiler optimisation that can potentially change the order
that code is executed as it assumes serial access. Use volatile to ensure that
the most up to date version of a variable is returned in a multi threaded
environment.

  

private static volatile int flag = 0;

  

<https://msdn.microsoft.com/en-us/library/x13ttww7.aspx>

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-12-29 15:57:27  
>Last Evernote Update Date: 2017-01-22 17:37:14  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  
<!--stackedit_data:
eyJoaXN0b3J5IjpbNjYyNTU4OTY0XX0=
-->