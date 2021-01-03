#if !NETSTANDARD2_0

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ExtensionsAndStuff.ReferenceStackAllocation;

namespace ExtensionsAndStuff.RefStructs.SpanList
{
    public ref struct StackList32<T> where T : class
    {
        private readonly ReferenceValueHolder32<T> _values;
        private readonly Span<T> _span;
        
        public int Count { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; private set; }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StackList32(IEnumerable<T> values)
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