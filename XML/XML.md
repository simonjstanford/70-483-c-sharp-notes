# XML

The first line in an XML file is called the prolog:

```xml
<?xml version="1.0" encoding="utf-8" ?>
```

An XML document can contain comments/special processing instructions. This can be contained in a Document Type Definition (DTD) file that is stored externally and referenced in the prolog.

The classes for working with XML files are in `System.Xml`
- `[XmlReader](XmlReader.md)`. An abstract base class. You can only moved forward and nothing is cached.
- `[XmlWriter](XmlWriter.md)`. You can only moved forward and nothing is cached.
- `[XmlDocument](XmlDocument.md)`
- `[XPath](XPath.md)`. Used to navigate through an XML document.


<!--stackedit_data:
eyJoaXN0b3J5IjpbMTM3NDU0MDM1NSw5NzYyMjk5Nl19
-->