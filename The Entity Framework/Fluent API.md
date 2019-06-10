# Fluent API

Attributes can be used to control Entity Framework behaviour, but the fluent API can be used to do the same and some more advanced functionality. The fluent API is used by overriding the `OnModelCreating` method in `DbContext`. You still use the Add-Migration and Update-Database commands to implement the change.

E.g. to change the mapping of a property to a column:

```csharp
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Entity<Customer>().Property(c => c.LastName).HasColumnName("Surname");
}
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE3NzM5MTIyOTFdfQ==
-->