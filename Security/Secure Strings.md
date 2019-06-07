# Secure Strings

- Strings can be moved around by the garbage collector, leaving multiple copies.
- Strings aren't encrypted, so could be written as plain text on a page file or in a memory dump.
- strings are immutable - changing leaves extra copies in memory.
- `System.Secuirty.SecureString` helps protect against this:
	- It automatically encrypts the value.
	- There is only a reference to a single memory location.
	- Garbage collector doesn't move it.
	- Mutable.
	- Implements `IDisposable` so it can be removed from memory.
	- For security, only one character at a time is added to a `SecureString`.

Usage:


```csharp
//the using ensures that the SecureString is disposed
using (SecureString securePwd = new SecureString())
{
    ConsoleKeyInfo key;
    Console.Write("Enter password: ");
    do
    {
        key = Console.ReadKey();
        if (key.Key != ConsoleKey.Enter)
        {
            //ignore out of range keys
            //if (((int)key.Key) >= 65 && ((int)key.Key) <= 90)
            //{
            securePwd.AppendChar(key.KeyChar);
            //Console.Write(key.KeyChar);
            //}
        }
    } while (key.Key != ConsoleKey.Enter);
    //makes any further attempt to modify the secure string throw an InvalidOperationException.
    securePwd.MakeReadOnly();
    Console.WriteLine();
    try
    {
        //Process.Start("Notepad.exe", "sstanford", securePwd, "LOCALDOM");
        var proc = new System.Diagnostics.Process();
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.FileName = "Notepad.exe";
        proc.StartInfo.Domain = "Simon-Laptop";
        proc.StartInfo.UserName = "simonjstanford@gmail.com";
        proc.StartInfo.Password = securePwd;
        proc.Start();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    Console.ReadKey();
}
```

You can convert a `SecureString` back to a normal string using the `Marshall` class to retrieve the data directly from memory:


```csharp
public static void ConvertToUnsecureString(SecureString securePassword)
{
    //the IntPtr is a pointer to a memory address
    IntPtr unmanagedString = IntPtr.Zero;
    try
    {
        unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
        Console.WriteLine(Marshal.PtrToStringUni(unmanagedString));
    }
    finally
    {
        //make sure that the string is removed from memory
        Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
    }
}
```

The `Marshall` class has several methods that can be used to decrypt `SecureString`. They each have an associated method for clearing the `SecureString` from memory:


| Decrypt Method                   | Clear Memory Method        |
|----------------------------------|----------------------------|
| SecureStringToBSTR               | ZeroFreeBSTR               |
| SecureStringToCoTaskMemAnsi      | ZeroFreeCoTaskMemAnsi      |
| SecureStringToCoTaskMemUnicode   | ZeroFreeCoTaskmemUnicode   |
| SecureStringToGlovalAllocAnsi    | ZeroFreeGlobalAllocAnsi    |
| SecureStringToGlobalAllocUnicode | ZeroFreeGlobalAllocUnicode |

<!--stackedit_data:
eyJoaXN0b3J5IjpbLTQwMDY1NTc4OSwtMTE3MDYyNzUwNV19
-->