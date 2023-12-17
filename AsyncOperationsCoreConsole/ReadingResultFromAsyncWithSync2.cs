using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncOperationsCoreConsole
{
    public class ReadingResultFromAsyncWithSync2
    {
        public static void Main()
        {
            // Call the asynchronous method from a synchronous method
            Task<string> asyncTask = Task.Run(AsyncMethod);

            // Wait for the asynchronous method to complete and get the result
            string result = asyncTask.Result;

            Console.WriteLine("Result from the async method: " + result);
        }

        static async Task<string> AsyncMethod()
        {
            // Simulate some asynchronous work
            await Task.Delay(200);
            return "Async method result";
        }
    }
}
