# Anonymous Types

This is a type that is created at compile time without a formal class definition. This uses Object Initialisation Syntax and Implicitly Typed Variables. Anonymous types are used in LINQ when creating a 'projection' - selecting properties from a query and creating a type from it.

An anonymous type is created like this:

```csharp
var person = new
{
     FirstName = "Simon",
     LastName = "Stanford"
};
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTIwMDYyNTU0MDFdfQ==
-->