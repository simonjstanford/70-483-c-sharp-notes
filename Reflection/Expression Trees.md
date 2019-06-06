# Expression Trees

This is a way of dynamically generating code (like CodeDom), but you describe
the code and the compiler creates it for you (like how LINQ is declarative not
procedural).

  

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

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-10-03 21:12:03  
>Last Evernote Update Date: 2016-11-07 22:15:54  
>author: simonjstanford@gmail.com  
<!--stackedit_data:
eyJoaXN0b3J5IjpbNzY2NzM1Mzc2XX0=
-->