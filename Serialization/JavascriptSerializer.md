# JavascriptSerializer

This class is kept in `System.Web.Extensions.dll` and is used to serialize/deserialize objects into JSON. JSON can start/end with EITHER `[ ]` or `{ }`.


```csharp
class Program
{
    static void Main(string[] args)
    {
        var RegisteredUsers = new List<Person>();
        RegisteredUsers.Add(new Person() { PersonID = 1, Name = "Bryon Hetrick", Registered = true });
        RegisteredUsers.Add(new Person() { PersonID = 2, Name = "Nicole Wilcox", Registered = true });
        RegisteredUsers.Add(new Person() { PersonID = 3, Name = "Adrian Martinson", Registered = false });
        RegisteredUsers.Add(new Person() { PersonID = 4, Name = "Nora Osborn", Registered = false });
        //serialization
        var serializer = new JavaScriptSerializer();
        var serializedResult = serializer.Serialize(RegisteredUsers);
        Console.WriteLine(serializedResult);
        //deserialization
        var deserializedResult = serializer.Deserialize<List<Person>>(serializedResult);
        Console.WriteLine(string.Format("New list contains {0} items.", deserializedResult.Count));
        Console.ReadKey();
    }
}
public class Person
{
    public int PersonID { get; set; }
    public string Name { get; set; }
    public bool Registered { get; set; }
}
```

Or to serialize using JSON. Note that members without the DataMember attribute are not serialized:

```csharp
class Program
{
    static void Main(string[] args)
    {
        Person p = new Person()
        {
            Name = "Simon Stanford"
        };

        using (MemoryStream stream = new MemoryStream())
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));
            serializer.WriteObject(stream, p);

            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            Console.WriteLine(reader.ReadToEnd());

            stream.Position = 0;
            Person result = (Person)serializer.ReadObject(stream);
        }

        Console.Read();

    }
}

[DataContract]
public class Person
{
    [DataMember]
    public string Name { get; set; }

    public bool IsDirty { get; set; }
}
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbMjU5NTYzODAxXX0=
-->