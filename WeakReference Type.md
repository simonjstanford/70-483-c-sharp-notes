# WeakReference Type

An object is garbage collected when there are no more references to it. A
WeakReference is used to store a reference to an object but **still** allow it
to be garbage collected. One example of use might be that you want to keep a
list of objects that have been instantiated, but also want them to be
naturally garbage collected. A WeakReference can then be used to see if the
object has been garbage collected or not.  If an object is only referenced by
a weak reference then it will be garbage collected.

  

It has the following properties:

  * IsAlive: Indicates if the referenced object has been garbage collected.
  * Target: The object referenced in the weak reference. If this is not null you can prevent the object being garbage collected by assigning a reference to a normal variable using this property.

  

To construct a weak reference:

  

var sb = new StringBuilder("this is a test");

var weak = new WeakReference(sb);

Console.WriteLine (weak.Target); // This is a test

  

  

[https://msdn.microsoft.com/en-
us/library/system.weakreference%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396](https://msdn.microsoft.com/en-
us/library/system.weakreference%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396)


---
### NOTE ATTRIBUTES
>Created Date: 2016-10-04 11:11:19  
>Last Evernote Update Date: 2017-01-26 20:49:18  
>author: simonjstanford@gmail.com  