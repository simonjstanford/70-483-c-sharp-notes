Use `Func<T>` when you don't want to define a delegate. It can take 0-16 parameters and a return type. You can use Lambda expressions or pass a method:

```csharp
Func<int, int, int> calc = (x, y) => x + y;
calc += (x, y) => x * y;

Console.WriteLine(calc(3, 4));
```

Use Action<T> when you don't want to define a delegate and there is no return type. It can take 0-16 parameters. You can use Lambda expressions or pass a method.


Console.WriteLine("Action<T> Example");

Action<int, int> calc = (x, y) => Console.WriteLine(x + y);
calc(3, 4);

Console.WriteLine();
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE5NzQ0Mzg4OTZdfQ==
-->