# Migrations

Migrations is used to change the database schema.

  

To enable Migrations, enter command 'Enable-Migrations' in the package manager
console. This creates:

  * Configuration.cs: this is where you can specify seed data, register providers for other databases, change namespaces, etc.
  * <timestamp>_InitialCreate.cs: the code that was originally executed to create the tables that are in the database.

To update the database model you first need to make the change in the C#
object, e.g. add a new property.  Then execute 'Add-Migration <name>' in the
package manage console to update the schema. This creates a new class in the
migrations folder that details the change. The code can be changed if need be.
Finally call 'Update-Database' to implement the change in the database. You
can use the -Verbose switch to see the SQL being executed.

  

![noteattachment1][5248c64a30f14151f2e1872e5f6dc2fb]  

  

  


---
### ATTACHMENTS
[5248c64a30f14151f2e1872e5f6dc2fb]: media/EntityFrameworkExample.zip
[EntityFrameworkExample.zip](media/EntityFrameworkExample.zip)
>hash: 5248c64a30f14151f2e1872e5f6dc2fb  
>source-url: file://C:\Users\Simon\Dropbox\Coding\70-483\EntityFrameworkExample.zip  
>file-name: EntityFrameworkExample.zip  
>attachment: true  

---
### NOTE ATTRIBUTES
>Created Date: 2016-10-08 12:22:55  
>Last Evernote Update Date: 2016-10-08 13:59:47  
>author: simonjstanford@gmail.com  
>source-url: https://msdn.microsoft.com/en-gb/data/jj193542  