# Null-coalescing operator

Null-coalescing operator provides a default value for nullable value types or reference types. I.e, x is returned if it's not null, else -1:  

```csharp
int? x = null;
int y = x ?? -1;
```

It can be nested:

```csharp
int? x = null;
int? z = null;
int y = x ?? z ?? -1;
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTEwMTU5MTk2OTUsMTQ3MDI0MDQ4NF19
-->