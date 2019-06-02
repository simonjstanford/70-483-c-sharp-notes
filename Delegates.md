# Delegates

A simple delegate example:

  

public delegate int Calculate(int x, int y);

  

public int Add(int x, int y)

{

    return x + y;

}

  

public int Multiply(int x, int y)

{

    return x * y;

}

  

public void UseDelegate()

{

    Console.WriteLine("Simple Delegate Example");

  

    Calculate calc = Add;

    Console.WriteLine(calc(3, 4));

  

    calc = Multiply;

    Console.WriteLine(calc(3, 4));

  

    Console.WriteLine("");

}

  

Multicasting:

  

public delegate void Print();

  

public void MethodOne()

{

    Console.WriteLine("MethodOne");

}

  

public void MethodTwo()

{

    Console.WriteLine("MethodTwo");

}

  

public void UseDelegate()

{

    Console.WriteLine("Multicasting Delegate Example");

  

    Print print = MethodOne;

    print += MethodTwo; //Use -= to remove

  

    foreach (var item in print.GetInvocationList())

    {

        Console.WriteLine(item.ToString());

    }

  

    print();

  

    Console.WriteLine();

}

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-12-20 13:23:10  
>Last Evernote Update Date: 2016-12-20 13:41:48  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  