using System;

namespace En3Tho.HelperClasses.Views
{
    public ref struct SpanListView<T>
    {
        private readonly Span<T> _values;

        public int Count
        {
            get;
            private set;
        }

        public int Length => _values.Length;

        public SpanListView(Span<T> values)
        {
            _values = values;
            Count = 0;
        }

        public SpanListView(Span<T> values, int count)
        {
            if ((uint)count > values.Length)
                ThrowHelper.ThrowArgumentOutOfRangeException(nameof(Count));
            
            _values = values;
            Count = count;
        }

        public Span<T> Slice() => _values.Slice(Count);

        public void Add(T value) => _values[Count++] = value;

        public void AddRange(Span<T> values)
        {
            if (values.Length + Count > _values.Length)
                ThrowHelper.ThrowArgumentOutOfRangeException(nameof(Count));

            values.CopyTo(_values.Slice(Count));
            Count += values.Length;
        }

        public ref T this[int index] => ref _values[index];
    }
}