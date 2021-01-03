using System;

namespace En3Tho.HelperClasses.Views
{
    public ref struct SpanDictionaryView<T>
    {
        private readonly Span<int> _buckets;
        private readonly Span<T> _items;

        public int Count { get; private set; }

        public SpanDictionaryView(Span<int> buckets, Span<T> items, bool clear = false)
        {
            _buckets = buckets;
            _items = items;
            Count = 0;

            if (clear)
            {
                _buckets.Clear();
                _items.Clear();
            }
        }

        // copy Dictionary logic w/o resizing
    }
}