# Binary Serialization

  * Used when you don't need to be able to read the serialized data.
  * Helpful when you want to serialize data that isn't suitable for XML, e.g. an image.
  * Binary serialization is done using the System.Runtime.Serialization and System.Runtime.Formatters.Binary namespaces.
  * Private fields are serialized by default (different to XML serialization) so use the [NonSerialized] attribute to stop specific fields being serialized.
  * Use OptionalFieldAttribute to tell the serializer that a field may not be saved in a serialized object. This can be used when you've added a new property to a class.

  

class Program

{

    static void Main(string[] args)

    {

        Person p = new Person()

        {

            FirstName = "Simon",

            LastName = "Stanford",

            Age = 35

        };

  

        IFormatter formatter = new BinaryFormatter();

        using (Stream stream = new FileStream("data.bin", FileMode.Create))

        {

            formatter.Serialize(stream, p);

        }

  

        using (Stream stream = new FileStream("data.bin", FileMode.Open))

        {

            Person p2 = (Person)formatter.Deserialize(stream);

            Console.WriteLine("{0} {1} is {2} years old", p2.FirstName, p2.LastName, p2.Age);

        }

  

        Console.Read();

    }

}

  

[Serializable]

public class Person

{

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

  

    [NonSerialized]

    private bool IsDirty = false;

}

  

  

You can tailor the serialization/deserialization process by executing methods
that take a StreamingContext as a parameter. This is done by creating the
methods inside the class to be serialized and decorating them with one of four
attributes:

  * OnDeserializedAttribute
  * OnDeserializingAttribute
  * OnSerializedAttribute
  * OnSerializingAttribute

  

[OnDeserialized()]

internal void OnDeserializedMethod(StreamingContext context)

{

     Console.WriteLine("OnSerialized.");

}

  

  

 **ISerializable**

You can implement ISerializable to gain more control over the serialization
process. This would allow you to not serialize sensitive data or even encrypt
it.

  

Definition:

  

public interface ISerializable

{

    void GetObjectData(SerializationInfo info, StreamingContext context);

}

  

GetObjectData() method is called when an object is serialized. It is used to
add key/value pairs of the data you want to serialize to the SerializationInfo
object that is passed to the method. This method needs to be decorated with a
SecurityPermission attribute so that it's allowed to execute
serialization/deserialization code.  A **protected** constructor is also
required which is used to retrieve the values and initialize your object
during deserialization.

  

Usage:

  

[Serializable]

public class Person : ISerializable

{

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

  

    [NonSerialized]

    private bool IsDirty = false;

  

    public Person()

    {

  

    }

  

    protected Person(SerializationInfo info, StreamingContext context)

    {

        FirstName = info.GetString("Value1");

        LastName = info.GetString("Value2");

        Age = info.GetInt32("Value3");

    }

  

    [System.Security.Permissions.SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]

    public void GetObjectData(SerializationInfo info, StreamingContext context)

    {

        info.AddValue("Value1", FirstName);

        info.AddValue("Value2", LastName);

        info.AddValue("Value3", Age);

    }

}




---
### NOTE ATTRIBUTES
>Created Date: 2016-12-03 13:42:58  
>Last Evernote Update Date: 2017-01-22 14:36:08  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  