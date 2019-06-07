# Regex Replace

```csharp  
string pattern = "(Mr\\.? |Mrs\\.? |Miss\\.? |Ms\\.? )";string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels", "Abraham Adams", "Ms. Nicole Norris" };foreach (var name in names){    Console.WriteLine(Regex.Replace(name, pattern, string.Empty));}Console.ReadKey();
```

https://www.cheatography.com/davechild/cheat-sheets/regular-expressions/


<!--stackedit_data:
eyJoaXN0b3J5IjpbLTEwMTMwOTg2MDJdfQ==
-->