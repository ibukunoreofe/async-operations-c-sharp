using System.Diagnostics;

namespace AsyncOperationsCoreConsole
{
    internal class AsyncTestTimeUsageDifference
    {
        public void RunSync()
        {
            // Create a Stopwatch instance
            Stopwatch stopwatch = new Stopwatch();

            // Start the stopwatch
            stopwatch.Start();

            // Call the function you want to time
            StaticBusyFunctions.WasteTimeOn(GetType().Name + "-1", 3000);
            StaticBusyFunctions.WasteTimeOn(GetType().Name + "-2", 3000);

            // Stop the stopwatch
            stopwatch.Stop();

            // Get the elapsed time
            TimeSpan elapsedTime = stopwatch.Elapsed;

            // Display the elapsed time in milliseconds
            Console.WriteLine($"Time taken: {elapsedTime.TotalMilliseconds} milliseconds");
        }

        public void RunASync()
        {
            // Create a Stopwatch instance
            Stopwatch stopwatch = new Stopwatch();

            // Start the stopwatch
            stopwatch.Start();

            // Call the function you want to time
            Task.WaitAll(
                 Task.Run(() => StaticBusyFunctions.WasteTimeOn(GetType().Name + "-1", 3000)),
                 Task.Run(() => StaticBusyFunctions.WasteTimeOn(GetType().Name + "-2", 3000))
                );
            
            // Stop the stopwatch
            stopwatch.Stop();

            // Get the elapsed time
            TimeSpan elapsedTime = stopwatch.Elapsed;

            // Display the elapsed time in milliseconds
            Console.WriteLine($"Time taken: {elapsedTime.TotalMilliseconds} milliseconds");
        }
    }
}
