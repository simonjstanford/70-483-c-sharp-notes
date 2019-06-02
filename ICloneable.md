# ICloneable

Clones an object.  

  

Definition:

  

public interface ICloneable

{

    Object Clone();

}

  

Example of usage:

  

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

  

<https://msdn.microsoft.com/en-us/library/system.icloneable(v=vs.110).aspx>[  
](https://msdn.microsoft.com/en-us/library/system.icloneable\(v=vs.110\).aspx)  


---
### NOTE ATTRIBUTES
>Created Date: 2016-12-18 12:03:33  
>Last Evernote Update Date: 2017-01-14 13:42:14  
>source: mobile.iphone  