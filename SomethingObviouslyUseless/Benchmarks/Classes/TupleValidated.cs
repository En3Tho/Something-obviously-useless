using En3Tho.ValueTupleExtensions;
using En3Tho.ValueTupleExtensions.OtherExtensions;

namespace Benchmarks.Classes
{
    public class TupleValidated
    {
        public object A { get; }
        public string B { get; }
        public int[] C { get; }
        public int? D { get; }
        public int E { get; }
        
        public TupleValidated(object a, string b, int[] c, int? d, int e)
            => (A, B, C, D, E) = (a, b, c, d, e).NullCheck();
    }
}