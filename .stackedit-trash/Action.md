#  Action

Use Func<T> when you don't want to define a delegate. It can take 0-16
parameters and a return type. You can use Lambda expressions or pass a method:

  

Func<int, int, int> calc = (x, y) => x + y;

calc += (x, y) => x * y;

  

Console.WriteLine(calc(3, 4));

  

Use Action<T> when you don't want to define a delegate and there is no return
type. It can take 0-16 parameters. You can use Lambda expressions or pass a
method.

  

Console.WriteLine("Action<T> Example");

  

Action<int, int> calc = (x, y) => Console.WriteLine(x + y);

calc(3, 4);

  

Console.WriteLine();

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-12-20 13:26:52  
>Last Evernote Update Date: 2016-12-21 12:44:52  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE0NDM5MDg5MjFdfQ==
-->