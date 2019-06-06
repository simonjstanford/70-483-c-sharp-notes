# Expression Trees


This is a way of dynamically generating code (like CodeDom), but you describe the code and the compiler creates it for you (like how LINQ is declarative not procedural).

```csharp
BlockExpression expression = Expression.Block(
    Expression.Call(
        null,
        typeof(Console).GetMethod("Write", new Type[] { typeof(String) }),
        Expression.Constant("Hello ")
    ),
    Expression.Call(
        null,
        typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
        Expression.Constant("World!")
    )
    );


//notice the two sets of brackets at the end!
Expression.Lambda<Action>(expression).Compile()();

Console.ReadKey();
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTEwNTYxNTI0OTldfQ==
-->