# ThreadLocal<T>

The example below uses static fields to store data. Use `ThreadLocal<T>` for a strongly typed, locally scoped way of storing unique data for threads. It works with static & instance fields and allows you to specify default values.

To create an int with a default value of 3. You can then use the `Value` property to get/set the value. Calls to `ThreadLocal` are lazy - they are evaluated on first call.

```csharp
static ThreadLocal<int> x = new ThreadLocal<int>(() => 3);
```

```csharp
public static ThreadLocal<int> _field =
    new ThreadLocal<int>(() =>
    {
        return Thread.CurrentThread.ManagedThreadId;
    });

static void Main(string[] args)
{
    new Thread(() =>
    {
        for (int i = 0; i < _field.Value; i++)
        {
            Console.WriteLine("Thread A: {0}", i);
        }
    }).Start();

    new Thread(() =>
    {
        for (int i = 0; i < _field.Value; i++)
        {
            Console.WriteLine("Thread B: {0}", i);
        }
    }).Start();

    Console.ReadKey();
}
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTIwNjIxNjM5Ml19
-->