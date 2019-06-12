# XML Schemas

XSD schema files can be created by using the XML Schema Definition Tool (Xsd.exe) via the visual studio command prompt. It can generate XML schema files or C# classes.

If you execute xsd.exe "C:\person.xml" you get the following schema:

[person.xml](../media/person.xml)
[person.xsd](../media/person.xsd)

XML can be validated using schemas:



public void ValidateXml()
{
    string xsdPath = "person.xsd";
    string xmlPath = "person.xml";
    XmlReader reader = XmlReader.Create(xmlPath);
    XmlDocument document = new XmlDocument();
    document.Schemas.Add("", xsdPath);
    document.Load(reader);
    var eventHandler = new ValidationEventHandler(MyValidationEventHandler);
    document.Validate(eventHandler);
    Console.ReadKey();
}
//if something is wrong with the file then this method is called
private void MyValidationEventHandler(object sender, ValidationEventArgs e)
{
    switch (e.Severity)
    {
        case XmlSeverityType.Error:
            Console.WriteLine("Error: {0}", e.Message);
            break;
        case XmlSeverityType.Warning:
            Console.WriteLine("Warning: {0}", e.Message);
            break;
        default:
            break;
    }
}




<!--stackedit_data:
eyJoaXN0b3J5IjpbMTI0MDE4NTE3NiwxMzA1MTYyNDcwXX0=
-->