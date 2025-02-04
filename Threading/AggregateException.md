# AggregateException

Exceptions are marshalled towards the consumer in [Parallel LINQ (PLINQ)](Parallel%20LINQ%20%28PLINQ%29.md),  [The Parallel Class](The%20Parallel%20Class.md) and [Tasks](Tasks.md). There is the possibility of multiple exceptions being thrown due to the asynchronous behaviour of these technologies so all thrown exceptions are wrapped in an `AggregateException` which exposes an `InnerExceptions` property. This is a list of all thrown exceptions.

## Flatten
You might end up with `AggregateException.InnerExceptions` containing more `AggregateException` objects because e.g. a task might contain child tasks and these could throw exceptions. These nested lists can be flattened using `AggregateException.Flatten()`. This returns a new `AggregateException` object with a list of all exceptions in the `InnerExceptions` property:

```csharp
catch (AggregateException aex)
{
    foreach (Exception ex in aex.Flatten().InnerExceptions)
        myLogWriter.LogException (ex);
}
```

## Handle

`Handle()` provides a method of catching only specific types of exceptions and re-throwing the rest. This is the method signature - it takes a predicate that it runs over every inner exception:

```csharp
public void Handle(Func<Exception, bool> predicate)
```

If the predicate returns true then it considers that exception handled. Any exceptions in `AggregateException.InnerExceptions` that returned false are bundled into a new `AggregateException`, and this is re-thrown:

```csharp
catch (AggregateException aex)
{
    aex.Flatten().Handle (ex => // Note that we still need to call Flatten
    {
        if (ex is DivideByZeroException)
        {
            Console.WriteLine ("Divide by zero");
            return true; // This exception is "handled"
        }

        if (ex is IndexOutOfRangeException)
        {
            Console.WriteLine ("Index out of range");
            return true; // This exception is "handled"
        }

        return false; // All other exceptions will get rethrown
});
```

https://msdn.microsoft.com/en-us/library/dd997415.aspx
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTAyNTk5MzI0Nl19
-->