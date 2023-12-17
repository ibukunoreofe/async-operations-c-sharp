using BenchmarkDotNet.Attributes;
using System.Diagnostics;

namespace AsyncOperationsCoreConsole
{
    [ShortRunJob]
    [MemoryDiagnoser]
    public class ParallelTasksExample
    {
        [Benchmark]
        public void Main()
        {
            // Create a Stopwatch instance
            Stopwatch stopwatch = new();

            // Start the stopwatch
            stopwatch.Start();

            // Create an array of tasks
            Task[] tasks = [Task1(), Task2(), Task3()];

            // Use Parallel.ForEach to process tasks in parallel
            Parallel.ForEach(tasks, task =>
            {
                task.Wait(); // Wait for the completion of each task
            });

            Console.WriteLine("All tasks have completed.");

            // Stop the stopwatch
            stopwatch.Stop();

            // Get the elapsed time
            TimeSpan elapsedTime = stopwatch.Elapsed;

            // Display the elapsed time in milliseconds
            Console.WriteLine($"Time taken: {elapsedTime.TotalMilliseconds} milliseconds");
        }

        static async Task Task1()
        {
            Console.WriteLine("Task 1 started");
            await Task.Delay(3000);
            Console.WriteLine("Task 1 completed");
        }

        static async Task Task2()
        {
            Console.WriteLine("Task 2 started");
            await Task.Delay(5000);
            Console.WriteLine("Task 2 completed");
        }

        static async Task Task3()
        {
            Console.WriteLine("Task 3 started");
            await Task.Delay(2000);
            Console.WriteLine("Task 3 completed");
        }
    }
}
