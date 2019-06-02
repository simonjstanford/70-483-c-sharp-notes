# #line

#line is used to change the line number/file name that is reported by the
compiler.

  

#line 9876

#error Error 1 //shows error on line 9876

  

#line 9877 "Weird File"

#error Error 2 //shows error on line 9877 from file 'Weird File'

  

#line default

#error Error 3 //shows error on correct line

  

#line hidden means that the line of code will be hidden from the debugger.
This means that the line of code is still executed, but it is stepped over
during debugging and you can't put a breakpoint next to it.

  

        Console.WriteLine("Normal line #1."); // Set break point here.   
#line hidden  
        Console.WriteLine("Hidden line.");   
#line default  
        Console.WriteLine("Normal line #2.");  
  

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-11-09 20:10:03  
>Last Evernote Update Date: 2016-11-09 20:10:05  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  