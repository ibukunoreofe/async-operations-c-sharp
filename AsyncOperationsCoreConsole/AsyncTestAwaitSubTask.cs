using System.Diagnostics;

namespace AsyncOperationsCoreConsole
{
    internal class AsyncTestAwaitSubTask
    {
        public static async Task Main()
        {
            // Create a Stopwatch instance
            Stopwatch stopwatch = new();

            // Start the stopwatch
            stopwatch.Start();

            // Create an array of tasks
            Task[] tasks = { Task1(), Task2(), Task3() };

            // Use await with Task.WhenAll to asynchronously wait for all tasks to complete
            await Task.WhenAll(tasks);

            // Expected time consumption should be 5secs
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

            // Subtask without await
            Task subTask = SubTaskWithoutAwait();

            // Continue with some other work while subTask is running
            Console.WriteLine("Task 3 is doing some other work while subTask is running...");

            // Await for subTask to complete before finishing Task3
            await subTask;

            Console.WriteLine("Task 3 completed");
        }

        static Task SubTaskWithoutAwait()
        {
            return Task.Delay(2000);
        }
    }
}
