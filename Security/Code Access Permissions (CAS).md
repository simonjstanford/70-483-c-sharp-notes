# Code Access Permissions (CAS)

- .NET protects against malicious code using Code Access Security (CAS).
- This means that applications can be restricted on the types of resources they can access and operations they can execute.
- The CLR enforces CAS.
- Applications installed on a PC have full trust.
- When running in a sandboxed environment (Internet Explorer, SQL Server), the operations are restricted.
- CAS enables code to demand that callers have specific permissions, e.g. read/write.
- it also enables code to demand that callers have a digital signature.
- Enforced at runtime - every method in a call stack is checked so a less trusted method can't call a restricted method.
- The base class for CAS is `System.Security.CodeAccessPermission` and is derived into `FileIOPermission`, `ReflectionPermission` and `SecurityPermission`.
- CAS can be specified declaratively (through attributes) or imperatively (asking for permission in the code).


```csharp
[FileIOPermission(SecurityAction.Demand, AllLocalFiles =FileIOPermissionAccess.Read)]
public void DeclarativeCAS()
{
}
public void ImperativeCAS()
{
    FileIOPermission f = new FileIOPermission(PermissionState.None);
    f.AllLocalFiles = FileIOPermissionAccess.Read;
    try
    {
        f.Demand();
    }
    catch (SecurityException s)
    {
        Console.WriteLine(s.Message);
    }
}
```

https://msdn.microsoft.com/en-us/library/c5tk9z76(v=vs.110).aspx
<!--stackedit_data:
eyJoaXN0b3J5IjpbOTY0NDk1NDM2XX0=
-->