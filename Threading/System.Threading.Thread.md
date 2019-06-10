# System.Threading.Thread

System.Threading.Thread

  

You can use Thread.Abort() to stop a thread, but it is executed in another
thread so can happen any time. It throws a ThreadAbortException and so can
leave an application unusable so it's better to have a shared variable that is
set/read in different threads.

  

Basic threading:

  

public static void ThreadMethod_1()

{

    for (int i = 0; i < 10; i++)

    {

        Console.WriteLine("ThreadProc 1: {0}", i);

  

        //signals that a thread has finished so windows doesn't wait for the time slice to finish.

        Thread.Sleep(0);

    }

}

  

public static void ThreadMethod_2(object o)

{

    for (int i = 0; i < (int)o; i++)

    {

        Console.WriteLine("ThreadProc 2: {0}", i);

  

        //signals that a thread has finished so windows doesn't wait for the time slice to finish.

        Thread.Sleep(0);

    }

}

  

static void Main(string[] args)

{

    bool stopped = false;

  

    Thread t = new Thread(new ThreadStart(ThreadMethod_1));

    t.Start();

  

    Thread t2 = new Thread(new ParameterizedThreadStart(ThreadMethod_2)); //use ParameterizedThreadStart to pass in parameters

    t2.IsBackground = false; t.IsBackground = false; //set to false to make the application wait until t has finished before closing (without relying on t.Join())

    t2.Start(50);

  

    //this thread is initialised with a lambda expression and keeps running until stopped is 'true'

    Thread t3 = new Thread(new ThreadStart(() =>

    {

        while (!stopped)

        {

            Console.WriteLine("Running...");

            Thread.Sleep(10);

        }

    }));

  

    for (int i = 0; i < 4; i++)

    {

        Console.WriteLine("Main thread: Do some work.");

        Thread.Sleep(0);

    }

  

    t.Join(); //wait for the thread to finish

    t3.Join();

  

    Console.ReadKey();

}

  

  

  

  

  

  

  

  

  

  

  

  

  

  

  



---
### TAGS
{Threading}

---
### NOTE ATTRIBUTES
>Created Date: 2016-08-01 20:21:46  
>Last Evernote Update Date: 2016-12-24 13:54:19  
>author: simonjstanford@gmail.com  
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE5NTQ5NzU0NjhdfQ==
-->