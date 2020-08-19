using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses.Views
{
    public ref struct SingleRankCircularIListView<T>
    {
        private int _current;
        public readonly int Length;
        public readonly IList<T> Values;

        public SingleRankCircularIListView(IList<T> values, int length, int current = 0)
        {
            Debug.Assert(values.Count <= length);
            Values = values;
            Length = length;
            _current = current;
        }

        public SingleRankCircularIListView(IList<T> values, int current = 0) : this(values, values.Count, current) { }

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Values[index % Length];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Values[index & Length] = value;
        }

        public T Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Values[_current];
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Write(T item)
        {
            var current = (_current + 1) % Length;
            Values[current] = item;
            _current = current;
        }
    }
}