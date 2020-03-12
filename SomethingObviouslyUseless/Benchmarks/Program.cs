using System;
using BenchmarkDotNet.Running;
using Benchmarks.Benchmarks;
using ExtensionsAndStuff.BaseTypesExtensions;
using ExtensionsAndStuff.ValueTupleExtensions;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ContainsBenchmark>();
            Console.ReadLine();
        }
    }
}
