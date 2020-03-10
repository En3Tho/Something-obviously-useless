#if !NETSTANDARD2_0

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#pragma warning disable 649

namespace ExtensionsAndStuff.RefStructs
{
    /// <summary>
    /// StructList with size of 128 bytes.
    /// Has 14 on stack elements and an array to continue resizing like List of T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public ref struct MiniList<T> where T : class
    {
        internal const int InnerMaxCount = 14;
        internal const int InnerMaxIndex = InnerMaxCount - 1;
        internal const int ArrayShift = InnerMaxCount;

        public int Count { get; private set; }
        private int _arrayIndex;
        internal T[] _array;
        internal T _value0;
        #region otherValues
        internal T _value1;
        internal T _value2;
        internal T _value3;
        internal T _value4;
        internal T _value5;
        internal T _value6;
        internal T _value7;
        internal T _value8;
        internal T _value9;
        internal T _value10;
        internal T _value11;
        internal T _value12;
        internal T _value13;
        #endregion

        public void Add(T value)
        {
            AddInternal(value);
        }

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => GetInternal(index);
        }

        private void CheckIndex(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private T GetInternal(int index)
        {
            CheckIndex(index);
            return index > InnerMaxIndex ? _array[index - ArrayShift] : Unsafe.Add(ref _value0, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void AddInternal(T value)
        {
            if (Count < InnerMaxCount) Unsafe.Add(ref _value0, Count) = value; // TODO check for a faster way to access struct element via index
            else if (_array != null && _arrayIndex < _array.Length) _array[_arrayIndex++] = value;
            else ResizeArray(value);
            Count++;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void ResizeArray(T value)
        {
            if (_array == null)
                _array = new T[8];
            else
                Array.Resize(ref _array, _array.Length * 2);

            _array[_arrayIndex++] = value;
        }

        public T[] ToArray()
        {
            if (Count == 0) return Array.Empty<T>();
            var result = new T[Count];
            var spanLength = Math.Min(Count, InnerMaxCount);
            MemoryMarshal.CreateReadOnlySpan(ref _value0, spanLength).CopyTo(result);
            if (Count > InnerMaxCount)
                Array.Copy(_array, 0, result, spanLength, _array.Length);
            return result;
        }
    }
}

#endif