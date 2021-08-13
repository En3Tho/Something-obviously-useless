using BenchmarkDotNet.Attributes;

namespace Benchmarks.Benchmarks
{
    [DisassemblyDiagnoser]
    public class PossiblyEmptyMethodBench
    {
        public int X { get; set; }
        public int Y { get; set; }

        [Benchmark]
        public void TestXPlusY()
        {
            var z = X + Y;
        }
    }
}