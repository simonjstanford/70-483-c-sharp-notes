# Performance Monitor

You can access the performance monitor programmatically:

  

using (PerformanceCounter pc = new PerformanceCounter("Memory", "Available
Bytes"))

{

    string text = "Available memory: ";

    Console.Write(text);

  

    while (true)

    {

        Console.Write(pc.RawValue);

        Console.SetCursorPosition(text.Length, Console.CursorTop);

    }

}

  

All performance monitors have a unique name within a category.

  

To access the performance monitors one of the following must be true:

  * The application needs to run under full trust  
  * The account that is running the application must be an administrator or part of the Performance Monitor Users group.

  

  

 **Performance Counters**

Performance counters come in different types, but they all implement
IDisposable because they access unmanaged resources. Some types are:

  *  **NumberOfItems32/NumberOfItems64** : Counts the number of operations/items.
  *  **RateOfCountsPerSecond32/RateOfCountsPerSecond64** : Calculates the amount per second of an item/operation.
  *  **AverageTimer32**  The average time to perform a process.

  

How to programmatically use Windows Perfmon:

  

static void Main(string[] args)

{

    if (CreatePerformanceCounters())

    {

        Console.WriteLine("Created performance counters");

        Console.WriteLine("Please restart application");

        Console.ReadKey();

        return;

    }

  

    var totalOperationCounter = new PerformanceCounter(

        "MyCategory",

        "# operations executed",

        "",

        false);

  

    var operationsPerSecondCounter = new PerformanceCounter(

        "MyCategory",

        "# operations / sec",

        "",

        false);

  

    totalOperationCounter.Increment();

    operationsPerSecondCounter.Increment();

}

  

private static bool CreatePerformanceCounters()

{

    if (!PerformanceCounterCategory.Exists("MyCategory"))

    {

        var counters = new CounterCreationDataCollection()

        {

            new CounterCreationData(

                "# operations executed",

                "Total number of operations executed",

                PerformanceCounterType.NumberOfItems32),

  

            new CounterCreationData(

                "# operations / sec",

                "Number of operations executed per second",

                PerformanceCounterType.RateOfCountsPerSecond32),

        };

  

        PerformanceCounterCategory.Create("MyCategory", "Sample category for Codeproject", counters);

  

        return true;

    }

  

    return false;

}

  

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-11-15 12:16:39  
>Last Evernote Update Date: 2016-11-15 12:35:54  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-url: https://www.google.co.uk/webhp?sourceid=chrome-instant  
>source-url: &  
>source-url: ion=1  
>source-url: &  
>source-url: espv=2  
>source-url: &  
>source-url: ie=UTF-8#q=AvergateTimer32  
>source-application: evernote.win32  