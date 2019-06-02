# XmlSerializer

  * This was created for SOAP messaging for use in web services.
  * XmlSerializer is loosely coupled using attributes to map nodes to properties. If the serializer can't find a property during deserialization then it will just set it to its default value.
  * You need to add the [Serializable] attribute to the class. If the object can't be serialized then an exception will be thrown at runtime.
  * All members are serialized unless they opt-out.
  * The XmlIgnore attribute is used to not serialize a member.

  

Drawbacks:

  * It doesn't maintain object references.
  * Doesn't work with private fields.
  * Doesn't have the highest performance. 
  * The class must be public.

  

Usage:

  

class Program

{

    static void Main(string[] args)

    {

        XmlSerializer serializer = new XmlSerializer(typeof(Person));

  

        string xml;

        using (StringWriter writer = new StringWriter())

        {

            Person p = new Person()

            {

                FirstName = "Simon",

                LastName = "Stanford",

                Age = 35

            };

  

            serializer.Serialize(writer, p);

            xml = writer.ToString();

        }

  

        Console.WriteLine(xml);

  

        using (StringReader reader = new StringReader(xml))

        {

            Person p = (Person)serializer.Deserialize(reader);

            Console.WriteLine("{0} {1} is {2} years old", p.FirstName, p.LastName, p.Age);

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

}

  

There are attributes you can use to change how the XML is created. Note that
derived classes needs to be identified in the XmlSerializer constructor.

  

class Program

{

    static void Main(string[] args)

    {

        Random random = new Random();

  

        XmlSerializer serializer = new XmlSerializer(typeof(Order), new Type[] { typeof(VipOrder) });

  

        string xml;

        using (StringWriter writer = new StringWriter())

        {

  

            Order p = new VipOrder()

            {

                ID = random.Next(),

                IsDirty = true,

                Description = "VIP Order!",

                OrderLines = new List<OrderLine>()

                {

                    new OrderLine()

                    {

                        ID = random.Next(),

                        Amount = 20,

                        Product = "Test Product 1"

                    },

                    new OrderLine()

                    {

                        ID = random.Next(),

                        Amount = 5,

                        Product = "Test Product 2"

                    },

                }

            };

  

            serializer.Serialize(writer, p);

            xml = writer.ToString();

        }

  

        Console.WriteLine(xml);

        Console.Read();

    }

}

  

[Serializable]

public class Order

{

    [XmlAttribute]

    public int ID { get; set; }

  

    [XmlIgnore]

    public bool IsDirty { get; set; }

  

    [XmlArray("Lines")]

    [XmlArrayItem("OrderLine")]

    public List<OrderLine> OrderLines { get; set; }

}

  

[Serializable]

public class OrderLine

{

    [XmlAttribute]

    public int ID { get; set; }

  

    [XmlAttribute]

    public int Amount { get; set; }

  

    [XmlElement("OrderedProduct")]

    public string Product { get; set; }

}

  

[Serializable]

public class VipOrder : Order

{

    public string Description { get; set; }

}

  

  

XmlAttributes

The XmlAttributes class is a collection of attribute objects that control how
the XmlSerializer serializes and deserializes an object. This is useful when
you're working with a class that is defined in an inaccessible source.

  

  

public class Orchestra

{

    public Instrument[] Instruments;

}

  

public class Instrument

{

    public string Name;

}

  

public class Brass : Instrument

{

    public bool IsValved;

    public bool IsShiny;

}

  

public class Run

{

    public static void Main()

    {

        Run test = new Run();

        test.SerializeObject();

        test.DeserializeObject("Override.xml");

  

        Console.Read();

    }

  

    public void SerializeObject()

    {

        Orchestra band = new Orchestra();

  

        // Create an object of the derived type.

        Brass i = new Brass();

        i.Name = "Trumpet";

        i.IsValved = true;

        i.IsShiny = false;

        Instrument[] myInstruments = { i };

        band.Instruments = myInstruments;

  

        XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides();

  

        //register the derived class as serializable as an element

        XmlAttributes attrs = new XmlAttributes();

        XmlElementAttribute attr = new XmlElementAttribute();

        attr.ElementName = "Brass";

        attr.Type = typeof(Brass);

        attrs.XmlElements.Add(attr);

        attrOverrides.Add(typeof(Orchestra), "Instruments", attrs);

  

        //register the IsShiny property as serializable as an attribute

        XmlAttributes attrs2 = new XmlAttributes();

        XmlAttributeAttribute xAttribute2 = new XmlAttributeAttribute("IsShiny");

        attrs2.XmlAttribute = xAttribute2;

        attrOverrides.Add(typeof(Brass), "IsShiny", attrs2);

  

        //register the IsValved property as serializable as an attribute

        XmlAttributes attrs3 = new XmlAttributes();

        XmlAttributeAttribute xAttribute = new XmlAttributeAttribute("IsValved");

        attrs3.XmlAttribute = xAttribute;

        attrOverrides.Add(typeof(Brass), "IsValved", attrs3);

  

        //serialize the objects

        XmlSerializer s = new XmlSerializer(typeof(Orchestra), attrOverrides);

        using (StringWriter writer = new StringWriter())

        {

            s.Serialize(writer, band);

            Console.WriteLine(writer.ToString());

        }

    }

  

    public void DeserializeObject(string filename)

    {

        XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides();

        XmlAttributes attrs = new XmlAttributes();

  

        // Create an XmlElementAttribute to override the Instrument.

        XmlElementAttribute attr = new XmlElementAttribute();

        attr.ElementName = "Brass";

        attr.Type = typeof(Brass);

  

        // Add the XmlElementAttribute to the collection of objects.

        attrs.XmlElements.Add(attr);

  

        attrOverrides.Add(typeof(Orchestra), "Instruments", attrs);

  

        // Create the XmlSerializer using the XmlAttributeOverrides.

        XmlSerializer s = new XmlSerializer(typeof(Orchestra), attrOverrides);

  

        FileStream fs = new FileStream(filename, FileMode.Open);

        Orchestra band = (Orchestra)s.Deserialize(fs);

        Console.WriteLine("Brass:");

  

        /* The difference between deserializing the overridden

        XML document and serializing it is this: To read the derived

        object values, you must declare an object of the derived type

        (Brass), and cast the Instrument instance to it. */

        Brass b;

        foreach (Instrument i in band.Instruments)

        {

            b = (Brass)i;

            Console.WriteLine(

            b.Name + "\n" +

            b.IsValved);

        }

    }

}

  

public static string SerializeFontList(FontList fontList)

{

   string xml;

   using (var stream = Serializer.Serialize(ref fontList))

   using (var reader = new StreamReader(stream))

   {

      xml = reader.ReadToEnd();

   }

   return xml;

}

  

public static FontList DeserializeFontList(string xml)

{

   FontList fontList;

        

   //load the xml into a byte array

   byte[] byteArray = Encoding.UTF8.GetBytes(xml);

   using (var ms = new MemoryStream(byteArray))

   {

      fontList = Serializer.Deserialize<FontList>(ms);

   }

   return fontList;

}

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-12-03 13:11:18  
>Last Evernote Update Date: 2017-12-01 14:32:09  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  