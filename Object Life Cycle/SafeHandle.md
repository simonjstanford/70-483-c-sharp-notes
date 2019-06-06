# SafeHandle


`IntPtr` is just a simple integer-based struct that can hold a pointer (ie., 32 bit size on 32-bit systems, 64-bit size on 64-bit systems).

`SafeHandle` is a class that is intended to hold Win32 object handles - it has a finalizer that makes sure that the handle is closed when the object is GC'ed. `SafeHandle` is an abstract class because different Win32 handles have different ways they need to be closed. Prior to the introduction of `SafeHandle`, `IntPtr` was used to hold Win32 handles, but ensuring that they were properly closed and prevented from being GC'ed was the responsibility of the programmer.

http://stackoverflow.com/questions/526661/intptr-safehandle-and-handleref-explained
https://msdn.microsoft.com/en-gb/library/system.runtime.interopservices.safehandle(v=vs.110).aspx  
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTIyMTMyOTcwN119
-->