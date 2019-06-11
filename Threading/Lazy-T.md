# Lazy<T>

Helps use lazy initialization - only instantiates on first use. If `Lazy<T>` is instantiated with an argument of true it implements a thread safe initialization pattern - the Singleton patter wrapped in a lock. Pass false and it's just the Singleton pattern.

```csharp
Lazy<Expensive> _expensive = new Lazy<Expensive>(() => new Expensive(), true);
public Expensive Expensive
{
    get
    {
        return _expensive.Value;
    }
}
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbNTcwMTQxODY3XX0=
-->