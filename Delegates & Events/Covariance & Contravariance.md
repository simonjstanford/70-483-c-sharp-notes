## Covariance

A method can have a return type that is more derived than that defined in the delegate. E.g. a delegate can have the return type `Textwriter`, so a method with a return type of `StreamWriter` or `StringWriter` could be used.


```csharp
class Program
{
    delegate Person CovarianceDelegate();

    static void Main(string[] args)
    {
        CovarianceDelegate example = ReturnEmployee;
    }

    private static Employee ReturnEmployee()
    {
        return new Employee();
    }
}

class Person { }

class Employee : Person { }
```

## Contravariance

A method can have a parameter type that is less derived than the delegate type. E.g. a delegate has a `StreamWriter` as a parameter. It points to a method that takes a `TextWriter` as a parameter. This works because `StreamWriter` is derived from `TextWriter` - you could pass in a `StreamWriter` parameter directly to the method, so you can also do the same when calling it via a delegate.

Also - a method can take parameters that are form a superclass of the type expected by a delegate. E.g, a delegate represents methods that take an `Employee` object as a parameter. You could set this delegate to a method that takes a `Person` as a parameter. When invoking the delegate you have to pass an `Employee` as this is what the delegate has defined, but this is OK because the method can use the `Employee` as a `Person`. You have to pass the method an `Employee` because that's what the delegate defines, but that's ok because an `Employee` is always a `Person` so the method will work.

```csharp
class Program
{
    delegate void ContravarianceDelegate(Employee employee);

    static void Main(string[] args)
    {
        ContravarianceDelegate example = PersonParameter;

        example(new Person()); //doesn't compile
        example(new Employee());
    }

    private static void PersonParameter(Person person)
    {

    }
}

class Person { }

class Employee : Person { }
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbNzI0NjY4NDM3XX0=
-->