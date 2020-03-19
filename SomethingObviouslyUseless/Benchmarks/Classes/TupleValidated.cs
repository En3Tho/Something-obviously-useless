using ExtensionsAndStuff.ValueTupleExtensions;

namespace Benchmarks.Classes
{
    public class TupleValidated
    {
        public object A { get; }
        public string B { get; }
        public int[] C { get; }
        
        public TupleValidated(object a, string b, int[] c)
            => (A, B, C) = (a, b, c).NullCheck();
    }
}