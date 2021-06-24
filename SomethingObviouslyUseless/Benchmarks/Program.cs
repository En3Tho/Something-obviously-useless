using BenchmarkDotNet.Running;
using System;
using Benchmarks.Benchmarks;

#nullable enable

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<PInvokeBenchmark>();
            Console.ReadLine();
        }
    }
}