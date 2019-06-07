# Regex Groups

You can refer to a regex group from within the expression. This expression
matches any single word character and then refers back to the group number
(1). This means that it will match the same word character repeater twice,
i.e. aa, bb, cc, etc.

  

(\w)\1

  

The same can be done with named groups:

  

(?<twice>\w)\k<twice>

  


---
### NOTE ATTRIBUTES
>Created Date: 2017-01-07 14:44:08  
>Last Evernote Update Date: 2017-01-07 14:47:08  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  
<!--stackedit_data:
eyJoaXN0b3J5IjpbNDY2Njg1MjAyXX0=
-->