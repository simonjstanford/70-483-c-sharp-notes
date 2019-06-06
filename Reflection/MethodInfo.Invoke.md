# MethodInfo.Invoke()


Execute a method on a type:

```csharp
int i = 42;

MethodInfo method = i.GetType().GetMethod("CompareTo", new Type[] { typeof(int) });
int result = (int)method.Invoke(i, new object[] {41});

Console.WriteLine(result);
Console.ReadKey();
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbOTAyMDkwMzg4XX0=
-->