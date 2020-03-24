using System;
using BenchmarkDotNet.Running;
using Benchmarks.Benchmarks;
using Benchmarks.Classes;
using En3Tho.ValueTupleExtensions.LinqToValueTupleExtensions;
using ExtensionsAndStuff.HelperClasses.WorkflowHelpers;
using ExtensionsAndStuff.Linq;
using System.Linq;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<FirstOrDefaultBenchmark>();
            Console.ReadLine();
        }

        static void TryCatch(Action action)
        {
            try { action(); }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
    }
}