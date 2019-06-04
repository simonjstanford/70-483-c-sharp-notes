# IEquatable

- Used to determine if one object equals another object.
- Enables use List.Contains(), IndexOf(), LastIndexOf() and Remove()
- You also need to override Object.Equals() for performance and GetHashCode() to ensure that the object works in a hash table.


Defintion:

```csharp
namespace System
{
    public interface IEquatable<T>
    {
        bool Equals(T other);
    }
}
```

https://msdn.microsoft.com/en-us/library/ms131187(v=vs.110).aspx
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTQ1NjU4NzI5OV19
-->