using BenchmarkDotNet.Attributes;
using Benchmarks.Classes;
using ExtensionsAndStuff.ValueTupleExtensions;

namespace Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    public class TupleVsArrayParams
    {
        public ParamsHolder Holder { get; } = new ParamsHolder();
        
        [Benchmark]
        public void CallParamsClass()
        {
            Holder.ParamsClass(new object(), new object(), new object(), new object(), new object(), new object(), new object());
        }
        
        [Benchmark]
        public  void CallParamsTuple()
        {
            Holder.ParamsTuple((new object(), new object(), new object(), new object(), new object(), new object(), new object()).AsSpan());
        }
    }
}