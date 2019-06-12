# XmlWriter

```csharp
StringWriter stream = new StringWriter();

using (XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings() { Indent = true }))
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
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTUzNzY1MTg2LC0xNTE5NTcyMTA1XX0=
-->