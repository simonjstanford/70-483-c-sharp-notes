# Legacy Event-Based Threading

To thread, use BackgroundWorker. Drag the control onto the form, go to it's event (lightening bolt in properties window) and double click all 3 to make the events.  `DoWork` is for the separate thread, `ProgressChanged` is to update a progress bar and `RunWorkerCompeted` lets you run code in the main thread after the background thread has finished:

```csharp
namespace threadingExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //method that needs threading
        private void WasteCPUCycles()
        {
            DateTime startTime = DateTime .Now;
            double value = Math .E;
            while (DateTime .Now < startTime.AddMilliseconds(100))
            {
                value *= Math.Sqrt(2);
            }
        }

        //button to start the work
        private void goButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync( new Guy("Bob" , 37, 146));
        }

        //method called by backgroundWorker when started
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // The e.Argument property returns the argument that was passed to RunWorkerAsync()
            Console.WriteLine("Background worker argument: " + (e.Argument ?? "null"));

            // Start wasting CPU cycles
            for (int i = 1; i <= 100; i++)
            {
                WasteCPUCycles();
                // Use the BackgroundWorker.ReportProgress method to report the % complete
                backgroundWorker1.ReportProgress(i);

                // If the BackgroundWorker.CancellationPending property is true, cancel
                if (backgroundWorker1.CancellationPending)
                {
                    Console.WriteLine("Cancelled" );
                    break;
                }
            }
        }

        //method used to updated progress bar
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        //method ran when doWork finished
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Finished" );
        }

        // When the user clicks Cancel, call BackgroundWorker.CancelAsync() to send it a cancel message
        private void cancelButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

    }
}
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTEzMTgxMjQ1NzddfQ==
-->