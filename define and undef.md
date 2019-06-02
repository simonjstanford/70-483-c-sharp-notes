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

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-11-09 20:01:03  
>Last Evernote Update Date: 2016-11-09 20:10:57  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  