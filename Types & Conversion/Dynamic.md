# Dynamic

Declaring a type as dynamic stops the compiler statically type checking the object to see if it has the methods that you're trying to call and instead does it at run time. This is helpful when working the COM objects. `ExpandoObject` is a sealed implementation that allows you to dynamically add/read properties to it. `DynamicObject` is a more advanced implementation that can be inherited to customise behaviour.
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTEzMjk1NDgyNjYsLTQ4NDAzNzM1Nl19
-->