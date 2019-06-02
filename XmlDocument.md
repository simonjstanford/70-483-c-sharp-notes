# XmlDocument

XmlReader and XmlWriter and fast but not easy to use. XmlDocument is good for
small files where performance is not an issue. It represents the XML in a
hierarchical way in memory so you can navigate and edit the elements in place.
XmlDocument uses a collection of XmlNode objects and is itself derived from
XmlNode.

  

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

  

using (StringReader stringReader = new StringReader(xml))

{

    XmlDocument doc = new XmlDocument();

    doc.Load(stringReader);

    XmlNodeList nodes = doc.GetElementsByTagName("person");

  

    foreach (XmlNode node in nodes)

    {

        string firstName = node.Attributes["firstname"].Value;

        string lastName = node.Attributes["lastname"].Value;

        Console.WriteLine("Name: {0} {1}", firstName, lastName);

    }

  

    XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "person", "");

  

    XmlAttribute firstNameAttribute = doc.CreateAttribute("firstname");

    firstNameAttribute.Value = "Simon";

  

    XmlAttribute lastNameAttribute = doc.CreateAttribute("lastname");

    lastNameAttribute.Value = "Stanford";

  

    newNode.Attributes.Append(firstNameAttribute);

    newNode.Attributes.Append(lastNameAttribute);

  

    doc.DocumentElement.AppendChild(newNode);

    Console.WriteLine("Modified XML:");

    doc.Save(Console.Out);

}

  

Console.Read();

  

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-11-29 20:04:55  
>Last Evernote Update Date: 2017-03-16 20:36:32  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  