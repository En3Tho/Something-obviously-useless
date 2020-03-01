using System;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.RefStructs.SpanList
{
    public ref struct SpanHeapList<T> where T : class
    {
        public Span<T> Span { get; }
        public int Count { get; private set; }
        private SimpleArrayResizeable<T> _resizeable;

        public SpanHeapList(Span<T> span)
        {
            Span = span;
            Count = 0;
            _resizeable = null;
        }

        public void Add(T value)
        {
            AddInternal(value);
        }

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => index < Span.Length ? Span[index] : _resizeable[index - Span.Length];
        }

        private void AddInternal(T value)
        {
            if (Count < Span.Length)
                Span[Count] = value;
            else if (_resizeable != null)
                _resizeable.Add(value);
            else
                CreateAndAddToResizeable(value);

            Count++;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void CreateAndAddToResizeable(T value)
        {
            _resizeable = new SimpleArrayResizeable<T>();
            _resizeable.Add(value);
        }
    }

    public static class SpanHeapList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanHeapList<T> Create<T>(Span<T> span) where T : class
            => new SpanHeapList<T>(span);
    }
}