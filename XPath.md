# XPath

XPath is a query language for XML documents. XmlDocument implements
IXPathNavigable so you can retrieve an XPathNavigator object from it. This
gives you a way of moving and querying an XML document.

  

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

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-11-29 20:24:47  
>Last Evernote Update Date: 2016-11-29 20:30:53  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  