# ThreadStatic Attribute

The [ThreadStatic] attribute ensures that each thread gets its own copy of a
field. However, this doesn't work with instance fields and field initializers
only execute once on the thread that's running when the static constructor
executes. If you want to work with instance fields or start with a non-default
value then
[ThreadLocal](evernote:///view/26944639/s226/75360b56-132f-4d9a-88f7-3fee0ab4e70b/75360b56-132f-4d9a-88f7-3fee0ab4e70b/)
is better.

  

//This attribute ensures that each thread gets its own copy of the field -
take it away and the count goes up to 20

[ThreadStatic]

public static int _field;

  

static void Main(string[] args)

{

    new Thread(() =>

    {

        for (int i = 0; i < 10; i++)

        {

            _field++;

            Console.WriteLine("Thread A: {0}", _field);

        }

    }).Start();

  

    new Thread(() =>

    {

        for (int i = 0; i < 10; i++)

        {

            _field++;

            Console.WriteLine("Thread B: {0}", _field);

        }

    }).Start();

  

    Console.ReadKey();

}


---
### NOTE ATTRIBUTES
>Created Date: 2016-11-18 12:53:13  
>Last Evernote Update Date: 2017-02-02 19:58:05  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTEwNjIxMzI3MzddfQ==
-->