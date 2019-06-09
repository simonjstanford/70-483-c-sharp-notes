# Barrier

This is used when you have several threads and you want to make sure they all arrive at a certain point before continuing execution.






Example of usage:

```csharp
var participants = 5;

Barrier barrier = new Barrier(participants + 1, // We add one for the main thread.
    b => { //this is executed when all active participants have signalled
        Console.WriteLine("{0} paricipants are at rendez-vous point {1}.",
                        b.ParticipantCount - 1, // We substract the main thread .
                        b.CurrentPhaseNumber);
    });

for (int i = 0; i < participants; i++) {
    var localCopy = i;
    Task.Run(() => {
        Console.WriteLine("Task {0} left point A!", localCopy);
        Thread.Sleep(1000 * localCopy + 1); // Do some "work"
        if (localCopy % 2 == 0) {
            Console.WriteLine("Task {0} arrived at point B!", localCopy);
            barrier.SignalAndWait();
        }
        else {
            Console.WriteLine("Task {0} changed its mind and went back!", localCopy);
            barrier.RemoveParticipant();
            return;
        }
        Thread.Sleep(1000 * (participants - localCopy));
        Console.WriteLine("Task {0} arrived at point C!", localCopy);
        barrier.SignalAndWait();
    });
}

Console.WriteLine("Main thread is waiting for {0} tasks!", barrier.ParticipantsRemaining - 1);
barrier.SignalAndWait(); // Waiting at the first phase
barrier.SignalAndWait(); // Waiting at the second phase
Console.WriteLine("Main thread is done!");
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTMwNzkzNDQxOV19
-->