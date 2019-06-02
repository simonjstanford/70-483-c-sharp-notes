# Create Attributes

  * Defining constructor parameters is optional, but if done must be: 
    * A primitive value type
    * The 'Type' type
    * An enum
    * A one-dimensional array of any of the above
  * All properties must be statically evaluate-able.

  

 **The AttributeUsage Attribute**

Has several properties:

  * AllowMultiple
  * Inherited - determines if 
    * Classes: an attribute applied to a base class should also be applied to an inherited class.
    * Methods: an attribute applied to a virtual method applies to overriding methods
  * ValidOn - what targets the attribute is designed for. Accepts values from the AttributeTargets enum 
    * <https://msdn.microsoft.com/en-us/library/system.attributetargets(v=vs.110).aspx>

  

  

   [MyAttribute("test1!")]

    class Program

    {

        [MyAttribute("test2!")]

        static void Main(string[] args)

        {

        }

    }

  

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple=true)]

    public class MyAttribute : Attribute

    {

        public string Description { get; set; } //must be read/write

  

        public MyAttribute(string description)

        {

            Description = description;

        }

    }

  

![noteattachment1][e4b5c673138eb3dbd1cc4d0bbe8e764f]

  


---
### ATTACHMENTS
[e4b5c673138eb3dbd1cc4d0bbe8e764f]: media/AttributesExample-2.zip
[AttributesExample-2.zip](media/AttributesExample-2.zip)
>hash: e4b5c673138eb3dbd1cc4d0bbe8e764f  
>source-url: file://C:\Users\Simon\Desktop\AttributesExample.zip  
>file-name: AttributesExample.zip  
>attachment: true  

---
### NOTE ATTRIBUTES
>Created Date: 2016-10-03 21:09:49  
>Last Evernote Update Date: 2017-01-10 20:06:18  
>author: simonjstanford@gmail.com  