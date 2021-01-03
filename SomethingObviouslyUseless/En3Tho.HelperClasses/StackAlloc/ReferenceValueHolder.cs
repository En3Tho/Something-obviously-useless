#if !NETSTANDARD2_0

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace En3Tho.HelperClasses.StackAlloc
{
    internal ref struct ValueHolder4<T>
    {
        public T _1;
        public T _2;
        public T _3;
        public T _4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _1, 4);
    }

    internal ref struct ValueHolder8<T>
    {
        public ValueHolder4<T> _1;
        public ValueHolder4<T> _2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _1._1, 8);
    }

    internal ref struct ValueHolder16<T>
    {
        public ValueHolder8<T> _1;
        public ValueHolder8<T> _2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _1._1._1, 16);
    }

    internal ref struct ValueHolder32<T>
    {
        public ValueHolder16<T> _1;
        public ValueHolder16<T> _2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _1._1._1._1, 32);
    }

    internal ref struct ValueHolder64<T>
    {
        public ValueHolder32<T> _1;
        public ValueHolder32<T> _2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _1._1._1._1._1, 64);
    }
}

#endif