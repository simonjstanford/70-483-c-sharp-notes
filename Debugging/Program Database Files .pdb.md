# Program Database Files (.pdb)

  * PDBs are a data source that annotates an assembly with 
    * Source file names and lines
    * Local variable names
  * They are created with the `/debug:Full` or `/debug:pdbonly` command line switches. `/debug:pdbonly` is recommended for release build as without the pdb files you won't be able to debug the code.
  * The debugger looks for a .pdb file with the same name as the assembly that's in the same directory.
  * The pdb should have an ID (GUID) that matches and ID in the assembly dll metadata. As PDBs are created at compile time with a new GUID, you can't use old PDBs to debug because the GUIDs wont match.
  * You can view the debug info for Microsoft DLLs by using the Microsoft Symbol Server. 
    * Turn off 'enable just my code' (tools -> options -> debugging -> general).
    * Select Symbols -> Microsoft Symbols Server
  * You can use TFS to publish PDB files from builds to a shared location. This lets you debug previous versions of an application without have the source code.
  * You can't debug without PDB files!
  * A PDB file contains private and public symbol data. 
    * A public PDB file only contains items that are available from one source file to another. Therefore, local variables etc. are not in the public symbol.
  * Use PDBCopy.exe (part of the Windows Software Development Kit) to remove symbol data:


```
cd "C:\Program Files (x86)\Windows Kits\10\Debuggers\x64"
pdbcopy "C:\Users\simon\70-483\Strong Naming\StrongNamedAssemblyV3\StrongNamedAssemblyV3\bin\Debug\StrongNamedAssembly.pdb" "C:\Users\simon\70-483\Strong Naming\StrongNamedAssemblyV3\StrongNamedAssemblyV3\bin\Debug\PublicStrongNamedAssembly.pdb" -p
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbNjA2ODIzNTA1LDIwNDEwODA1OTRdfQ==
-->