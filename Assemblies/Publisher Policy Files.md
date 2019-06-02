# Publisher Policy Files

  * If you've deployed an assembly to the GAC but then a bug is found in the DLL and is fixed, you can use a publisher policy file to specify that a different version of the DLL should be used.
  * Uses XML to set a binding redirect to the new DLL.
  * The publish policy file is deployed to the GAC.

 **Creating a Publisher Policy**

1) Create two strongly named assemblies with the same assembly name. One must
be a different version than the other. I put them both in the GAC.

[StrongNamedAssembly](https://github.com/simonjstanford/70-483-c-sharp-notes/blob/master/media/StrongNamedAssembly.zip)
[StrongNamedAssemblyV2](https://github.com/simonjstanford/70-483-c-sharp-notes/blob/master/media/StrongNamedAssemblyV2.zip)

    gacutil -i "C:\Users\simon\Dropbox\Coding\70-483\StrongNaming\StrongNamedAssembly\StrongNamedAssembly\bin\Debug\StrongNamedAssembly.dll"
    gacutil -i "C:\Users\simon\Dropbox\Coding\70-483\StrongNaming\StrongNamedAssemblyV2\StrongNamedAssemblyV2\bin\Debug\StrongNamedAssembly.dll"

2) Create a publisher policy file redirecting one assembly to the other. Note
that the <probing/> element is used to define the place where the new DLL is
located. This is important as .NET looks in the application directory for the
DLL and throws an TypeLoadException if it can't find it. The documentation
says that the probing element can only be used when the path is relative to
the application, but I found that an absolute path worked.

[Publisher Policy File](https://github.com/simonjstanford/70-483-c-sharp-notes/blob/master/media/Publisher_Policy_File.xml)
  
2a) Alternatively, you can use the codeBase element instead of a probing
element to specify a location for the DLL. This is used when the DLL isn't in
the application directory is not on the local computer. The remote DLL needs
to be strongly named.

    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
    
          <codeBase version="3.0.0.0" href= "\\simon-server\Backup\StrongNamedAssembly.dll"/>
    
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

       al /link:"C:\Users\simon\Dropbox\Coding\70-483\Strong Naming\PublisherPolicyFileExample\Publisher Policy File\Publisher Policy File.xml" /out:"C:\temp\PublisherPolicyAssembly.dll" /keyfile:"C:\Users\simon\Dropbox\Coding\70-483\Strong Naming\StrongNamedAssemblyV2\StrongNamedAssemblyV2\myKey.snk" /platform:anycpu

4) Install the new DLL into the GAC. **Note that the publisher policy XML file
and publisher policy DLL need to be in the same directory.**

       gacutil -i "C:\Users\simon\Dropbox\Coding\70-483\Strong
    Naming\PublisherPolicyFileExample\Publisher Policy
    File\policy.1.0.StrongNamedAssembly.dll"

5) Now, applications that reference v1 of the assembly will use v2.

[Publisher Policy File Example](https://github.com/simonjstanford/70-483-c-sharp-notes/blob/master/media/PublisherPolicyFileExample.zip)
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTQyNDIwMjczNiwtNTg5NDU4NDc4XX0=
-->