# Read Attributes

  * Attributes, e.g. serialisation, are read during execution to determine an action.
  * There are two ways to read attributes: 
    * Attribute.GetCustomAttribute() or Attribute.GetCustomAttributes()
    * GetCustomAttributes() on a Type or MemberInfo object.

---
    class Program
    {
    	static void Main(string[] args)
    	{
    		if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute)))
    		{
    			Console.WriteLine("Serializable attribute is defined");
    		}
    
    		//read properties of an attribute
    		var attributes = typeof(ConditionalClass)
    						.GetMethod("Test")
    						.GetCustomAttributes().OfType<ConditionalAttribute>()
    						.OrderBy(a => a.ConditionString);
    
    		foreach (var attribute in attributes)
    		{
    			Console.WriteLine(attribute.ConditionString);
    		}
    		Console.ReadKey();
    	}
    }

    [Serializable]
    public class Person
    {
    
    }

    public class ConditionalClass
    {
    	[Conditional("DEBUG")]
    	public void Test()
    	{
    
    	}
    }

[AttributesExample.zip](https://github.com/simonjstanford/70-483-c-sharp-notes/blob/master/media/AttributesExample.zip)
  
In the example below, the public property 'Reviewed' in DeveloperAttribute is
assigned a value when using the attribute. It is not in the attribute's
constructor, it is just a public property.

    [Developer("Joan Smith", "1", Reviewed = true)]

<https://msdn.microsoft.com/en-us/library/84c42s56.aspx>



<!--stackedit_data:
eyJoaXN0b3J5IjpbLTEwNDU3NTM5ODJdfQ==
-->