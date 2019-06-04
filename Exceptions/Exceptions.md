# Exceptions

Exceptions that come from other languages (e.g. C++) don't inherit from
System.Exception, but they are wrapped in a
System.Runtime.CompilerServices.RuntimeWrappedException object.

  

To stop a finally block from executing you can use Environment.FailFast()
inside the try section (not catch or finally), passing in either a string or
an exception. This info is written to the windows log and the application is
terminated.

  

If code in a finally block causes an exception then controls goes to the next
outer try block, if any, and the original exception is lost.

  

ExceptionDispatchInfo is used to capture exception data at a certain point:

  

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

  

  

Properties of an exception object:

  * HResult: a 32bit value that describes the severity of an error, where it is and a unique number for the error. Only used when going into native code.
  * TargetSite: the method that threw the error. Null if not available.

  

See
[Conversion](evernote:///view/26944639/s226/93387844-cf79-4867-8551-0c334ea3e2ae/93387844-cf79-4867-8551-0c334ea3e2ae/)
for info on using 'checked' to throw overflow exceptions.


---
### NOTE ATTRIBUTES
>Created Date: 2016-08-22 20:11:02  
>Last Evernote Update Date: 2017-01-13 18:17:44  
>author: simonjstanford@gmail.com  
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTg0MjY1OTg0Ml19
-->