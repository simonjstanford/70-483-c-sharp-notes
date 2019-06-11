# Structs

Normally, reference types are stored in the heap, values types in the stack. However, a value type is stored in the heap when a class contains a value type as a field, a lambda expression closes over a value type, or the value type is boxed.

A class that is declared directly within a namespace has the following access modifiers: (default is internal):
- `public
- internal
- Nested classes and structs can also be declared as private.

A class's members access modifiers are (the default is private):
- public
- private
- internal - same assembly
- protected - inside the class or from a class that inherits it
- internal protected - mixture of the above two

Interfaces and enums can only be public.

InternalsVisibleToAttribute is an attribute that exposes a method with an internal access modifier to a given assembly. This is helpful when you want to write unit tests for the method:

```csharp
[assembly: InternalsVisibleTo("CompanyName.Project.MyAssembly.Test")]
```

A method defined as public inside an internal class will be internal. However, an internal implementation of an interface will stay internal. An internal override of a public virtual member will be internal.
<!--stackedit_data:
eyJoaXN0b3J5IjpbMzM3OTIwMDQ4LC0xMjA4MTQ0MDc1XX0=
-->