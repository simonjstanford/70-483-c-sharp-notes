# ConditionalAttribute

The `ConditionalAttribute` can used instead of the `#if` directive when you want to execute/skip an entire method, e.g. when you only want to execute a logging method when in debug.

```csharp
static void Main(string[] args)
{
    LogStuff();
    Console.ReadKey();
}

[Conditional("DEBUG")]
static void LogStuff()
{
    Console.WriteLine("Debugging!");
}
```

<!--stackedit_data:
eyJoaXN0b3J5IjpbLTU1NDUxNzg5LC0xMzY5NTkyMTMyXX0=
-->