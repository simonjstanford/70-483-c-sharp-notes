# IEnumerable, IEnumerator, IEnumerable<T> & IEnumerator<T>


Definition of IEnumerable:

```csharp
public interface IEnumerable
{
    IEnumerator GetEnumerator();
}
```

Definition of IEnumerator:

```csharp
public interface IEnumerator
{
    bool MoveNext();
    Object Current { get; }
    void Reset();
}
```
 
- IEnumerator Defines the way elements in a collection are enumerated through. It contains:
	- Current: the current object in this enumeration.
	- MoveNext(). Returns false if there are no more elements in the collection. Must be called before retrieving the first item (thus allowing for empty collections)
- Reset()
	* 
IEnumerable only has one method - GetEnumerator. This is used to retrieve an object that implements IEnumerator. IEnumerable can be seen as an IEnumerator provider and is the base interface that collection classes provide.
	* 
The abstraction of iteration allows for multiple consumers to read a collection at the same time without interference.
	* 
The generic versions avoid the overhead of boxing value types and strengthen type safety. When implementing the generic versions, the non-generic versions are normally explicitly implemented to hide them from the user.



An example of use:


string s = "Hello";
// Because string implements IEnumerable, we can call GetEnumerator():

IEnumerator rator = s.GetEnumerator();
while (rator.MoveNext())
{
    char c = (char) rator.Current;
    Console.Write (c + ".");
}

https://msdn.microsoft.com/en-us/library/system.collections.ienumerable(v=vs.110).aspx

Yield
Implementing both of these interfaces can be a lot of work. If you just want to iterate over an internal collection you can use yield instead:


using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumerableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] data = new Person[3];
            data[0] = new Person("Mitch", "Burns");
            data[1] = new Person("Kirsty", "Smith");
            data[2] = new Person("Simon", "Stanford");

            People people = new People(data);

            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }

            Console.ReadKey();
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }

    class People : IEnumerable<Person>
    {
        Person[] people;

        public People(Person[] people)
        {
            this.people = people;
        }

        public IEnumerator<Person> GetEnumerator()
        {
            for (int index = 0; index < people.Length; index++)
            {
                yield return people[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

<!--stackedit_data:
eyJoaXN0b3J5IjpbMTkxMDIwMTk0Nl19
-->