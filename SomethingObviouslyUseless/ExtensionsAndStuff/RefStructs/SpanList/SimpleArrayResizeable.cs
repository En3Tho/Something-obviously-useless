using System;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.RefStructs.SpanList
{
    internal class SimpleArrayResizeable<T> : IResizeable<T> where T : class
    {
        private int count;
        private T[] _array;

        public SimpleArrayResizeable()
        {
            _array = new T[8];
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void AddWithResize(T value)
        {
            Array.Resize(ref _array, _array.Length * 2);
            _array[count++] = value;
        }

        public void Add(T value)
        {
            if (count < _array.Length)
                _array[count++] = value;
            else
                AddWithResize(value);
        }

        public T this[int index] => _array[index];

        public T[] ToArray()
        {
            if (count == 0) return Array.Empty<T>();
            var result = new T[count];
            Array.Copy(_array, 0, result, 0, count);
            return result;
        }

        public void CopyTo(T[] array, int start)
        {
            Array.Copy(_array, 0, array, start, count);
        }
    }
}