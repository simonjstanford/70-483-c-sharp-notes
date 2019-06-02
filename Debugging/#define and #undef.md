# #define and #undef

Define custom symbols with #define before any code in a file.

    #define MyDirective
    
    using System;
    
    namespace CompilerDirectiveExample
    {
        class Program
        {
            static void Main(string[] args)
            {
    
    #if MyDirective
                Console.WriteLine("MyDirective!");
    #else
                Console.WriteLine("Not MyDirective!");
    #endif
    
            }
        }
    }

  
Use #undef to remove a symbol.

    #undef MyDirective
    
    using System;
    
    namespace CompilerDirectiveExample
    {
        class Program
        {
            static void Main(string[] args)
            {
    
    #if MyDirective
                Console.WriteLine("MyDirective!");
    #else
                Console.WriteLine("Not MyDirective!");
    #endif
            }
        }
    }
<!--stackedit_data:
eyJoaXN0b3J5IjpbNjMyNTgwODUxLC04MDg5Mjg3NDVdfQ==
-->