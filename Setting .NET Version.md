# Setting .NET Version

An application runs on the .NET version that it was built with, but for
desktop applications this can be changed by modifying the supportedRuntime
element in app.config. This can't be done with Windows Store apps.

  

  

<configuration>  
  <startup>  
    <supportedRuntime version="<version>"/>   
  </startup>

</configuration>

  

Version values:

  * .NET Framework 1.0: "v1.0.3705"
  * .NET Framework 1.1: "v1.1.4322"
  * .NET Framework 2.0, 3.0, and 3.5: "v2.0.50727"
  * .NET Framework 4 and 4.5 (including point releases such as 4.5.1): "v4.0"

  

Rules:

  * If the supportedRuntime element is set and the local machine has that version of .NET then the application will run on that version.
  * If there is no supportedRuntime element or no config file and the local machine has the version of .NET that the app was written in then that version will be used.
  * If the .NET version that application was written in is not installed on the local machine and there is no supportedRuntime element set then the latest version of .NET is used. However, .NET applications of versions before 4.0 will not try to run on .NET 4 and newer. Instead, the user will be asked to install .NET 3.5. This can be overridden with a supportedRuntime entry.
  * You can use multiple supportedElement entries, in order of preference.


---
### NOTE ATTRIBUTES
>Created Date: 2017-02-05 13:39:27  
>Last Evernote Update Date: 2017-02-05 13:53:03  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-url: https://msdn.microsoft.com/en-us/library/jj152935(v=vs.110).aspx  
>source-application: evernote.win32  