# Generics

When implementing generics you can restrict the type that is provided in the signature:

struct `Nullable<T>` where T : struct

There are several options and more than one can be used:

- `where T : struct` - must be a value type
- `where T : class` - must be a reference type (including class, interface, delegate)
- `where T : new()` - must have a public default constructor
- `where T : <base class name>` - must be or derive from the specified class
- `where T : <interface name>` - must be or implement the specified interface. Multiple interfaces can be provided
- `where T : U` - must be or derive from the argument supplied for `U`


The method `default(T)` provides the default value for a generic type:

```csharp
T defaultVal = default(T);
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTYzOTIwMTc0MCwtMTg5Nzc1OTQ1NV19
-->