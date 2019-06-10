# Volatile

The `volatile` keyword is used with objects that are accessed by multiple threads. It stops compiler optimisation that can potentially change the order that code is executed as it assumes serial access. Use volatile to ensure that the most up to date version of a variable is returned in a multi threaded environment.

```csharp
private static volatile int flag = 0;
```

https://msdn.microsoft.com/en-us/library/x13ttww7.aspx

<!--stackedit_data:
eyJoaXN0b3J5IjpbNjY0MzUzOTU0LC0xNjk0MDQ4NTI5XX0=
-->