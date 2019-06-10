# Parallel LINQ (PLINQ)

Parallel LINQ (PLINQ) is a way to execute a LINQ query in multiple threads:

  

Console.WriteLine("performs a parallel query if it needs to");

var numbers = Enumerable.Range(0, 10);

var parallelResult = numbers.AsParallel().Where(i => i % 2 == 0).ToArray();

  

foreach (var item in parallelResult)

{

    Console.WriteLine(item);

}

  

Console.ReadKey();

  

Console.WriteLine("always performs a parallel query");

var parallelResult2
.rs.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism).Where(i
=> i % 2 == 0).ToArray();

  

foreach (var item in parallelResult2)

{

    Console.WriteLine(item);

}

  

Console.ReadKey();

  

Console.WriteLine("choose the max number of cores that will be used");

var parallelResult3 = numbers.AsParallel().WithDegreeOfParallelism(2).Where(i
=> i % 2 == 0).ToArray();

  

foreach (var item in parallelResult3)

{

    Console.WriteLine(item);

}

  

Console.ReadKey();

  

Console.WriteLine("the above results are returned in any order. If you want to
sort the results then use the AsOrdered operator");

var parallelResult4 = numbers.AsParallel().AsOrdered().Where(i => i % 2 ==
0).ToArray();

  

foreach (var item in parallelResult4)

{

    Console.WriteLine(item);

}

  

Console.ReadKey();

  

Console.WriteLine("AsSequential() is used to change a subcomponent of a query
from parallel to sequential");

var parallelResult5 = numbers.AsParallel().AsOrdered().Where(i => i % 2 ==
0).AsSequential().Take(2);

  

foreach (var item in parallelResult5)

{

    Console.WriteLine(item);

}

  

Console.ReadKey();

  

Console.WriteLine("ForAll() allows parallel iteration of a collection but
ignores any ordering");

//remember that LINQ is lazy and only executes when it needs to!

var parallelResult6 = numbers.AsParallel().Where(i => i % 2 == 0);

parallelResult6.ForAll(x => Console.WriteLine(x));

  

Console.WriteLine("Exceptions are aggregrated into AggregateException ");

try

{

    var parallelResult7 = numbers.AsParallel().Where(i => i % 2 == 0);

    parallelResult7.ForAll(x => Console.WriteLine(x));

}

catch (AggregateException e)

{

    Console.WriteLine("There were {0} exceptions", e.InnerExceptions.Count);

}

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-11-18 12:58:54  
>Last Evernote Update Date: 2017-04-10 13:56:49  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTIzMjU1NDY3NV19
-->