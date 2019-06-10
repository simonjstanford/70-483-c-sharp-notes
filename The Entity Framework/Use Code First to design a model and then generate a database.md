# Use Code First to design a model and then generate a database

Entity Framework is installed via NuGet.

You can use The Entity Framework to design a database model and then save/load data to it.  The data is stored in a SQL Express database if installed, else LocalDb which is installed as part of Visual Studio.  The database is named after the fully qualified name of the class that inherits from the `DbContext` class.

There are several attributes you can use:
- `KeyAttribute`: specifies the primary key. The int property 'Id' is assumed to be a primary key.
- `StringLengthAttribute` : the min/max character length of the field
- `MaxLengthAttribute` : sets the max length of an array or string of the field
- `ConcurrencyCheckAttribute` : specifies a property as to be included in a WHERE clause. Used to improve performance in large tables when there are multiple calls - http://stackoverflow.com/questions/23857104/why-we-use-concurrency-check-attribute-in-entity-framework. 
- RequiredAttribute : a data field is required.
- TimestampAttribute : specifies the datatype of the column as a row version.
- ComplexTypeAttribute : denotes a property that has properties of its own but no primary key.
- ColumnAttribute : the database column a property is mapped to.
- TableAttribute : the table that a class is mapped to.
- InversePropertyAttribute: http://jaliyaudagedara.blogspot.co.uk/2015/04/use-of-inversepropertyattribute-in.html
- ForeignKeyAttribute: denotes a foreign key.
- DatabaseGeneratedAttribute: determines how the database generates values for a property.
- NotMappedAttribute: a property should be excluded from the database.


<!--stackedit_data:
eyJoaXN0b3J5IjpbMTgzODQ3OTU5NF19
-->