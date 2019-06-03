# Events

The event keyword develops the idea of
[Delegates](evernote:///view/26944639/s226/e95a2f3e-025d-452c-9170-06f4c5e8fa57/e95a2f3e-025d-452c-9170-06f4c5e8fa57/).

  

In the syntax below, EventHandler is the delegate and BallInPlay is the name
of the event. An event executes the methods subscribed to the delegate and has
added restrictions.

  

public event EventHandler BallInPlay;

  

Using the event keyword means that:

  * The = operator can't be used - only += can be used. This means that something can't overwrite all other event subscriptions. Using +=/-= multiple times on the same method adds/removes the method multiple times. It will be executed more than once!
  * You could use Action<T> or a custom delegate when defining an event. However, EventHandler or EventHandler<T> is used instead as it's defined in the pattern. This is just a delegate with no return type and parameters for the sender and event arguments. Use EventHandler when there is no return value and EventHandler<T> when there is.

  

An event can only be raised by the class that defines it - this means that a
derived class can't even raise the event. This is why events are normally
raised by an 'On' method.

  

Delegates are executed sequentially, but the order is not guaranteed.

  

You can use a _custom event accessor_ to customise addition/removal of
subscribers. This looks a lot like a property:

  

private event EventHandler<MyArgs> onChange = delegate { };

public event EventHandler<MyArgs> OnChange

{

     add

     {

          lock (onChange)

          {

               onChange += value;

               //extra stuff here

          }

     }

     remove

     {

          lock (onChange)

          {

               onChange -= value;

                //extra stuff here

          }

     }

}

 **  
**

  

class Program

{

    static void Main(string[] args)

    {

        Ball ball = new Ball();

        Fan fan = new Fan(ball);

        Pitcher pitcher = new Pitcher(ball);

  

        ball.BallHit(900, 900);

  

        Console.ReadKey();

    }

  

    class Pitcher

    {

        public Pitcher(Ball ball)

        {

               ball.BallInPlay += ball_BallInPlay;

              

               //You can also define it this way

               //ball.BallInPlay += new EventHandler(ball_BallInPlay);

        }

        void ball_BallInPlay(object sender, EventArgs e)

        {

            if (e is BallEventArgs)

            {

                BallEventArgs ballEventArgs = e as BallEventArgs;

                if ((ballEventArgs.Distance < 95) && (ballEventArgs.Trajectory < 60))

                    CatchBall();

                else

                    CoverFirstBase();

            }

        }

  

        private void CoverFirstBase()

        {

            Console.WriteLine("Pitcher: I covered first base");

        }

  

        private void CatchBall()

        {

            Console.WriteLine("Pitcher: I caught the ball");

        }

    }

  

    class Fan

    {

        public Fan(Ball ball)

        {

            ball.BallInPlay += new EventHandler(ball_BallInPlay);

        }

  

        void ball_BallInPlay(object sender, EventArgs e)

        {

            if (e is BallEventArgs)

            {

                BallEventArgs ballEventArgs = e as BallEventArgs;

                if (ballEventArgs.Distance > 400 && ballEventArgs.Trajectory > 30)

                    Console.WriteLine("Fan: Home run! Im going for the ball!");

                else

                    Console.WriteLine("Fan: Woo-hoo! Yeah!");

            }

        }

    }

  

    class Ball

    {

        public event EventHandler BallInPlay;

  

        public void BallHit(int trajectory, int distance)

        {

            BallEventArgs e = new BallEventArgs(trajectory, distance); //create the eventArgs

            EventHandler ballInPlay = BallInPlay; //create the object

            if (ballInPlay != null) //if there are no subcribers then the object will be null

                ballInPlay(this, e); //and finally fire the event.  A reference to itself and the eventArgs are passed.

        }

    }

  

    class BallEventArgs : EventArgs

    {

        public int Trajectory;

        public int Distance;

  

        public BallEventArgs(int trajectory, int distance)

        {

            this.Trajectory = trajectory;

            this.Distance = distance;

        }

    }

  

}

  



---
### TAGS
{Delegates}  {Events}  {Lambda Expressions}  {Contravariance}  {Covariance}

---
### NOTE ATTRIBUTES
>Created Date: 2016-08-20 10:18:35  
>Last Evernote Update Date: 2017-03-16 16:41:03  
>author: simonjstanford@gmail.com  
<!--stackedit_data:
eyJoaXN0b3J5IjpbNzI0Njc2MDQxXX0=
-->