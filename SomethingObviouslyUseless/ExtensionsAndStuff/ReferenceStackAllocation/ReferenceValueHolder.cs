using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ExtensionsAndStuff.ReferenceStackAllocation
{
    public ref struct ReferenceValueHolder4<T> where T : class
    {
        public T _1;
        public T _2;
        public T _3;
        public T _4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _1, 4);
    }

    public ref struct ReferenceValueHolder8<T> where T : class
    {
        public ReferenceValueHolder4<T> _1;
        public ReferenceValueHolder4<T> _2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _1._1, 8);
    }

    public ref struct ReferenceValueHolder16<T> where T : class
    {
        public ReferenceValueHolder8<T> _1;
        public ReferenceValueHolder8<T> _2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _1._1._1, 16);
    }

    public ref struct ReferenceValueHolder32<T> where T : class
    {
        public ReferenceValueHolder16<T> _1;
        public ReferenceValueHolder16<T> _2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _1._1._1._1, 32);
    }

    public ref struct ReferenceValueHolder64<T> where T : class
    {
        public ReferenceValueHolder32<T> _1;
        public ReferenceValueHolder32<T> _2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _1._1._1._1._1, 64);
    }
}