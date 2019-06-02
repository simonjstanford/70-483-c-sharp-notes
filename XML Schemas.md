# XML Schemas

XSD schema files can be created by using the XML Schema Definition Tool
(Xsd.exe) via the visual studio command prompt. It can generate XML schema
files or C# classes.

  

If you execute xsd.exe "C:\person.xml" you get the following schema:

  

![noteattachment1][40f77f0c8d8979486ea9742d8045fc77]
![noteattachment2][653984a473ef013177f7cc06e6fecab6]

  

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

  

![noteattachment3][c537ee3a13b48311717dbab60ec38683]  

  


---
### ATTACHMENTS
[40f77f0c8d8979486ea9742d8045fc77]: media/person.xml
[person.xml](media/person.xml)
>hash: 40f77f0c8d8979486ea9742d8045fc77  
>source-url: file://C:\Users\Simon\Desktop\person.xml  
>file-name: person.xml  
>attachment: true  

[653984a473ef013177f7cc06e6fecab6]: media/person.xsd
[person.xsd](media/person.xsd)
>hash: 653984a473ef013177f7cc06e6fecab6  
>source-url: file://C:\Users\Simon\Desktop\person.xsd  
>file-name: person.xsd  
>attachment: true  

[c537ee3a13b48311717dbab60ec38683]: media/XmlSchemaValidationExample.zip
[XmlSchemaValidationExample.zip](media/XmlSchemaValidationExample.zip)
>hash: c537ee3a13b48311717dbab60ec38683  
>source-url: file://C:\Users\Simon\Dropbox\Coding\70-483\XmlSchemaValidationExample.zip  
>file-name: XmlSchemaValidationExample.zip  
>attachment: true  

---
### NOTE ATTRIBUTES
>Created Date: 2016-10-12 18:31:01  
>Last Evernote Update Date: 2016-11-07 22:19:49  
>author: simonjstanford@gmail.com  