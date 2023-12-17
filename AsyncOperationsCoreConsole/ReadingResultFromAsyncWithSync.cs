using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncOperationsCoreConsole
{
    public class ReadingResultFromAsyncWithSync
    {
        public static void Main()
        {
            // Call the asynchronous method from a synchronous method using await
            string result = SynchronousMethod().Result;

            Console.WriteLine("Result from the async method: " + result);
        }

        static async Task<string> SynchronousMethod()
        {
            // Call the asynchronous method using await
            string result = await AsyncMethod();
            return result;
        }

        static async Task<string> AsyncMethod()
        {
            // Simulate some asynchronous work
            await Task.Delay(200);
            return "Async method result";
        }
    }
}
