# DataContract

The Data Contract serializer is used by WCF to serialize objects into XML or JSON. The `DataContractAttribute` is used instead of `SerializableAttribute`. Members are not serialized by default - they must be decorated with the `DataMember` attribute.

You can use `OnDeserializedAttribute`, `OnDeserializingAttribute`, `ONSerializedAttribute` and `OnSerializingAttribute` in the same wasy as Binary Serialization.


```csharp
class Program
{
    static void Main(string[] args)
    {
        Person p = new Person()
        {
            Name = "Simon Stanford"
        };

        using (Stream stream = new FileStream("data.xml", FileMode.Create))
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(Person));
            serializer.WriteObject(stream, p);
        }

        using (Stream stream = new FileStream("data.xml", FileMode.Open))
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(Person));
            Person result = (Person)serializer.ReadObject(stream);
        }
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
eyJoaXN0b3J5IjpbLTEyMzgzNjEyOV19
-->