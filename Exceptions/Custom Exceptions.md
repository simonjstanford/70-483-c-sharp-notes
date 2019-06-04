# Custom Exceptions

  * Custom exceptions are derived from Exception.
  * Custom exceptions require a parameterless constructor. It's best practice to also add one with a string, another with a string & exception, and one for serialisation (e.g. for a web service).
  * Never inherit from System.ApplicationException.


---
### NOTE ATTRIBUTES
>Created Date: 2016-12-23 11:28:02  
>Last Evernote Update Date: 2016-12-23 11:30:10  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTQ0NTg1MDAwNl19
-->