# Throwing/Rethrowing Exceptions

Use 'throw' without any other text to rethrow an exception and keep the stack
trace. You can also use ExceptionDispatchInfo.Throw(). This preserves the
original stack trace and also adds the trace to where throw() was called. This
can be used when an exception is caught in one thread and thrown in another.

  

try

{

  

}

catch (Exception)

{

    throw;

}

  

Or you can throw the exception but reset the stack trace. This can be useful
if you don't want to expose the callstack, e.g. private methods:

  

try

{

  

}

catch (Exception ex)

{

    throw ex;

}

  

You may want to catch an exception, wrap it in a new Exception object to
provide more detail and then re-throw it. In this case you need to make sure
that the original exception is in the new exception's InnerException property.

  

  

try

{

  

}

catch (Exception ex)

{

    var wrapper = new NotSupportedException("This is a wrapper exception", ex);

    throw wrapper;

}

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-12-23 11:22:17  
>Last Evernote Update Date: 2016-12-23 11:27:34  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  