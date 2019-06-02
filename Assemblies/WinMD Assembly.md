# WinMD Assembly

  * WinRT Runtime is for Windows 8 and is written in native C++. It is used to created Windows 8 Apps. As it is C++, the DLLs don't have metadata.
  * As Windows 8 Apps can also be written in other languages (e.g. JavaScript, C#), Windows Metadata files (WinMD) are used to create mappings between these managed and unmanaged components.
  * WinMD files contain code and Metadata that is used in Intellisense.
  * WinRT does not offer access to all of .NET 4.5 - duplicate, legacy, etc. code was removed.
  * WinMD assemblies are created by adding a Windows Runtime Component. This is only done when creating a component that will be used by other languages. Otherwise, just use a Class Library (Windows Store Apps) project.
  * There are restrictions on Windows Runtime components: 
    * Classes can't be generic
    * You can't implement an interface that isn't a WinRT interface.
    * You can't derive from types not inside WinRT.
    * ....plus some more (p.218)


---
### NOTE ATTRIBUTES
>Created Date: 2016-11-08 19:14:49  
>Last Evernote Update Date: 2016-11-08 19:20:54  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE5MDAzNTUzMDZdfQ==
-->