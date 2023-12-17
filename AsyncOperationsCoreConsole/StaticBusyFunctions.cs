using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncOperationsCoreConsole
{
    internal static class StaticBusyFunctions
    {
        // Synchronous method
        public static void WasteTimeOn( this string id, int timeDelayMs = 3000)
        {
            Console.WriteLine($"\nStart Operation on {id}");
            // Perform some time-consuming operation
            Thread.Sleep(timeDelayMs);
            Console.WriteLine($"\nEnd Operation on {id}");
        }
    }
}
