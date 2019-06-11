# Structs

- Stucts can't be inherited so you can't use the protected or protected internal access modifiers. 
- They can implement an interface.
- Constructors are optional but if included they must contain parameters - no default constructors are allowed.
- Fields can't be initialised in the struct body. They must be initialized via the constructor or after the struct is declared.
- Private members can only be initialised in the constructor. All members must be initialised by the constructor if there is one.
- Members that are reference types must have their constructors called explicitly.
- Structs can be declared without the new operator, but all the members remain unassigned.
- Stucts are stored in the stack and are value types. This means that they are copied when passed around an application.
- Use a struct to create a custom value type - this is usually done to improve performance of small, immutable objects that are used a lot.

https://msdn.microsoft.com/en-us/library/0taef578.aspx
<!--stackedit_data:
eyJoaXN0b3J5IjpbMjAwNDQ1MzIwOCwtMTIwODE0NDA3NV19
-->