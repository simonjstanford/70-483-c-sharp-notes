# Versioning Assemblies

  * Managed assemblies have a version number in the assembly manifest.
  * The manifest records its own version and the version numbers of all the other assemblies that it references.
  * Format: major.minor.build.revision. 
    * Major: new features, breaking changes.
    * Minor: small changes to existing features.
    * Build: Auto incremented on each build
    * Revision: patches in the production environment
  * A project has an AssemblyInfo.cs file. It contains: 
    * An AssemblyFileVersionAttribute. Incremented on each build. This shouldn't be done on each developer build - it should be integrated into the build process on the build server.
    * AssemblyVersionAttribute. Incremented manually. DOne when you want to deploy a specific version.


E.g:

    [assembly: AssemblyVersion("1.0.0.0")]
    [assembly: AssemblyFileVersion("1.0.0.0")]

<!--stackedit_data:
eyJoaXN0b3J5IjpbMjA4NTI4NjU5NiwtMjcwODMyMzA5XX0=
-->