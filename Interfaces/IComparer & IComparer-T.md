# IComparer & IComparer<T>

- This is used to define custom sorting of an object.
- The interface is implemented in a separate class that is passed as an argument into a sort method.  
- Also see [IComparable & IComparable<T>](../Interfaces/IComparable%20&%20IComparable-T.md).

https://msdn.microsoft.com/en-us/library/system.collections.icomparer(v=vs.110).aspx

Definition:

```csharp
namespace System.Collections.Generic
{   
    using System;
    // The generic IComparer interface implements a method that compares
    // two objects. It is used in conjunction with the Sort and
    // BinarySearch methods on the Array, List, and SortedList classes.
    public interface IComparer<in T>
    {
        // Compares two objects. An implementation of this method must return a
        // value less than zero if x is less than y, zero if x is equal to y, or a
        // value greater than zero if x is greater than y.
        int Compare(T x, T y);
    }
}
```

Example of usage:

```csharp
class Program
{
    static void Main(string[] args)
    {
        var cars = new List<Car>();
        cars.Add(new Car() { Year = 2014 });
        cars.Add(new Car() { Year = 2011 });
        cars.Add(new Car() { Year = 2004 });
        cars.Add(new Car() { Year = 1999 });
        cars.Add(new Car() { Year = 2015 });

        cars.Sort(new SortYearAscendingHelper());

        foreach (var car in cars)
        {
            Console.WriteLine(car.Year);
        }

        Console.Read();
    }
}

public class SortYearAscendingHelper : IComparer<Car>
{
    public int Compare(Car c1, Car c2)
    {
        if (c1.Year > c2.Year)
            return 1;
        else if (c1.Year < c2.Year)
            return -1;
        else
            return 0;
    }
}

public class Car
{
    public int Year { get; set; }
}
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbMjgyODU5NzcwLDE5OTExNTM4MV19
-->