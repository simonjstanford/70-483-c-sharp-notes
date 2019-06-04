# P/invoke


You can use P/invoke to execute unmanaged resources. It relies on using the DllImport attribute (which is part of System.Runtime.InteropServices) to decorate a method. The DllImport attribute is used to define the DLL to be used, the character code set to use and how errors should be handled. The method that is used to execute the external code should have a static extern declaration.

In the example below, lpszLongPath is the string to get a short path name for, lpszShortPath is the character array to store the short path name and cchBuffer is the total length of the character array. The method returns a uint that specifies the length of the short path that is stored in the array.

```csharp
static void Main(string[] args)
{
    string longName = @"C:\temp\uncompressed.data";

    char[] buffer = new char[10240];
    long length = GetShortPathName(longName, buffer, buffer.Length);

    string shortName = new string(buffer);
    Console.WriteLine(shortName.Substring(0, (int)length));
    Console.Read();
}

[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
static extern uint GetShortPathName(string lpszLongPath, char[] lpszShortPath, int cchBuffer);
```

You can use MarshalAs if you need to control the data type that is sent to the unmanaged DLL: 

```csharp
[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
static extern uint GetShortPathName([MarshalAs(UnmanagedType.LPStr)]string lpszLongPath,
                                    [MarshalAs(UnmanagedType.LPArray)]char[] lpszShortPath,
                                    int cchBuffer);
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTYzODk4MzM5Ml19
-->