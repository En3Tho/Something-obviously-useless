using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;

namespace ExtensionsAndStuff.RefStructs.SpanList
{
    internal class JaggedArrayResizeable<T> // TODO : ref
    {
        private const int BaseLocalArrayLength = 8;
        private const int MaxChunkIndexStartAt = 7;
        private const int MaxChunkSize = 512;
        private const uint MaxCountBeforeMaxChunkSize = 1016;

        public int Count { get; private set; }
        private int _globalIndex;
        private int _localIndex;
        private T[][] _arrays;

        public JaggedArrayResizeable()
        {
            _arrays = new[] {new T[BaseLocalArrayLength]};
        }

        public void Add(T value)
        {
            if (_globalIndex < _arrays.Length)
            {
                var _inner = _arrays[_globalIndex]; // TODO: check globalArray != null
                if (_localIndex < _inner.Length)
                {
                    _inner[_localIndex] = value;
                    _localIndex = (_localIndex + 1) % _inner.Length;
                    _globalIndex += (_localIndex == 0 ? 1 : 0);
                }
            }
            else
                AddWithResize(value);

            Count++;
        }

        public T this[int index]
        {
            get
            {
                if (index < BaseLocalArrayLength)
                    return _arrays[0][index];
                if (index < MaxCountBeforeMaxChunkSize)
                {
                    var lzcnt = (int)Lzcnt.LeadingZeroCount((uint)index);
                    int shift = 32 - lzcnt;
                    var shiftResult = MaxCountBeforeMaxChunkSize << shift >> shift;
                    var localIndex = index - shiftResult;
                    var globalIndex = lzcnt - (index == shiftResult || localIndex >= 0 ? 3 : 4);
                    var array = _arrays[globalIndex];
                    return array[localIndex >= 0 ? localIndex : array.Length - localIndex];
                }
                else
                {
                    var indexAfterMax = index - MaxCountBeforeMaxChunkSize;
                    var globalIndex = indexAfterMax % (MaxChunkSize - 1) + MaxChunkIndexStartAt;
                    var localIndex = indexAfterMax - globalIndex * (MaxChunkSize - 1);
                    return _arrays[globalIndex][localIndex];
                }
            }
        }
        
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void AddWithResize(T value)
        {
            Array.Resize(ref _arrays, Math.Min(_arrays.Length * 2, MaxChunkSize));
            _arrays[_globalIndex++][0] = value;
            _localIndex = 1;
        }

        public T[] ToArray()
        {
            if (Count == 0) return Array.Empty<T>();
            var result = new T[Count];
            var remaining = Count;
            foreach (var local in _arrays)
            {
                var written = Math.Min(local.Length, remaining);
                Array.Copy(local, 0, result, 0, written);
                if ((remaining -= written) == 0)
                    break;
            }

            return result;
        }

        public void CopyTo(T[] array, int start)
        {
            if (array.Length - start < Count)
                throw new ArgumentOutOfRangeException(nameof(start));

            var remaining = Count;
            foreach (var local in _arrays)
            {
                var written = Math.Min(local.Length, remaining);
                Array.Copy(local, 0, array, start, written);
                if ((remaining -= written) == 0)
                    break;
                start += written;
            }
        }
    }
}