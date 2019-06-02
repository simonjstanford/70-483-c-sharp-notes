# LINQ to XML

This allows you to convert a collection into an XML document:

  

List<Employee> employees = new List<Employee>()

{

    new Employee()

    {

        FirstName = "John",

        LastName = "Smith",

        StateId = 1

    },

    new Employee()

    {

        FirstName = "Jane",

        LastName = "Doe",

        StateId = 2

    },

    new Employee()

    {

        FirstName = "Jack",

        LastName = "Jones",

        StateId = 1

    }

};

  

var xmlEmployees = new XElement("Root", from e in employees

                                        select new XElement("Employee", new XElement("FirstName", e.FirstName),

                                                                        new XElement("LastName", e.LastName)));

  

Debug.WriteLine(xmlEmployees);

  

  

Or to read XML:

  

string xml = @"<root><test><title type=""text"">title</title><content
type=""text"">gfgdgdggd</content></test><test2><title
type=""text"">title</title><content
type=""text"">gfgdgdggd</content></test2></root>";

  

XDocument xDoc = XDocument.Parse(xml);

  

var types =

    from x in xDoc.Root.Descendants("test")

    from y in x.Descendants("title")

    where y.Attributes("type").Any()

    select y.Attribute("type").Value;

  

foreach (var type in types)

{

    Console.WriteLine(type.ToString());

}

  

Console.Read();

  

Updating XML can be done procedurally:

  

string xml = @"<?xml version=""1.0"" encoding =""utf 8"" ?>

                <people>

                    <person firstname =""John"" lastname =""Doe"">

                        <contactdetails>

                            <emailaddress> john@unknown.com </emailaddress>

                        </contactdetails>

                    </person>

  

                    <person firstname =""Jane"" lastname =""Doe"">

                        <contactdetails>

  

                            <emailaddress>jane@unknown.com</emailaddress>

                            <phonenumber>001122334455 </phonenumber>

                        </contactdetails>

                    </person>

                </people>";

  

XElement root = XElement.Parse(xml);

  

foreach (XElement p in root.Descendants("person"))

{

    string name = (string)p.Attribute("firstname") + (string)p.Attribute("lastname");

  

    p.Add(new XAttribute("IsMale", name.Contains("John")));

  

    XElement contactDetails = p.Element("contactdetails");

    if (!contactDetails.Descendants("phonenumber").Any())

    {

        contactDetails.Add(new XElement("phonenumber", "01234567890"));

    }

}

  

Console.WriteLine(root.ToString());

  

Console.Read();

  

Or using functional construction:

  

XElement root = XElement.Parse(xml);

  

XElement newTree = new XElement("people",

    from p in root.Descendants("person")

    let name = (string)p.Attribute("firstname") + (string)p.Attribute("lastname")

    let contactDetails = p.Element("contactdetails")

    select new XElement("person", new XAttribute("IsMale", name.Contains("John")),

                                    p.Attributes(),

                                    new XElement("contactdetails",

                                                contactDetails.Element("emailAddress"),

                                                contactDetails.Element("phonenumber") ?? new XElement("phonenumber", 01234567890))));

  

Console.WriteLine(newTree.ToString());

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-12-02 18:19:43  
>Last Evernote Update Date: 2017-01-27 19:08:57  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  