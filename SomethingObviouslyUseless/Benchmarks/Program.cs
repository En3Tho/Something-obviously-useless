using BenchmarkDotNet.Running;
using Benchmarks.BenchmarkDotNet;
using En3Tho.ValueTupleExtensions.LinqLikeExtensions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Benchmarks.Benchmarks;
using En3Tho.HelperClasses;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<JsonVsEncodingBenchmarks>();            
            Console.ReadLine();
        }
    }
}