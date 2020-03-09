using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExtensionsAndStuff.RefStructs.SpanList
{
    public ref struct SpanList<T>
    {
        private Span<T> Span { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }
        public int Count { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; private set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanList(Span<T> span)
        {
            Span = span;
            Count = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(T value)
        {
            Span[Count++] = value;
        }

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Span[index];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> Slice() => Span.Slice(0, Count);
    }

    public static class SpanList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanList<T> Create<T>(Span<T> span) => new SpanList<T>(span);
    }

}
