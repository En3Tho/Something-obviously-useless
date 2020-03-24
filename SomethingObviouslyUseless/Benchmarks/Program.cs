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
    }
}