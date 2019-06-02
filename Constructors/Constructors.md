# Constructors

Use : this() in the same way as : base() to execute one constructor from
another:  

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

<!--stackedit_data:
eyJoaXN0b3J5IjpbMTQ1OTU5MjIwNF19
-->