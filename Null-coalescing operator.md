# Null-coalescing operator

Null-coalescing operator provides a default value for nullable value types or
reference types. I.e, x is returned if it's not null, else -1:  

  

int? x = null;

int y = x ?? -1;

  

It can be nested:

  

int? x = null;

int? z = null;

int y = x ?? z ?? -1;

  


---
### NOTE ATTRIBUTES
>Created Date: 2017-01-10 19:45:25  
>Last Evernote Update Date: 2017-01-10 19:45:30  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  