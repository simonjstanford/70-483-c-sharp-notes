#  FileInfo Classes

The File class is static and can be used instead of the FileInfo class if
there is only one operation that needs to be done.

  

To delete:

  

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

  

To move:

  

string path = @"c:\temp\test.txt";

string destPath = @"c:\temp\destTest.txt";

  

File.CreateText(path).Close();

File.Move(path, destPath);

  

FileInfo fileInfo = new FileInfo(path);

fileInfo.MoveTo(destPath);

  

To copy:

  

string path = @"c:\temp\test.txt";

string destPath = @"c:\temp\destTest.txt";

  

File.CreateText(path).Close();

File.Copy(path, destPath);

  

FileInfo fileInfo = new FileInfo(path);

fileInfo.CopyTo(destPath);

  

Use the Path.Combine to build a path to a file. This helps reduce errors with
backslashes:

  

string folder = @"C:\temp";

string fileName = "test.dat";

string fullPath = Path.Combine(folder, fileName); //results in
C:\temp\test.dat

  

Console.WriteLine(fullPath);

Console.ReadKey();

  

The Path class also has some other methods that help working with files:

  

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

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-11-16 12:10:54  
>Last Evernote Update Date: 2016-11-16 13:06:21  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  