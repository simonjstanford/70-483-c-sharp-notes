# Database Connections

**Code First**

 **  
**

By default and without any configuration, calling the parameterless
constructor on DbContext will cause DbContext to use either SQL Express (if
exists) else a LocalDb. A database will be created for your application that
is called the fully qualified name of the DbContext derived class that you 've
created. You can change the database name by passing the name into the
DbContext base constructor:

  

public class ShopContext : DbContext

{

    public ShopContext() : base("Shop")

    {

    }

}

  

To change the database that the Entity Framework uses you add to the
connection string to the app.config or web.config file:

  

<connectionStrings>

  <add name="CustomerDatabase"

        providerName="System.Data.SqlClient"

        connectionString="data source=SIMON-SERVER\SQLEXPRESS;initial catalog=Customers;persist security info=True;user id=Test;password=guuWRwSnrSdMkiDUs9jl;MultipleActiveResultSets=True;App=EntityFramework" />

</connectionStrings>

  

Then pass the connection string name into the DbContext base constructor:

  

public class ShopContext : DbContext

{

    public ShopContext()

        : base("name=CustomerDatabase")

    {

    }

}

  

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-10-08 14:36:32  
>Last Evernote Update Date: 2016-11-07 22:18:26  
>author: simonjstanford@gmail.com  
>source-url: https://msdn.microsoft.com/en-us/data/jj592674  
<!--stackedit_data:
eyJoaXN0b3J5IjpbNTcxMTM2NzEzXX0=
-->