# MethodInfo.Invoke()

Execute a method on a type:

  

int i = 42;

  

MethodInfo method = i.GetType().GetMethod("CompareTo", new Type[] {
typeof(int) });

int result = (int)method.Invoke(i, new object[] {41});

  

Console.WriteLine(result);

Console.ReadKey();

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-10-03 21:07:58  
>Last Evernote Update Date: 2016-11-07 22:16:07  
>author: simonjstanford@gmail.com  