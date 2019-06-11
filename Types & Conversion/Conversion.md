# Conversion

Implicit conversion - the compiler knows that conversion is safe, e.g. int to double or a derived class to its base class.

Explicit conversion - casting when conversion is not safe:

```csharp
double x = 1234.7;
int a = (int)x;
```

User defined conversion:

```csharp
class Program
{
    static void Main(string[] args)
    {
        Money money = new Money(42.42M);
        decimal amount = money;
        int trucatedAmount = (int)money;
    }
}

class Money
{
    public decimal Amount { get; set; }

    public Money(decimal amount)
    {
        Amount = amount;
    }

    public static implicit operator decimal (Money money)
    {
        return money.Amount;
    }

    public static explicit operator int(Money money)
    {
        return (int)money.Amount;
    }
}
```

.NET will not throw an exception when converting between types and data loss will incur. Use `checked` to throw an exception or set the 'Check for arithmetic overflow/underflow' option in the projects advanced build settings. Note that both of these methods only throw an exception for integer operations. When converting from a double to a float and an overflow occurs, the value is set to infinity. In this case, you would have to manually check that the value isn't infinity. 

```csharp
int y1 = int.MaxValue;
short x1 = (short)y1;

Console.WriteLine(x1);

checked
{
    int y2 = int.MaxValue;
    short x2 = (short)y2;

    Console.WriteLine(x2);
}

Console.Read();
 ```
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE3MDcxNjcxMDMsLTI3MDczNTYwOV19
-->