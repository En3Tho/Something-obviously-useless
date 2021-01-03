using System.Collections.Generic;
using System.Diagnostics;

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
            get => Values[index % Length];
            set => Values[index % Length] = value;
        }

        public T Current => Values[_current];

        public void Write(T item)
        {
            var current = (_current + 1) % Length;
            Values[current] = item;
            _current = current;
        }
    }
}