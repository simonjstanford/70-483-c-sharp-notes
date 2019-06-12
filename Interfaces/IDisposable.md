# IDisposable

- Dispose() is implemented to clean up unmanaged resources immediately.
- Using a disposed object will cause an ObjectDisposedException.
- See [Finalization](../Object%20Life%20Cycle/Finalization.md) for an example.

Definition:

```csharp
public interface IDisposable
{
    void Dispose();
}
```


## The Using Statement
- You can use a 'Using' statement to call dispose(). This is interpreted by the compiler as a try/catch with dispose() in the finally block.
- If you want to implement the catch section of the try then you have to manually create the whole try/catch/finally statement with displose() in finally.


Using statements are interpreted as:

```csharp
FileStream fs = new FileStream ("myFile.txt", FileMode.Open);
try
{
    // ... Write to the file ...
}
finally
{
    if (fs != null) ((IDisposable)fs).Dispose();
}
```

https://msdn.microsoft.com/en-us/library/system.idisposable(v=vs.110).aspx
https://msdn.microsoft.com/en-us/library/b1yfkh5e(v=vs.110).aspx
<!--stackedit_data:
eyJoaXN0b3J5IjpbNDgzOTEyMDQwLDE0MTkzNTgyMDVdfQ==
-->