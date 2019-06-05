# DriveInfo

```csharp
DriveInfo[] drives = DriveInfo.GetDrives();

foreach (var drive in drives)
{
    Console.WriteLine("Drive {0}", drive.Name);
    Console.WriteLine("    File type: {0}", drive.DriveType);

    if (drive.IsReady)
    {
        Console.WriteLine("    Volume label: {0}", drive.VolumeLabel);
        Console.WriteLine("    File system: {0}", drive.DriveFormat);
        Console.WriteLine("    Available space to current user: {0, 15} bytes", drive.AvailableFreeSpace);
        Console.WriteLine("    Total available space:           {0, 15} bytes", drive.TotalFreeSpace);
        Console.WriteLine("    Total size of drive:             {0, 15} bytes", drive.TotalSize);
    }
}

Console.ReadKey();
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbMzE1NzA1MTEzLDU4MzE3NTExMF19
-->