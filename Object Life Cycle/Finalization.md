# Finalization

  * Finalization is a mechanism to clean up unmanaged objects before garbage collection.
  * Used for unmanaged resources - database connections, files, etc.
  * Finalizers only execute when the garbage collector tries to clean up an object.
  * Finalizers increase the life of an object as it is put in a finalization queue and a thread executes it. This means that garbage collection can be delayed. You shouldn't rely on the garbage collector to clean up unmanaged resources due to the randomness of clean up - us [IDisposable](evernote:///view/26944639/s226/bf431065-7644-4659-87f0-18a34033843d/bf431065-7644-4659-87f0-18a34033843d/) instead. 
  * A distructor is defined in a class with a ~ and is converted into a finaliser.
  * Destructors can be defined in classes only, not structures. A class can have only one destructor.
  * Destructors cannot be inherited or overloaded.
  * Destructors cannot be called directly.
  * Destructors cannot have modifiers or parameters.

  

  

 public class Test

    {

        ~Test()

        {

            //this code is called when the finalize method executes

        }

    }

  

  

 **Calling Dispose From a Finalizer**

See the example below. The boolean overload is to ensure that only Dispose()
cleans up external objects. Finalization should never try to clean up external
objects because they will be in an unpredictable state - they might already be
finalized!

 **  
**

Also see
[IDisposable](evernote:///view/26944639/s226/bf431065-7644-4659-87f0-18a34033843d/bf431065-7644-4659-87f0-18a34033843d/)

 **  
**

class Test : IDisposable

{

    public void Dispose() // NOT virtual

    {

        Dispose(true);

        GC.SuppressFinalize(this); // Prevent finalizer from running.

    }

  

    ~Test()

    {

        Dispose(false);

    }

  

    protected virtual void Dispose(bool disposing)

    {

        if (disposing)

        {

            // Call Dispose() on other objects owned by this instance.

            // You can reference other finalizable objects here.

            // ...

        }

  

        // Release unmanaged resources owned by (just) this object.

        // ...

    }

}

 **  
**

  


---
### NOTE ATTRIBUTES
>Created Date: 2017-01-10 19:42:38  
>Last Evernote Update Date: 2017-01-17 20:11:37  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE5OTYxMTk2NF19
-->