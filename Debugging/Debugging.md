# Debugging

In debug configuration the compiler inserts extra:

  * No-operation (NOP) instructions, e.g. an assignment to a variable that's never used.
  * Branch instructions (code that's executed conditionally). When an instruction isn't executed it can be removed from the compiled output.

  

When optimising code for release, the compiler can also in-line short methods.


---
### NOTE ATTRIBUTES
>Created Date: 2016-11-09 19:49:00  
>Last Evernote Update Date: 2016-11-09 19:51:06  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE3MTYxNjMwMjhdfQ==
-->