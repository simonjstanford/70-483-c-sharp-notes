# Create Attributes

  * Defining constructor parameters is optional, but if done must be: 
    * A primitive value type
    * The 'Type' type
    * An enum
    * A one-dimensional array of any of the above
  * All properties must be statically evaluate-able. 

## The AttributeUsage Attribute

Has several properties:

  * AllowMultiple
  * Inherited - determines if 
    * Classes: an attribute applied to a base class should also be applied to an inherited class.
    * Methods: an attribute applied to a virtual method applies to overriding methods
  * ValidOn - what targets the attribute is designed for. Accepts values from the AttributeTargets enum 
    * <https://msdn.microsoft.com/en-us/library/system.attributetargets(v=vs.110).aspx>
---

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

[AttributesExample.zip](https://github.com/simonjstanford/70-483-c-sharp-notes/blob/master/media/AttributesExample.zip)
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTEyMzY2NDkzNDRdfQ==
-->