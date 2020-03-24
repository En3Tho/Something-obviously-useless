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
            //BenchmarkRunner.Run<FirstOrDefaultBenchmark>();

            var ints = new[] { 1, 2, 3, 4, 5, 5 };
         
            TryCatch(() => ints.First(x => x == 12));
            TryCatch(() => ints.First(x => x == 5, x => x == 25));
            TryCatch(() => ints.Last(x => x == 12));
            TryCatch(() => ints.Last(x => x == 5, x => x == 12));
            TryCatch(() => ints.Single(x => x == 5));
            TryCatch(() => ints.Single(x => x == 4, x => x == 5));

            Console.ReadLine();
        }

        static void TryCatch(Action action)
        {
            try { action(); }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
    }
}