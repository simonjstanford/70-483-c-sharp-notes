# IEquatable

  * Used to determine if one object equals another object.  

  * Enables use List.Contains(), IndexOf(), LastIndexOf() and Remove()
  * You also need to override Object.Equals() for performance and GetHashCode() to ensure that the object works in a hash table.

  

Defintion:

  

namespace System

{

    public interface IEquatable<T>  
    {  
        bool Equals(T other);

    }

}  
  

  

  

[](https://msdn.microsoft.com/en-
us/library/ms131187\(v=vs.110\).aspx)<https://msdn.microsoft.com/en-
us/library/ms131187(v=vs.110).aspx>

[  
](https://msdn.microsoft.com/en-us/library/ms131187\(v=vs.110\).aspx)


---
### NOTE ATTRIBUTES
>Created Date: 2016-12-18 11:47:58  
>Last Evernote Update Date: 2017-01-14 14:04:53  
>source: mobile.iphone  
>source-url: https://referencesource.microsoft.com/mscorlib/system/iequatable.cs.html#91a17479daaada86  