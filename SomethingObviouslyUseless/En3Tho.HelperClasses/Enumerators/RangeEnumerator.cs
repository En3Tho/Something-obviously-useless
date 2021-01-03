#if (!NETSTANDARD2_0)

using System;

namespace En3Tho.HelperClasses.Enumerators
{
    public static class RangeExtensions
    {
        public static RangeEnumerator GetEnumerator(this Range range) => new RangeEnumerator(range);
        
        public ref struct RangeEnumerator
        {
            private readonly int _start;
            private readonly int _length;
            private int _count;
            public RangeEnumerator(Range range)
            {
                var (offset, length) = range.GetOffsetAndLength(int.MaxValue);
                (Current, _start, _length, _count) = (offset - 1, offset - 1, length, 0);
            }

            public bool MoveNext()
            {
                bool result;
                (result, _count, Current) = (_count < _length, _count + 1, Current + 1);
                return result;
            }

            public void Reset() => (Current, _count) = (_start, 0);

            public int Current { get; private set; }

            public void Dispose() { }
        }
    }
}

#endif