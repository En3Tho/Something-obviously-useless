using System;
using System.Linq;
using BenchmarkDotNet.Running;
using Benchmarks.Benchmarks;
using ExtensionsAndStuff.ReferenceStackAllocation;
using ExtensionsAndStuff.RefStructs.SpanList;
using ExtensionsAndStuff.Unsafe.SpanExtensions;
using ExtensionsAndStuff.Unsafe.SpanHeapListExtensions;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SpanCopyVsArrayCopy>();

            Console.ReadLine();
        }
    }
}
