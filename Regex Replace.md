# Regex Replace

  

string pattern = "(Mr\\\\.? |Mrs\\\\.? |Miss\\\\.? |Ms\\\\.? )";

string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels", "Abraham Adams", "Ms.
Nicole Norris" };

foreach (var name in names)

{

    Console.WriteLine(Regex.Replace(name, pattern, string.Empty));

}

Console.ReadKey();

  

<https://www.cheatography.com/davechild/cheat-sheets/regular-expressions/>

  

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-10-05 12:13:28  
>Last Evernote Update Date: 2016-11-07 22:16:35  
>author: simonjstanford@gmail.com  