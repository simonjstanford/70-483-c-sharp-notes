# Asynchronous Streams
You can use async/await for using a `FileStream` asynchronously. Note the bool switch that is passed through to the `FileStream` constructor to make it asynchronous.

```csharp
static void Main(string[] args)
{
    var task = CreateAndWriteAsyncToFile();
    task.ContinueWith((i) =>
    {
        Console.WriteLine("Write done!");
    });
    Console.WriteLine("Do more stuff!");
    Console.Read();
}

public static async Task CreateAndWriteAsyncToFile()
{
    using (FileStream stream = new FileStream("test.dat", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
    {
        byte[] data = new byte[100000];
        new Random().NextBytes(data);
        await stream.WriteAsync(data, 0, data.Length);
    }
}
```

Or use a method that returns a `Task<T>` object with the result of the asynchronous call. Here, you can use the await keyword to execute the call asynchronously and then return to it on completion.

```csharp
static void Main(string[] args)
{
    var task = ReadStringAsync();
    Console.WriteLine("Do more stuff!");
    Console.Read();
}

public static async Task ReadStringAsync()
{
    HttpClient client = new HttpClient();
    string result = await client.GetStringAsync("http://www.microsoft.com");
    Console.WriteLine(result);
}
```

`WhenAll()` lets you instantiate a number of `Task` objects and then wait for them all to finish. This has a performance advantage as you will only wait for as long as the time taken for the longest task.

```csharp
public static async Task ReadStringAsync2()
{
    HttpClient client = new HttpClient();

    //here each web request starts when the next one finishes
    var microsoftString = await client.GetStringAsync("http://www.microsoft.com");
    var msdnString = await client.GetStringAsync("http://msdn.microsoft.com");
    var blogString = await client.GetStringAsync("http://blog.msdn.com");

    //here WhenAll() means that all web requests are executed in parallel
    Task microsoft = client.GetStringAsync("http://www.microsoft.com");
    Task msdn = client.GetStringAsync("http://msdn.microsoft.com");
    Task blog = client.GetStringAsync("http://blog.msdn.com");

    await Task.WhenAll(microsoft, msdn, blog);
}
```

<!--stackedit_data:
eyJoaXN0b3J5IjpbLTk4NjAwNDgzOF19
-->