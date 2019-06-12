# XmlReader

An abstract base class and inherited by `XmlTextReader`, `XmlNodeReader` and XmlValidatingReader.


string xml = @"<?xml version=""1.0"" encoding =""utf 8"" ?>
                <people>
                    <person firstname =""john"" lastname =""doe"">
                        <contactdetails>
                            <emailaddress>john@unknown.com</emailaddress>
                        </contactdetails>
                    </person>

                    <person firstname =""jane"" lastname =""doe"">
                        <contactdetails>
                            <emailaddress>jane@unknown.com</emailaddress>
                            <phonenumber>001122334455</phonenumber>
                        </contactdetails>
                    </person>
                </people>";

using (StringReader stringReader = new StringReader(xml))
{
    using (XmlReader xmlReader = XmlReader.Create(stringReader, new XmlReaderSettings() { IgnoreWhitespace = true }))
    {
        xmlReader.MoveToContent();

        xmlReader.ReadStartElement("people");

        string firstName = xmlReader.GetAttribute("firstname");
        string lastName = xmlReader.GetAttribute("lastname");
        Console.WriteLine("Person: {0} {1}", firstName, lastName);

        xmlReader.ReadStartElement("person");

        Console.WriteLine("Contact Details");
        xmlReader.ReadStartElement("contactdetails");
        string emailAddress = xmlReader.ReadString();
        Console.WriteLine("Email address: {0}", emailAddress);
    }
}

The above only outputs the first person element:


Person: john doe
Contact Details
Email address:  john@unknown.com

A more complete example:


string xml = @"<?xml version=""1.0"" encoding =""utf 8"" ?>
    <people>
        <person firstname =""john"" lastname =""doe"">
            <contactdetails>
                <emailaddress>john@unknown.com</emailaddress>
            </contactdetails>
        </person>

        <person firstname =""jane"" lastname =""doe"">
            <contactdetails>
                <emailaddress>jane@unknown.com</emailaddress>
                <phonenumber>001122334455</phonenumber>
            </contactdetails>
        </person>
    </people>";

using (StringReader stringReader = new StringReader(xml))
{
    using (XmlReader r = XmlReader.Create(stringReader, new XmlReaderSettings() { IgnoreWhitespace = true }))
    {

        while (r.Read())
        {
            switch (r.NodeType)
            {
                case XmlNodeType.Element:
                    if (r.IsStartElement())
                    {
                        Console.WriteLine("Element: {0}", r.Name);

                        if (r.HasAttributes)
                        {
                            while (r.MoveToNextAttribute())
                            {
                                dynamic value = r.ReadContentAs(r.ValueType, null);
                                Console.WriteLine("--Attribute: {0}: {1}, {2}", r.Name, value, value.GetType());
                            }
                        }
                    }
                    break;
                case XmlNodeType.Text:
                    if (r.HasValue)
                    {
                        dynamic value = r.ReadContentAs(r.ValueType, null);
                        Console.WriteLine("--Value: {0}, {1}", value, value.GetType());
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

Console.Read();

Outputs:


Element: people
Element: person
--Attribute: firstname: john, System.String
--Attribute: lastname: doe, System.String
Element: contactdetails
Element: emailaddress
--Value: john@unknown.com, System.String
Element: person
--Attribute: firstname: jane, System.String
--Attribute: lastname: doe, System.String
Element: contactdetails
Element: emailaddress
--Value: jane@unknown.com, System.String
Element: phonenumber
--Value: 001122334455, System.String


<!--stackedit_data:
eyJoaXN0b3J5IjpbOTExMjMzNjQzLC0xMzc4MTc4OTUxXX0=
-->