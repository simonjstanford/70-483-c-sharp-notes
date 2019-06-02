#  Await

The async keyword means that the compiler will transform a method into a state
machine. It allows you to write a method that looks synchronous but behaves
asynchronously. They throw an AggregateException when there's an error.

  

static void Main(string[] args)

{

    string result = AccessTheWebAsync().Result;

    Console.WriteLine("hello1");

    Console.WriteLine(result);

    Console.WriteLine("hello2");

    Console.ReadKey();

}

  

// Three things to note in the signature:

//  \- The method has an async modifier.

//  \- The return type is Task or Task<T>. (See "Return Types" section.)

//    Here, it is Task<int> because the return statement returns an integer.

//  \- The method name ends in "Async."

static async Task<string> AccessTheWebAsync()

{

    Thread.Sleep(5000);

  

    // You need to add a reference to System.Net.Http to declare client.

    HttpClient client = new HttpClient();

  

    // GetStringAsync returns a Task<string>. That means that when you await the

    // task you'll get a string (urlContents).

    Task<string> getStringTask = client.GetStringAsync("http://www.microsoft.com");

  

    // The await operator suspends AccessTheWebAsync.

    //  \- AccessTheWebAsync can't continue until getStringTask is complete.

    //  \- Meanwhile, control returns to the caller of AccessTheWebAsync.

    //  \- Control resumes here when getStringTask is complete.

    //  \- The await operator then retrieves the string result from getStringTask.

    string urlContents = await getStringTask;

  

    // The return statement specifies an integer result.

    // Any methods that are awaiting AccessTheWebAsync retrieve the length value.

    return urlContents;

}

  

static async void SaveSomethingAsync()

{

    var client = new HttpClient();

  

    //ConfigureAwait(false) means that this method wont try to return to the calling thread after it's finished

    string content = await client.GetStringAsync("http://www.microsoft.com").ConfigureAwait(false);

  

    using (var stream = new FileStream("temp.html", FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true))

    {

        byte[] encodedText = Encoding.Unicode.GetBytes(content);

        await stream.WriteAsync(encodedText, 0, encodedText.Length).ConfigureAwait(false);

    }

}

  

When there are several tasks that need awaiting you can await WhenAll:

  

private async Task GetDataAsync()

{

     var task1 = ReadDataFromIOAsync();

     var task2 = ReadDataFromIOAsync();

  

     await Task.WhenAll(task1, task2);

  

     //do stuff with task1.Result and task2.Result

}

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-11-18 12:52:02  
>Last Evernote Update Date: 2016-12-29 15:11:44  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  