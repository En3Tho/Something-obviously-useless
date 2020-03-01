using System;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.RefStructs.SpanList
{
    public ref struct SpanHeapList<T>
    {
        private readonly Span<T> _sourceSpan;
        private Span<T> _localSpan;
        private int _localIndex;
        public int Count { get; private set; }

        public SpanHeapList(Span<T> span)
        {
            _sourceSpan = span;
            _localSpan = span;
            Count = 0;
            _localIndex = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(T value)
        {
            AddInternal(value);
        }

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => index < _sourceSpan.Length ? _sourceSpan[index] : _localSpan[index - _sourceSpan.Length];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void AddInternal(T value)
        {
            if (_localIndex >= _localSpan.Length)
                CreateAndAddToResizeable();

            _localSpan[_localIndex++] = value;
            Count++;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void CreateAndAddToResizeable()
        {
            if (_localSpan.Length == 0)
            {
                _localSpan = new T[_sourceSpan.Length];
                _localIndex = 0;
            }
            else
            {
                var copy = new T[_localSpan.Length * 2];
                _localSpan.CopyTo(copy);
                _localSpan = copy;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanContainer Slice()
        {
            return Count > _sourceSpan.Length
                ? new SpanContainer(_sourceSpan, _localSpan.Slice(0, Count - _sourceSpan.Length))
                : new SpanContainer(_sourceSpan.Slice(0, Count), Span<T>.Empty);
        }

        public ref struct SpanContainer
        {
            public SpanContainer(Span<T> sourceSpan, Span<T> arraySpan)
            {
                SourceSpan = sourceSpan;
                ArraySpan = arraySpan;
            }

            public Span<T> SourceSpan { get; }
            public Span<T> ArraySpan { get; }
        }
    }

    public static class SpanHeapList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanHeapList<T> Create<T>(Span<T> span) where T : class
            => new SpanHeapList<T>(span);
    }
}