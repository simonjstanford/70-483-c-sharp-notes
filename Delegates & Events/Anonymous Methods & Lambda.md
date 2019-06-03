This replaces anonymous methods. See [Events](Events.md). 

An anonymous method enables you to define a method without a name. This is done by creating a delegate. Anonymous methods are normally used to define simple event handlers or execute simple tasks on different threads.

```csharp
private Func<float, float> Function = delegate(float x) { return x * x; };
```

Or:

```csharp
Func<int,int> myDelegate =
     delegate(int x)
     {
          return x * 2;
     };
Console.WriteLine(myDelegate(21));
```

Lambda expressions are anonymous functions, i.e. a shorthand way to write a method. Closure means that variables of a method are kept in memory for at least as long as the longest living delegate.

This is an example of an expression Lambda. These are lambdas that are a single expression:


```csharp
public delegate int Calculate(int x, int y);

public void UseDelegate()
{
    Console.WriteLine("Lambda Example");

    //return types are inferred
    Calculate calc = (x, y) => x + y;
    Console.WriteLine(calc(3, 4));

    calc = (x, y) => x * y;
    Console.WriteLine(calc(3, 4));

    calc = (x, y) =>
    {
        Console.WriteLine("Adding numbers");
        return x + y;
    };

    Console.WriteLine(calc(3, 4));

    Console.WriteLine();
}
```

You don't need parentheses around the parameter if there is only one:

```csharp
Action<string> note = message => MessageBox.Show(message);
```

If you want the Lambda to have multiple lines of codes then you need to wrap them in curly brackets:

```csharp
MyLambda = () => 
{
     //code here
}
```

Lambda expressions can execute asynchronous tasks using async/await:

```csharp
MyLambda = async () => 
{
     //code
     await DoSomething();
     //code
}
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTUyNTA0Mzc2NV19
-->