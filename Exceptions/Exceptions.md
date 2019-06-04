# Exceptions
Exceptions that come from other languages (e.g. C++) don't inherit from System.Exception, but they are wrapped in a System.Runtime.CompilerServices.RuntimeWrappedException object.

To stop a finally block from executing you can use Environment.FailFast() inside the try section (not catch or finally), passing in either a string or an exception. This info is written to the windows log and the application is terminated.

If code in a finally block causes an exception then controls goes to the next outer try block, if any, and the original exception is lost.

ExceptionDispatchInfo is used to capture exception data at a certain point:

```csharp
static void Main(string[] args)
{
    DispatchInfoThrowExample();
}

public static void DispatchInfoThrowExample()
{
    ExceptionDispatchInfo exception = null;

    try
    {
        string s = Console.ReadLine();
        int.Parse(s);
    }
    catch (FormatException ex)
    {
        exception = ExceptionDispatchInfo.Capture(ex);
    }

    if (exception != null)
    {
        exception.Throw();
    }
}
```

Properties of an exception object:

- HResult: a 32bit value that describes the severity of an error, where it is and a unique number for the error. Only used when going into native code.
- TargetSite: the method that threw the error. Null if not available.


See Conversion for info on using 'checked' to throw overflow exceptions.
<!--stackedit_data:
eyJoaXN0b3J5IjpbODQ2ODEzMDUzXX0=
-->