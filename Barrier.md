# Barrier

**Barrier**

This is used when you have several threads and you want to make sure they all
arrive at a certain point before continuing execution.

  

![noteattachment1][d807c9be7d68777bc2328c256e75360a]

![noteattachment2][a15bb78aa815bdb2cebffe90db467f6c]

  

![noteattachment3][33a13ec97e4a74207c24baff681db978]

  

Example of usage:

  

var participants = 5;

  

Barrier barrier = new Barrier(participants + 1, // We add one for the main
thread.

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

  

Console.WriteLine("Main thread is waiting for {0} tasks!",
barrier.ParticipantsRemaining - 1);

barrier.SignalAndWait(); // Waiting at the first phase

barrier.SignalAndWait(); // Waiting at the second phase

Console.WriteLine("Main thread is done!");


---
### ATTACHMENTS
[33a13ec97e4a74207c24baff681db978]: media/Barrier.png
[Barrier.png](media/Barrier.png)
[a15bb78aa815bdb2cebffe90db467f6c]: media/Barrier-2.png
[Barrier-2.png](media/Barrier-2.png)
[d807c9be7d68777bc2328c256e75360a]: media/Barrier-3.png
[Barrier-3.png](media/Barrier-3.png)
---
### NOTE ATTRIBUTES
>Created Date: 2016-12-29 15:57:10  
>Last Evernote Update Date: 2016-12-29 15:57:21  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  