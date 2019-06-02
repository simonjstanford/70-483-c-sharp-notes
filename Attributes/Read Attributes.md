# Read Attributes




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







  
  

![noteattachment1][e4b5c673138eb3dbd1cc4d0bbe8e764f]

  

In the example below, the public property 'Reviewed' in DeveloperAttribute is
assigned a value when using the attribute. It is not in the attribute's
constructor, it is just a public property.

  

[Developer("Joan Smith", "1", Reviewed = true)]

  

  

<https://msdn.microsoft.com/en-us/library/84c42s56.aspx>


---
### ATTACHMENTS
[e4b5c673138eb3dbd1cc4d0bbe8e764f]: media/AttributesExample.zip
[AttributesExample.zip](media/AttributesExample.zip)
>hash: e4b5c673138eb3dbd1cc4d0bbe8e764f  
>source-url: file://C:\Users\Simon\Desktop\AttributesExample.zip  
>file-name: AttributesExample.zip  
>attachment: true  

---
### NOTE ATTRIBUTES
>Created Date: 2016-10-03 21:08:31  
>Last Evernote Update Date: 2017-01-30 20:06:24  
>author: simonjstanford@gmail.com  
>source-url: https://msdn.microsoft.com/en-us/library/84c42s56.aspx  

<!--stackedit_data:
eyJoaXN0b3J5IjpbMjEzMTk0ODEwNF19
-->