using System;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.ReferenceStackAllocation
{
    public static class StackAlloc
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> AllocSpan4<T>() where T : class
            => new ReferenceValueHolder4<T>().AsSpan();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> AllocSpan8<T>() where T : class
            => new ReferenceValueHolder8<T>().AsSpan();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> AllocSpan16<T>() where T : class
            => new ReferenceValueHolder16<T>().AsSpan();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> AllocSpan32<T>() where T : class
            => new ReferenceValueHolder32<T>().AsSpan();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> AllocSpan64<T>() where T : class
            => new ReferenceValueHolder64<T>().AsSpan();
    }
}