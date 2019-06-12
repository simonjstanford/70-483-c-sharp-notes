# XPath

`XPath` is a query language for XML documents. `XmlDocument` implements `IXPathNavigable` so you can retrieve an `XPathNavigator` object from it. This gives you a way of moving and querying an XML document.

```csharp
XmlDocument doc = new XmlDocument();
doc.Load(stringReader);

XPathNavigator nav = doc.CreateNavigator();
string query = "//people/person[@firstname='Jane']";
XPathNodeIterator iterator = nav.Select(query);

Console.WriteLine(iterator.Count);

while (iterator.MoveNext())
{
    string firstName = iterator.Current.GetAttribute("firstname", "");
    string lastName = iterator.Current.GetAttribute("lastname", "");
    Console.WriteLine("Name: {0} {1}", firstName, lastName);
}
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbNDk3MjEwMjA1LC05NzAwMzM3NzBdfQ==
-->