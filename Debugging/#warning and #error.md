# #warning and #error

#warning and #error can be used to report a warning/error to the compiler.

    using System;
    
    namespace CompilerDirectiveExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                #warning Bollocks
                #error Random Error
            }
        }
    }

<!--stackedit_data:
eyJoaXN0b3J5IjpbMTMyOTcwNzAyMl19
-->