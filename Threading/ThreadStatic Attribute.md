# ThreadStatic Attribute

The `[ThreadStatic]` attribute ensures that each thread gets its own copy of a field. However, this doesn't work with instance fields and field initializers only execute once on the thread that's running when the static constructor executes. If you want to work with instance fields or start with a non-default value then `ThreadLocal` is better.

```csharp
//This attribute ensures that each thread gets its own copy of the field - take it away and the count goes up to 20
[ThreadStatic]
public static int _field;

static void Main(string[] args)
{
    new Thread(() =>
    {
        for (int i = 0; i < 10; i++)
        {
            _field++;
            Console.WriteLine("Thread A: {0}", _field);
        }
    }).Start();

    new Thread(() =>
    {
        for (int i = 0; i < 10; i++)
        {
            _field++;
            Console.WriteLine("Thread B: {0}", _field);
        }
    }).Start();

    Console.ReadKey();
}
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE4MjAwNzQ5MDQsMTg4OTQ3OTAxN119
-->