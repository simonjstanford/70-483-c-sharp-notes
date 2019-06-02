# Anonymous Types

This is a type that is created at compile time without a formal class
definition. This uses [Object Initialisation
Syntax](evernote:///view/26944639/s226/3b6762bd-
df50-4f80-b016-4683016546db/3b6762bd-df50-4f80-b016-4683016546db/) and
[Implicitly Typed
Variables](evernote:///view/26944639/s226/59688576-af29-4044-9d34-08b58fdba406/59688576-af29-4044-9d34-08b58fdba406/).
Anonymous types are used in LINQ when creating a 'projection' \- selecting
properties from a query and creating a type from it.

  

An anonymous type is created like this:

  

var person = new

{

     FirstName = "Simon",

     LastName = "Stanford"

};


---
### NOTE ATTRIBUTES
>Created Date: 2016-11-30 20:35:20  
>Last Evernote Update Date: 2017-01-17 19:33:57  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  