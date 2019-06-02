# Profiling an Application

Profiling is the process of determining how your application uses certain
resources, e.g. memory uses, which methods are being called and how long each
method takes to execute. This is helpful when you have a bottleneck and need
to track down the cause.

  

Best practice is not to prematurely optimise code. Instead, it should be
written as readable and maintainable as possible. Performance optimisation
should only occur when you run into problems.

  

A simple way of measuring execution time is by using the Stopwatch class:

  

const int numberOfIterations = 100000;

  

static void Main(string[] args)

{

    Stopwatch sw = new Stopwatch();

    sw.Start();

    Algorithm1();

    sw.Stop();

  

    //this can be milliseconds, ticks or formatted time  

    Console.WriteLine(sw.Elapsed);

  

    sw.Reset();

    sw.Start();

    Algorithm2();

    sw.Stop();

  

    Console.WriteLine(sw.Elapsed);

    Console.ReadLine();

}

  

private static void Algorithm1()

{

    string result = "";

    for (int i = 0; i < numberOfIterations; i++)

    {

        result += 'a';

    }

}

  

private static void Algorithm2()

{

    StringBuilder sb = new StringBuilder();

    for (int i = 0; i < numberOfIterations; i++)

    {

        sb.Append('a');

    }

  

    string result = sb.ToString();

}

  

Alternatively, you can use the Performance Profiler that comes with Visual
Studio. In 2012 it was only available Ultimate, Premium and Professional. The
profiler can be found in the Analze menu in the toolbar. The easiest thing to
do is to use the Performance Wizard. You have four options:

  * CPU Sampling. A lightweight option that has little effect on the application. Used in an initial search of performance problems.
  * Instrumentation. Injects code into a compiled file that captures timing information for each function that is called. Used to find problems with input/output or to closely examine a method.
  * .NET memory allocation. Interrupts a program each time the application allocates a new object or when the garbage collector is called to show how memory is used.
  * Resource contention data. Used in multithreaded applications to find out why methods have to wait for each other before they can access a shared resource.


---
### NOTE ATTRIBUTES
>Created Date: 2016-11-14 20:24:16  
>Last Evernote Update Date: 2016-11-14 20:47:43  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  
<!--stackedit_data:
eyJoaXN0b3J5IjpbNDYyMjIxOTkyXX0=
-->