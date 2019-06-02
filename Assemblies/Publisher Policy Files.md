# Publisher Policy Files

  * If you've deployed an assembly to the GAC but then a bug is found in the DLL and is fixed, you can use a publisher policy file to specify that a different version of the DLL should be used.
  * Uses XML to set a binding redirect to the new DLL.
  * The publish policy file is deployed to the GAC.

 **Creating a Publisher Policy  **

1) Create two strongly named assemblies with the same assembly name. One must
be a different version than the other. I put them both in the GAC.


    gacutil -i "C:\Users\simon\Dropbox\Coding\70-483\StrongNaming\StrongNamedAssembly\StrongNamedAssembly\bin\Debug\StrongNamedAssembly.dll"
    gacutil -i "C:\Users\simon\Dropbox\Coding\70-483\StrongNaming\StrongNamedAssemblyV2\StrongNamedAssemblyV2\bin\Debug\StrongNamedAssembly.dll"


2) Create a publisher policy file redirecting one assembly to the other. Note
that the <probing/> element is used to define the place where the new DLL is
located. This is important as .NET looks in the application directory for the
DLL and throws an TypeLoadException if it can't find it. The documentation
says that the probing element can only be used when the path is relative to
the application, but I found that an absolute path worked.

  

![noteattachment3][7d646f78a4345467ae7d22e75cf07f33]

  

2a) Alternatively, you can use the codeBase element instead of a probing
element to specify a location for the DLL. This is used when the DLL isn't in
the application directory is not on the local computer. The remote DLL needs
to be strongly named.

  

<?xml version="1.0" encoding="utf-8"?>

<configuration>

  <runtime>

    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">

  

      <codeBase version="3.0.0.0" href= "\\\simon-server\Backup\StrongNamedAssembly.dll"/>

  

      <dependentAssembly>

  

        <assemblyIdentity name="StrongNamedAssembly"

                          publicKeyToken="9b72c515e5bd9e33"

                          culture="neutral" />

  

        <!-- Redirecting to version 3.0.0.0 of the assembly. -->

        <bindingRedirect oldVersion="1.0.0.0"

                         newVersion="3.0.0.0"/>

  

      </dependentAssembly>

    </assemblyBinding>

  </runtime>

</configuration>

  

3) Run an Assembly Linker command to turn the Publisher Policy File into a
DLL. Make sure that the output DLLs name is in the format **policy.**
_majorNumber_ **.** _minorNumber_ **.** _mainAssemblyName_ **.dll**.

  

al /link:"C:\Users\simon\Dropbox\Coding\70-483\Strong
Naming\PublisherPolicyFileExample\Publisher Policy File\Publisher Policy
File.xml" /out:"C:\temp\PublisherPolicyAssembly.dll"
/keyfile:"C:\Users\simon\Dropbox\Coding\70-483\Strong
Naming\StrongNamedAssemblyV2\StrongNamedAssemblyV2\myKey.snk" /platform:anycpu  



4) Install the new DLL into the GAC. **Note that the publisher policy XML file
and publisher policy DLL need to be in the same directory.**

 **  
**

gacutil -i "C:\Users\simon\Dropbox\Coding\70-483\Strong
Naming\PublisherPolicyFileExample\Publisher Policy
File\policy.1.0.StrongNamedAssembly.dll"

 **  
**

5) Now, applications that reference v1 of the assembly will use v2.

  

 **![noteattachment4][b0d4deaa6eb2ccbab9956c6733a8b808]**

  


---
### ATTACHMENTS
[5d818a5597a007ff091527b7bc98af34]: media/StrongNamedAssemblyV2.zip
[StrongNamedAssemblyV2.zip](media/StrongNamedAssemblyV2.zip)
>hash: 5d818a5597a007ff091527b7bc98af34  
>source-url: file://C:\Users\simon\Dropbox\Coding\70-483\Strong Naming\StrongNamedAssemblyV2.zip  
>file-name: StrongNamedAssemblyV2.zip  
>attachment: true  

[dd3d89c875cbf461ccba373b1fe56034]: media/StrongNamedAssembly.zip
[StrongNamedAssembly.zip](media/StrongNamedAssembly.zip)
>hash: dd3d89c875cbf461ccba373b1fe56034  
>source-url: file://C:\Users\simon\Dropbox\Coding\70-483\Strong Naming\StrongNamedAssembly.zip  
>file-name: StrongNamedAssembly.zip  
>attachment: true  

[7d646f78a4345467ae7d22e75cf07f33]: media/Publisher_Policy_File.xml
[Publisher_Policy_File.xml](media/Publisher_Policy_File.xml)
>hash: 7d646f78a4345467ae7d22e75cf07f33  
>source-url: file://C:\Users\simon\Dropbox\Coding\70-483\Strong Naming\PublisherPolicyFileExample\Publisher Policy File\Publisher Policy File.xml  
>file-name: Publisher Policy File.xml  
>attachment: true  

[b0d4deaa6eb2ccbab9956c6733a8b808]: media/PublisherPolicyFileExample.zip
[PublisherPolicyFileExample.zip](media/PublisherPolicyFileExample.zip)
>hash: b0d4deaa6eb2ccbab9956c6733a8b808  
>source-url: file://C:\Users\simon\Dropbox\Coding\70-483\Strong Naming\PublisherPolicyFileExample.zip  
>file-name: PublisherPolicyFileExample.zip  
>attachment: true  

---
### NOTE ATTRIBUTES
>Created Date: 2016-11-02 12:27:37  
>Last Evernote Update Date: 2016-11-08 19:10:31  
>author: simonjstanford@gmail.com  
>source-url: https://msdn.microsoft.com/en-us/library/dz32563a(v=vs.110).aspx  

<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE5NzIzMjIyOTIsLTU4OTQ1ODQ3OF19
-->