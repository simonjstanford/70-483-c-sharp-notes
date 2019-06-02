# XML

The first line in an XML file is called the prolog:

  

<?xml version="1.0" encoding="utf-8" ?>

  

An XML document can contain comments/special processing instructions. This can
be contained in a Document Type Definition (DTD) file that is stored
externally and referenced in the prolog.

  

The classes for working with XML files are in System.Xml:

  * [XmlReader](evernote:///view/26944639/s226/76052bad-c990-43e2-8d79-f8b3794e8a20/76052bad-c990-43e2-8d79-f8b3794e8a20/). An abstract base class. You can only moved forward and nothing is cached.
  * [XmlWriter](evernote:///view/26944639/s226/514401a8-98d1-4262-86dc-8d549bdd03b8/514401a8-98d1-4262-86dc-8d549bdd03b8/). You can only moved forward and nothing is cached.
  * [XmlDocument](evernote:///view/26944639/s226/3b96acf5-928f-4b75-8a1b-70d520ba7a83/3b96acf5-928f-4b75-8a1b-70d520ba7a83/)
  * [XPath](evernote:///view/26944639/s226/73cddeeb-7af0-4c00-a318-2bbb23902722/73cddeeb-7af0-4c00-a318-2bbb23902722/). Used to navigate through an XML document.


---
### NOTE ATTRIBUTES
>Created Date: 2016-11-29 19:26:58  
>Last Evernote Update Date: 2017-01-28 11:29:16  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  