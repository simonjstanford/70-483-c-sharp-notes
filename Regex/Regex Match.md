# Regex Match

  

Regex regex = new Regex(@"\d+");

Match match = regex.Match("Dot 55 Perls");

if (match.Success)

{

    Console.WriteLine(match.Value);

}

Console.ReadKey();

  

<https://www.dotnetperls.com/regex>

<https://www.cheatography.com/davechild/cheat-sheets/regular-expressions/>


---
### NOTE ATTRIBUTES
>Created Date: 2016-10-05 12:14:50  
>Last Evernote Update Date: 2016-11-07 22:16:31  
>author: simonjstanford@gmail.com  
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTExMzkzNDcxMV19
-->