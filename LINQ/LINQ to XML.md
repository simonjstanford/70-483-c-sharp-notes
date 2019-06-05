# LINQ to XML

## Querying

Obtain the attribute value for every item. Note that you can use an explicit cast and not have .Value at the end:

```csharp
IEnumerable<string> partNos = 
from item in purchaseOrder.Descendants("Item") 
select (string) item.Attribute("PartNumber");
```

Items with a value greater than $100:

```csharp
IEnumerable<XElement> partNos = 
from item in purchaseOrder.Descendants("Item") 
where (int) item.Element("Quantity") * 
    (decimal) item.Element("USPrice") > 100 
orderby (string)item.Element("PartNumber") 
select item;
```

## Creating

Functional construction can be used to build an XML document. The advantage here is that you can pass as many parameters as you like into each constructor. If you pass in a collection as a parameter then each item in the collection will be added to the XML document.

```csharp
XElement contacts = 
new XElement("Contacts", 
    new XElement("Contact", 
        new XElement("Name", "Patrick Hines"), 
        new XElement("Phone", "206-555-0144", 
            new XAttribute("Type", "Home")), 
        new XElement("phone", "425-555-0145", 
            new XAttribute("Type", "Work")), 
        new XElement("Address", 
            new XElement("Street1", "123 Main St"), 
            new XElement("City", "Mercer Island"), 
            new XElement("State", "WA"), 
            new XElement("Postal", "68042") 
        ) 
    ) 
);
```

A more complete example. Note that if you pass a type as an argument into an `XElement` that is not an `XElement` or `XAttribute` then it will become the contents of the element:

```csharp
XElement people = new XElement("People",
    new XElement("Person",
        new XAttribute("FirstName", "Simon"),
        new XAttribute("LastName", "Stanford"),
        new XAttribute("Age", "35"),
        new XElement("Address",
            new XElement("Address1", "48 Bowden Rd"),
            new XElement("Address2", "St James"),
            new XElement("Town", "Northampton"),
            new XElement("PostCode", "NN5 5LT"))),
    new XElement("Person",
        new XAttribute("FirstName", "Steph"),
        new XAttribute("LastName", "Weaver"),
        new XAttribute("Age", "36"),
        new XElement("Address",
            new XElement("Address1", "51 Collingwood Rd"),
            new XElement("Address2", "Abington"),
            new XElement("Town", "Northampton"),
            new XElement("PostCode", "NN1 4RL"))));

IEnumerable<string> output = from person in people.Elements("Person")
                                where (int)person.Attribute("Age") > 30
                                select (string)person.Attribute("FirstName");

Console.WriteLine(people.ToString());

foreach (var item in output)
{
    Console.WriteLine(item);
}

Console.Read();
```

http://msdn.microsoft.com/en-us/library/bb387061.aspx

<!--stackedit_data:
eyJoaXN0b3J5IjpbMTk1ODQ4NTUwMF19
-->