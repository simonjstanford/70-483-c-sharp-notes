# Strings

- Reference type
- Immutable -> thread safe
- There is no difference between string and String -> String is just an alias.
- String interning: if you try to create two identical string object this will reference the same object. Happens at compile time.


## StringWriter/StringReader

This is a StringBuilder wrapper for when you want a TextWriter implementation but only need to store the output in memory, e.g. XMLWriter -> string


```csharp
var stringWriter = new StringWriter();
using (XmlWriter writer = XmlWriter.Create(stringWriter))
{
    writer.WriteStartElement("book");
    writer.WriteElementString("price", "19.95");
    writer.WriteEndElement();
    writer.Flush();
}
string xml = stringWriter.ToString();
Console.WriteLine(xml);

var stringReader = new StringReader(xml);
using (XmlReader reader = XmlReader.Create(stringReader))
{
    reader.ReadToFollowing("price");
    decimal price = decimal.Parse(reader.ReadInnerXml(), new CultureInfo("en-GB"));
    Console.WriteLine(price);
}
Console.ReadKey();
```

https://msdn.microsoft.com/en-us/library/system.io.stringwriter%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396


## StringComparison

This is an enumeration that can be used to change results of comparing strings based on culture:


```csharp
String[] cultureNames = { "en-US", "se-SE" };
String[] strings1 = { "case",  "encyclopædia", "encyclopædia", "Archæology" };
String[] strings2 = { "Case", "encyclopaedia", "encyclopedia" , "ARCHÆOLOGY" };
StringComparison[] comparisons = (StringComparison[])Enum.GetValues(typeof(StringComparison));
foreach (var cultureName in cultureNames)
{
    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
    Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.Name);
    for (int ctr = 0; ctr <= strings1.GetUpperBound(0); ctr++)
    {
        foreach (var comparison in comparisons)
        {
            Console.WriteLine("   {0} = {1} ({2}): {3}", strings1[ctr], strings2[ctr], comparison,
                                String.Equals(strings1[ctr], strings2[ctr], comparison));
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}
Console.ReadKey();
```

https://msdn.microsoft.com/en-us/library/system.stringcomparison.aspx


## ToString()

You can overload ToString() and add a string parameter to allow formatting options. This is similar to how d or D parameters work in DateTime.ToString():

```csharp
class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ToString(string format)
    {
        switch (format)
        {
            case "First":
                return FirstName;
            default:
                return FirstName + " " + LastName;
        }
    }
}
```

## CultureInfo

Use a CultureInfo object to display dates, currency, etc. correctly. CultureInfo implements [IFormatProvider](../Interfaces/IFormatProvider%20&%20ICustomFormatter.md):


```csharp
double cost = 19.99;
Console.WriteLine(cost.ToString("C", new CultureInfo("en-GB")));
```


## IFormatProvider
See [IFormatProvider](../Interfaces/IFormatProvider%20&%20ICustomFormatter.md)


## String.Format
This can be used to format a string. The following code outputs the same value in character format, decimal and hexadecimal. 

```csharp
int i = 163;
Console.WriteLine(string.Format("{0} {1,4} 0x{2:X}", (char)i, i, i));
Console.Read();
```

There are many formatting options:
- https://msdn.microsoft.com/en-us/library/0c899ak8(v=vs.110).aspx
- https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
- https://msdn.microsoft.com/en-us/library/c3s1ez6e(v=vs.110).aspx
- https://msdn.microsoft.com/en-us/library/ee372287(v=vs.110).aspx


<!--stackedit_data:
eyJoaXN0b3J5IjpbMTk5MDA5OTg4NCwxNzEyNTI1MTY5XX0=
-->