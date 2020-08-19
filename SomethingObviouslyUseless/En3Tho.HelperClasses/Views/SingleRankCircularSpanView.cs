using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses.Views
{
    public ref struct SingleRankCircularSpanView<T>
    {
        private int _current;
        public readonly int Length => Values.Length;
        public readonly Span<T> Values;

        public SingleRankCircularSpanView(Span<T> values, int current = 0)
        {
            Values = values;
            _current = current;
        }

        public ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref Values[index % Length];
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