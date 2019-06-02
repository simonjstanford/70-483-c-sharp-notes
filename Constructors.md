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

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-12-18 11:07:14  
>Last Evernote Update Date: 2017-01-11 19:21:09  
>source: mobile.iphone  