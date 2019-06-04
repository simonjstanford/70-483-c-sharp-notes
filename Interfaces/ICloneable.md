# ICloneable


Clones an object.

Definition:

```csharp
public interface ICloneable
{
    Object Clone();
}
```

Example of usage:

```csharp
class Person : ICloneable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Person Manager { get; set; }

    public object Clone()
    {
        Person person = new Person();
        person.FirstName = FirstName;
        person.LastName = LastName;
        person.Manager = Manager;

        return person;
    }
}
```

https://msdn.microsoft.com/en-us/library/system.icloneable(v=vs.110).aspx
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTEzMzcyNzA0NTVdfQ==
-->