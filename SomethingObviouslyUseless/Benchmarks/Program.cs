using System;
using System.IO;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Running;
using Benchmarks.Benchmarks;
using En3Tho.ValueTupleExtensions.CollectionsToValueTupleExtensions;
using En3Tho.ValueTupleExtensions.LinqLikeExtensions;
using En3Tho.ValueTupleExtensions.StringExtensions;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<FirstOrDefaultBenchmark>();
            Console.ReadLine();
        }
    }
}