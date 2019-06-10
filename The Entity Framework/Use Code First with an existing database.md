# Use Code First with an existing database

You can use the Entity Framework to connect to an existing database and generate classes for all database entities. The `DbContext` class is also derived, so you can immediately start using the database. This is done by adding a new 'ADO.NET Entity Data Model' item to a project and completing the wizard.

The classes that are created from the wizard can then be modified as appropriate. If the database changes you can either manually edit the entity classes or perform another reverse engineer to overwrite the classes.

A method is created for each stored procedure in an existing database. 

https://msdn.microsoft.com/en-us/data/jj200620

[Entity Framework Example](../media/EntityFrameworkCodeFirstExistingDatabase.zip)
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTQyMTA2Mzc1OSwtNjk0NDk1NzkyXX0=
-->