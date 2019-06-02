# HashSet

A HashSet is unordered but doesn't allow duplicates.

  

HashSet enables many mathematical operations on sets, e.g:

  * UnionWith: Union or set addition
  * IntersectWith: Intersection
  * ExceptWith: Set subtraction
  * SymmetricExceptWith: Symmetric difference

  

static void Main(string[] args)

{

    HashSet<int> oddSet = new HashSet<int>();

    HashSet<int> evenSet = new HashSet<int>();

  

    for (int x = 1; x < 10; x++)

    {

        if (x % 2 == 0)

            evenSet.Add(x);

        else

            oddSet.Add(x);

    }

  

    DisplaySet(oddSet);

    DisplaySet(evenSet);

  

    oddSet.UnionWith(evenSet);

    DisplaySet(oddSet);

  

    Console.Read();

}

  

private static void DisplaySet(HashSet<int> set)

{

    Console.Write("{");

    foreach (var item in set)

    {

        Console.Write(" {0}", item);

    }

    Console.WriteLine(" }");

}

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-12-05 20:54:15  
>Last Evernote Update Date: 2016-12-05 21:04:01  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  