# XmlWriter

  

StringWriter stream = new StringWriter();

  

using (XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings() {
Indent = true }))

{

    writer.WriteStartDocument();

    writer.WriteStartElement("People");

    writer.WriteStartElement("Person");

    writer.WriteAttributeString("firstname", "John");

    writer.WriteAttributeString("lastname", "Doe");

    writer.WriteStartElement("contactdetails");

    writer.WriteElementString("EmailAddress", "john@unknown.com");

    writer.WriteEndElement();

    writer.WriteEndElement();

    writer.Flush();

}

  

Console.WriteLine(stream.ToString());

Console.Read();

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-11-29 20:04:23  
>Last Evernote Update Date: 2016-11-29 20:04:44  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  