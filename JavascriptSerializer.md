# JavascriptSerializer

This class is kept in System.Web.Extensions.dll and is used to
serialize/deserialize objects into JSON. JSON can start/end with EITHER [ ] or
{ }.

  

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

  

Or to serialize using JSON. Note that members without the DataMember attribute
are not serialized:

  

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

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-10-11 19:44:37  
>Last Evernote Update Date: 2017-01-22 14:11:08  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-url: https://msdn.microsoft.com/en-us/library/system.web.script.serialization.javascriptserializer(v=vs.110).aspx  
>source-application: evernote.win32  