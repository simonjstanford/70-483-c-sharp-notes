# The Parallel Class

The `Parallel` class lets you split a task into a set of tasks that are executed concurrently:

```csharp
Parallel.For(0, 10, i =>
{
    Console.WriteLine("A" + i.ToString());
    Thread.Sleep(1000);
});

var numbers = Enumerable.Range(0, 10);
Parallel.ForEach(numbers, i =>
{
    Console.WriteLine("B" + i.ToString());
    Thread.Sleep(1000);
});

ParallelLoopResult result = Parallel.For(0, 10, (int i, ParallelLoopState state) =>
{
    Console.WriteLine("C" + i.ToString());
    Thread.Sleep(1000);

    if (i == 5)
    {
        Console.WriteLine("Breaking C");
        state.Break(); //Break means that all running iterations will finish, Stop() terminates everything
    }
});

Console.ReadKey();
```

You can save the outcome of each iteration using interim results and a For or ForEach overload that accepts delegates as arguments that define what to do with the results:

```csharp
public void MakeIt()
{
    string[] words = { "ack", "ook" };

    // Each argument in For() is used to help store the outcome of the asynchronous iterations
    Parallel.ForEach(words,

        //the initial value for the return value of each iteration
        () => string.Empty,

        //delegate that performs the actual work that is done per iteration
        (word, state, interimResult) => interimResult += AddB(word + ", "),

        //delegate that performs the final action. Here, we add the outcome of the iteration to 'result'
        (lastInterimResult) => Console.WriteLine(lastInterimResult)

    );

    Console.Read();
}

public string AddB(string word)
{
    return "b" + word;
}
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbNDA1NDg1ODk4XX0=
-->