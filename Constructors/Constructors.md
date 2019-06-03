# Constructors

Use : `this()` in the same way as : `base()` to execute one constructor from another:  

```csharp
public class Wine
{
	public decimal Price;
	public int Year;

	public Wine (decimal price)
	{
		Price = price;
	}

	public Wine (decimal price, int year) : this (price)
	{
		Year = year;
	}
}
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTY4MzUyODg5LC00NzE2Njg3MjBdfQ==
-->