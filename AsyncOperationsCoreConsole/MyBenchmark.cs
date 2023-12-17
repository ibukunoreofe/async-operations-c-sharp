using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace BenchmarkExample
{
    [ShortRunJob] 
    [MemoryDiagnoser]
    public class MyBenchmark
    {
        [Benchmark]
        public void StringConcatenation()
        {
            string result = "";
            for (int i = 0; i < 1000; i++)
            {
                result += "x";
            }
        }

        [Benchmark]
        public void StringInterpolation()
        {
            string result = "";
            for (int i = 0; i < 1000; i++)
            {
                result = $"{result}x";
            }
        }

        public static void Run()
        {
            // https://benchmarkdotnet.org/articles/guides/how-to-run.html
            // https://www.youtube.com/watch?v=Wa3sdKGp3wE
            // To run a benchmark, the class must be public not sealed and not static
            // You can use ShortRunJob attribute to reduce the number of runs
            // You can use MemoryDiagnoser to view the memory

            // Also, benchmark methods must be class methods not static

            // Importantly you should Run in Release Mode, without debugging.
            // You can run in VS Studio without debbugging option, light green play button


            // Test 1
            // Using Benchmark
            //using BenchmarkDotNet.Columns;
            //using BenchmarkDotNet.Configs;
            //using BenchmarkDotNet.Loggers;
            //using BenchmarkDotNet.Validators;

            //var config = new ManualConfig()
            //     .WithOptions(ConfigOptions.DisableOptimizationsValidator)
            //     .AddValidator(JitOptimizationsValidator.DontFailOnError)
            //     .AddLogger(ConsoleLogger.Default)
            //     .AddColumnProvider(DefaultColumnProviders.Instance);

            // BenchmarkDotNet.Running.BenchmarkRunner.Run<AsyncOperationsCoreConsole.ParallelTasksExample>(config);
            // BenchmarkDotNet.Running.BenchmarkRunner.Run<AsyncOperationsCoreConsole.ParallelTasksExample>();



            //// Test 2 Benchmarking
            //using BenchmarkDotNet.Running;
            //using BenchmarkExample;

            _ = BenchmarkRunner.Run<MyBenchmark>();

        }
    }
}
