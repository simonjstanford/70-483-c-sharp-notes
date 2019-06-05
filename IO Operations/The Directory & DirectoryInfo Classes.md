# The Directory & DirectoryInfo Classes

Both the `Directory` and `DirectoryInfo` classes offer access to the folder structure. The `Directory` class is static and should be used when only a single operation is needed, otherwise it is more efficient to use `DirectoryInfo`.

You can use both classes to create a folder. When this is done, you get given read and write rights to the folder. An `UnauthorizedAccessException` error will be thrown if you try and create a new directory in a location where you don't have sufficient permission.

```csharp
var directory1 = Directory.CreateDirectory(@"C:\Temp\Test1");

var directory2 = new DirectoryInfo(@"C:\Temp\Test2");
directory2.Create();
```

You can use `Directory`/`DirectoryInfo` to remove directories. If it does not exist then a `DirectoryNotFoundException` is thrown.

```csharp
if (Directory.Exists(@"C:\Temp\Test1"))
{
    Directory.Delete(@"C:\Temp\Test1");
}

var directoryInfo = new DirectoryInfo(@"C:\Temp\Test2");
if (directoryInfo.Exists)
{
    directoryInfo.Delete();
}
```

Use the `DirectorySecurity` class to change the access control of a directory. Note that the application must have the rights to make this modification.

```csharp
var directory2 = new DirectoryInfo(@"C:\Temp\Test2");
directory2.Create();

DirectorySecurity security = directory2.GetAccessControl();
security.AddAccessRule(new FileSystemAccessRule("everyone",
                                                FileSystemRights.ReadAndExecute,
                                                AccessControlType.Allow));
directory2.SetAccessControl(security);
```

Use `GetDirectories()` to search a directory for directories. There are overloads to add a `SearchOption`, e.g. `AllDirectories`.

```csharp
static void Main(string[] args)
{
    //List the subdirectories for Program Files containing the character 'a' with a maximum depth of 5
    DirectoryInfo directory = new DirectoryInfo(@"C:\Windows");
    ListDirectories(directory, "a*", 5, 0);

    Console.ReadKey();
}

private static void ListDirectories(DirectoryInfo directory, string searchPattern, int maxLevel, int currentLevel)
{
    if (currentLevel >= maxLevel)
    {
        return;
    }

    string indent = new string('-', currentLevel);

    try
    {
        DirectoryInfo[] subDirectories = directory.GetDirectories(searchPattern);

        foreach (var subDirectory in subDirectories)
        {
            Console.WriteLine(indent + subDirectory.Name);
            ListDirectories(subDirectory, searchPattern, maxLevel, currentLevel + 1);
        }
    }
    catch (UnauthorizedAccessException)
    {
        //no access to this directory
        Console.WriteLine(indent + "Can't access: " + directory.Name);
        return;
    }
    catch(DirectoryNotFoundException)
    {
        Console.WriteLine(indent + "Can't find: " + directory.Name);
    }
}
```

The search pattern in `GetDirectories()` can have wildcards:


| Wildcard | Description             | Example             |
|----------|-------------------------|---------------------|
| *        | Zero or more characters | *m* matches me, mmm |
| ?        | Exactly one character   | ?edia matches Media |


You can use `EnumerateDirectories` instead of `GetDirectories` if you want to start enumerating the directory collection before the search has completed. This is helpful when searching a large directory structure.

`Directory.Move()` and `DirectoryInfo.MoveTo()` are used to move the directory to another location.

`Directory.GetFiles()` returns an array of strings and `DirectoryInfo.GetFiles()` returns an array of `FileInfo` objects, but both are used to get a list of the files within a directory.

```csharp
foreach (var file in Directory.GetFiles(@"C:\Windows"))
{
    Console.WriteLine(file);
}

DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Windows");
foreach (var file in directoryInfo.GetFiles())
{
    Console.WriteLine(file.FullName);
}
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE5OTE3MDQ2NTddfQ==
-->