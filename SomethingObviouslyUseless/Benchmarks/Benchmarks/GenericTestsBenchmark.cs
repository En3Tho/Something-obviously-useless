using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Benchmarks.Classes;

namespace Benchmarks.BenchmarkDotNet
{
    [SimpleJob(RuntimeMoniker.NetCoreApp31, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    public class GenericTestsBenchmark
    {
        [Benchmark]
        public void GetValueInt()
        {
            GenericTests.GetValue<int>();
        }
        
        [Benchmark]
        public void GetValueString()
        {
            GenericTests.GetValue<string>();
        }
        
        [Benchmark]
        public void GetValueLong()
        {
            GenericTests.GetValue<long>();
        }
    }
}