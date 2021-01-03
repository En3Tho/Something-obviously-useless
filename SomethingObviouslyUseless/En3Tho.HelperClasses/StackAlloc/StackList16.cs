#if !NETSTANDARD2_0

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses.StackAlloc
{
    public ref struct StackList16<T>
    {
        private readonly ValueHolder16<T> _values;
        private readonly Span<T> _span;
        
        public int Length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _span.Length;
        }
        
        public int Count { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; private set; }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StackList16(IEnumerable<T> values)
        {
            _values = default;
            Count = 0;
            _span = _values.AsSpan();
            foreach (var value in values)
                Add(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(T value)
        {
            _span[Count++] = value;
        }

        public ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref _span[index];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> Slice() => _span.Slice(0, Count);
    }
}

#endif