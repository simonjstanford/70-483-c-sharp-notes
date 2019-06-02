# IDisposable

  * Dispose() is implemented to clean up unmanaged resources immediately.
  * Using a disposed object will cause an ObjectDisposedException.
  * See [Finalization](evernote:///view/26944639/s226/f538676c-53f6-4951-bc27-0afee40a485c/f538676c-53f6-4951-bc27-0afee40a485c/) for an example.

  

Definition:

  

public interface IDisposable

{

    void Dispose();

}

  

  

  

 **The Using Statement**

  * You can use a 'Using' statement to call dispose(). This is interpreted by the compiler as a try/catch with dispose() in the finally block.
  * If you want to implement the catch section of the try then you have to manually create the whole try/catch/finally statement with displose() in finally.

  

Using statements are interpreted as:

  

FileStream fs = new FileStream ("myFile.txt", FileMode.Open);

try

{

    // ... Write to the file ...

}

finally

{

    if (fs != null) ((IDisposable)fs).Dispose();

}

  

  

  

<https://msdn.microsoft.com/en-us/library/system.idisposable(v=vs.110).aspx>

  

<https://msdn.microsoft.com/en-us/library/b1yfkh5e(v=vs.110).aspx>


---
### NOTE ATTRIBUTES
>Created Date: 2016-10-03 21:05:26  
>Last Evernote Update Date: 2017-01-17 20:08:00  
>author: simonjstanford@gmail.com  
>source-url: https://referencesource.microsoft.com/mscorlib/system/idisposable.cs.html#1f55292c3174123d  