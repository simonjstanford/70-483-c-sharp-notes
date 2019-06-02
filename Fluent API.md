# Fluent API

Attributes can be used to control Entity Framework behaviour, but the fluent
API can be used to do the same and some more advanced functionality. The
fluent API is used by overriding the OnModelCreating method in DbContext. You
still use the Add-Migration and Update-Database commands to implement the
change.  

  

E.g. to change the mapping of a property to a column:

  

protected override void OnModelCreating(DbModelBuilder modelBuilder)

{

    modelBuilder.Entity<Customer>().Property(c => c.LastName).HasColumnName("Surname");

}

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-10-08 14:07:14  
>Last Evernote Update Date: 2016-11-07 22:18:30  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-url: https://msdn.microsoft.com/en-gb/data/jj193542  
>source-application: evernote.win32  