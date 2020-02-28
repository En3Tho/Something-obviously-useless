using System;

namespace Benchmarks.Classes
{
    public class ParamsHolder
    {
        public object[] ParamsClass(params object[] p)
            => p;

        public Span<object> ParamsTuple(Span<object> t)
            => t;
    }
}