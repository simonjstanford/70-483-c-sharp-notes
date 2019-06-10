# Database Connections

By default and without any configuration, calling the parameterless constructor on `DbContext` will cause `DbContext` to use either SQL Express (if exists) else a LocalDb. A database will be created for your application that is called the fully qualified name of the `DbContext` derived class that you've created. You can change the database name by passing the name into the `DbContext` base constructor:


```csharp
public class ShopContext : DbContext
{
    public ShopContext() : base("Shop")
    {
    }
}
```

To change the database that the Entity Framework uses you add to the connection string to the app.config or web.config file:

```xml
<connectionStrings>
  <add name="CustomerDatabase"
       providerName="System.Data.SqlClient"
       connectionString="data source=SIMON-SERVER\SQLEXPRESS;initial catalog=Customers;persist security info=True;user id=Test;password=guuWRwSnrSdMkiDUs9jl;MultipleActiveResultSets=True;App=EntityFramework" />
</connectionStrings>
```

Then pass the connection string name into the `DbContext` base constructor:

```csharp
public class ShopContext : DbContext
{
    public ShopContext()
        : base("name=CustomerDatabase")
    {
    }
}
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbNjIzOTY3ODg3XX0=
-->