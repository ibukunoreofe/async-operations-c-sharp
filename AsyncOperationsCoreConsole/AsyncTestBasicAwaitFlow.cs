using System.Diagnostics;

namespace AsyncOperationsCoreConsole
{
    internal class AsyncTestBasicAwaitFlow
    {
        public void Start()
        {
            // Create a Stopwatch instance
            Stopwatch stopwatch = new();

            // Start the stopwatch
            stopwatch.Start();

            // Call the function you want to time
            Task.WaitAll(Run1(), Run3());

            // Stop the stopwatch
            stopwatch.Stop();

            // Get the elapsed time
            TimeSpan elapsedTime = stopwatch.Elapsed;

            // Display the elapsed time in milliseconds
            Console.WriteLine($"Time taken: {elapsedTime.TotalMilliseconds} milliseconds");
        }

        public async Task Run1()
        {
            await Task.Run(() => "Run1".WasteTimeOn());
            // TODO: How to pass this Run2 task as return so that the caller can monitor when it is finished without me blocking it here
            // It should run total of 6 secs not 4 secs without awaiting
            // Run1 takes total of 6s including Run2 sub task
            // Run3 runs parrallel of 4s
            //  Run2(1500);
            
            // It is necessary to await all subtasks else the flow will continue without waiting
            await Run2(1500);
        }

        public async Task Run2(int run1Result)
        {
            await Task.Run(() => $"Run2 3secs After Run1 Completion:=> {run1Result}".WasteTimeOn());
        }

        public async Task Run3()
        {
            //await Task.Run(() => "Run3 - Should complete 3s after Run2".WasteTimeOn(9000) );
            await Task.Run(() => "Run3 - Should complete 1s after Run1".WasteTimeOn(4000) );
        }
    }
}
