# IComparable & IComparable<T>

- Compares objects to allow sorting.
- Also see IComparer & IComparer.
- Implementing this interface doesn't mean that > and < should be overloaded - this should only be done if there is a strong concept of greater/less than in the objects. Sorting objects is different from greater/less than!


Definitions:

```csharp
public interface IComparable
{
    // Interface does not need to be marked with the serializable attribute
    // Compares this object to another object, returning an integer that
    // indicates the relationship. An implementation of this method must return
    // a value less than zero if this is less than object, zero
    // if this is equal to object, or a value greater than zero
    // if this is greater than object.
    //
    int CompareTo(Object obj);
}

// Generic version of IComparable.

public interface IComparable<in T>
{
    // Interface does not need to be marked with the serializable attribute
    // Compares this object to another object, returning an integer that
    // indicates the relationship. An implementation of this method must return
    // a value less than zero if this is less than object, zero
    // if this is equal to object, or a value greater than zero
    // if this is greater than object.
    //
    int CompareTo(T other);
}


Generic Usage:


using System;
using System.Collections.Generic;

namespace IComparableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new List<Order>()
            {
                new Order { Created = new DateTime(2012, 12, 1)},
                new Order { Created = new DateTime(2012, 1, 6)},
                new Order { Created = new DateTime(2012, 7, 8)},
                new Order { Created = new DateTime(2012, 2, 20)},
            };

            orders.Sort();
        }
    }

    class Order : IComparable<Order>
    {
        public DateTime Created { get; set; }

        public int CompareTo(Order other)
        {
            return Created.CompareTo(other.Created);
        }
    }
}

Non-Generic Usage:


using System;
using System.Collections.Generic;

namespace IComparableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new List<Order>()
            {
                new Order { Created = new DateTime(2012, 12, 1)},
                new Order { Created = new DateTime(2012, 1, 6)},
                new Order { Created = new DateTime(2012, 7, 8)},
                new Order { Created = new DateTime(2012, 2, 20)},
            };

            orders.Sort();
        }
    }

    class Order : IComparable
    {
        public DateTime Created { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            Order o = obj as Order;

            if (o == null)
            {
                throw new ArgumentException("Object is not an Order");
            }

            return Created.CompareTo(o.Created);
        }
    }
}
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTc5NDEwNTQ0XX0=
-->