using System;
using BenchmarkDotNet.Running;
using Benchmarks.Benchmarks;
using En3Tho.ValueTupleExtensions.CollectionsToValueTupleExtensions;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<FirstOrDefaultBenchmark>();
            Array.Empty<int>().Map(x => x, x => x);
            Console.ReadLine();
        }
    }
}