# Extension methods

Extension methods need to be declared in a nongeneric, non-nested, static
class and uses the keyword 'this'.

  

public class Product

{

     public decimal Price { get; set; }

}

  

public static class MyExtensions

{

     public static decimal Discount(this Product product)

     {

          return product.Price * 0.9M;

     }

}

  

public class Calculator

{

     public decimal CalculateDiscount(Product p)

     {

          return p.Discount();

     }

}

  

It can also be declared on an interface. In this way you can provide methods
for an interface that will be available on all concrete implementations of the
interface.


---
### NOTE ATTRIBUTES
>Created Date: 2016-08-25 18:21:10  
>Last Evernote Update Date: 2016-11-07 22:13:26  
>author: simonjstanford@gmail.com  