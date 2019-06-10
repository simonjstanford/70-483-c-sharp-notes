# Locking

Mutual exclusion ensures only one thread at a time can access a resource. Threads are blocked from accessing a resource until available.

## Monitor
This is a primitive synchronisation object. Only works with reference types because value types are copied for different threads and boxed into different references. All methods are static.



Example of usage:

```csharp
object syncObject = new object();
Monitor.Enter(syncObject);
//do stuff
Monitor.Exit(syncObject);
```

## Lock

This above example wont release the lock if there is an exception, so you should place the Monitor.Exit() in a finally block. The 'lock' keyword can be used instead as it implicitly closes the monitor (like how a using statement works with Dispose().

- it's good practice to keep this private to restrict what's using it
- this object needs to be a reference type - a value type will be boxed so copies the value and breaks the mechanism
- it's bad practice to use 'this' as the lock - another lock from outside of the object could be trying to lock the same object. This will be difficult to debug!
- don't use a string either - string-interning means that one string object could be use for multiple variables




public static void LockExample()
{
    //lock allows synchronisation of threads by only allowing access when the lock is released
    int n = 0;

    object _lock = new object();

    var up = Task.Run(() =>
    {
        for (int i = 0; i < 1000000; i++)
        {
            lock (_lock)
            {
                n++;
            }
        }
    });

    for (int i = 0; i < 1000000; i++)
    {
        lock (_lock)
        {
            n--;
        }
    }

    up.Wait();

    Console.WriteLine(n);
    Console.ReadKey();
}

<!--stackedit_data:
eyJoaXN0b3J5IjpbLTI3MDc3NzkyMCwtMTgwNjA3MzE3NF19
-->