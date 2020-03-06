using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Running;
using Benchmarks.Benchmarks;
using ExtensionsAndStuff.ReferenceStackAllocation;
using ExtensionsAndStuff.RefStructs.SpanList;
using ExtensionsAndStuff.Unsafe.SpanExtensions;
using ExtensionsAndStuff.Unsafe.SpanHeapListExtensions;
using ExtensionsAndStuff.ValueTupleExtensions;

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
