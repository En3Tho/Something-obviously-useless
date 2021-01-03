#if !NETSTANDARD2_0

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses.StackAlloc
{
    public static partial class StackList<T> where T : class
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StackList64 Create64() => new StackList64(0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StackList64 Create64(IEnumerable<T> values) => new StackList64(values);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StackList64 Create64(Span<T> values) => new StackList64(values);

        public ref struct StackList64
        {
            private readonly ValueHolder64<T> _values;
            private readonly Span<T> _span;

            public int Length
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => _span.Length;
            }

            public int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get;
                private set;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal StackList64(int placeholder)
            {
                _values = default;
                _span = _values.AsSpan();
                Count = 0;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal StackList64(IEnumerable<T> values)
            {
                _values = default;
                Count = 0;
                _span = _values.AsSpan();
                AddRange(values);
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal StackList64(Span<T> values)
            {
                _values = default;
                Count = 0;
                _span = _values.AsSpan();
                AddRange(values);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void AddRange(Span<T> values)
            {
                foreach (var value in values)
                {
                    Add(value);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void AddRange(IEnumerable<T> values)
            {
                foreach (var value in values)
                {
                    Add(value);
                }
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
}

#endif