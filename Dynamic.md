# Dynamic

Declaring a type as dynamic stops the compiler statically type checking the
object to see if it has the methods that you're trying to call and instead
does it at run time. This is helpful when working the COM objects.
ExpandoObject is a sealed implementation that allows you to dynamically
add/read properties to it. DynamicObject is a more advanced implementation
that can be inherited to customise behaviour.


---
### NOTE ATTRIBUTES
>Created Date: 2016-10-04 11:15:14  
>Last Evernote Update Date: 2016-10-04 11:15:31  
>author: simonjstanford@gmail.com  