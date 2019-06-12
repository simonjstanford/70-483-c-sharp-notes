# XML

The first line in an XML file is called the prolog:

```xml
<?xml version="1.0" encoding="utf-8" ?>
```

An XML document can contain comments/special processing instructions. This can be contained in a Document Type Definition (DTD) file that is stored externally and referenced in the prolog.

The classes for working with XML files are in `System.Xml`
- `XmlReader`. An abstract base class. You can only moved forward and nothing is cached.
- `XmlWriter`. You can only moved forward and nothing is cached.
- `XmlDocument`
- `XPath`. Used to navigate through an XML document.


<!--stackedit_data:
eyJoaXN0b3J5IjpbOTc2MjI5OTZdfQ==
-->