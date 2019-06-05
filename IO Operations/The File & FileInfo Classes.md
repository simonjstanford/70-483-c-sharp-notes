# The File & FileInfo Classes

The `File` class is static and can be used instead of the `FileInfo` class if there is only one operation that needs to be done.

To delete:

```csharp
string path = @"c:\temp\test.txt";
if (File.Exists(path))
{
    File.Delete(path);
}

FileInfo fileInfo = new FileInfo(path);
if (fileInfo.Exists)
{
    fileInfo.Delete();
}
```

To move:

```csharp
string path = @"c:\temp\test.txt";
string destPath = @"c:\temp\destTest.txt";

File.CreateText(path).Close();
File.Move(path, destPath);

FileInfo fileInfo = new FileInfo(path);
fileInfo.MoveTo(destPath);
```

To copy:

```csharp
string path = @"c:\temp\test.txt";
string destPath = @"c:\temp\destTest.txt";

File.CreateText(path).Close();
File.Copy(path, destPath);

FileInfo fileInfo = new FileInfo(path);
fileInfo.CopyTo(destPath);
```

Use the `Path.Combine` to build a path to a file. This helps reduce errors with backslashes:

```csharp
string folder = @"C:\temp";
string fileName = "test.dat";
string fullPath = Path.Combine(folder, fileName); //results in C:\temp\test.dat

Console.WriteLine(fullPath);
Console.ReadKey();
```

The `Path` class also has some other methods that help working with files:

```csharp
string folder = @"C:\temp";
string fileName = Path.GetRandomFileName();
string fullPath = Path.Combine(folder, fileName);
File.CreateText(fullPath);

Console.WriteLine(Path.GetDirectoryName(fullPath));
Console.WriteLine(Path.GetExtension(fullPath));
Console.WriteLine(Path.GetFileName(fullPath));
Console.WriteLine(Path.GetPathRoot(fullPath));
Console.WriteLine(Path.GetTempPath());
Console.WriteLine(Path.GetTempFileName()); //creates a temporary file

Console.WriteLine(fullPath);

Console.ReadKey();
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTEzNjI2NjU0NzldfQ==
-->