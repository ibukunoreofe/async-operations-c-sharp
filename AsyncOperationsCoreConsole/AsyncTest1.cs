using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncOperationsCoreConsole
{
    internal class AsyncTest1
    {
        // Synchronous method
        public void DoSomethingSynchronous()
        {
            Console.WriteLine("Start Synchronous Operation");
            // Perform some time-consuming operation
            Thread.Sleep(2000);
            Console.WriteLine("End Synchronous Operation");
        }

        // Asynchronous method
        public async Task DoSomethingAsynchronous()
        {
            Console.WriteLine("Start Asynchronous Operation");
            // Simulate an asynchronous operation
            await Task.Delay(2000);
            Console.WriteLine("End Asynchronous Operation");
        }

        // Example usage
        public void Example()
        {
            DoSomethingSynchronous();
            DoSomethingAsynchronous().Wait(); // Using .Wait() to wait for the asynchronous operation to complete
        }

    }
}
