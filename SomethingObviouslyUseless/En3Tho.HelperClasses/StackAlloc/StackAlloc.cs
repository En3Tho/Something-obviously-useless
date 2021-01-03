#if !NETSTANDARD2_0

using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses.StackAlloc
{
    internal static class StackAlloc
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueHolder4<T> Alloc4<T>() where T : class
            => new ValueHolder4<T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueHolder8<T> Alloc8<T>() where T : class
            => new ValueHolder8<T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueHolder16<T> Alloc16<T>() where T : class
            => new ValueHolder16<T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueHolder32<T> Alloc32<T>() where T : class
            => new ValueHolder32<T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueHolder64<T> Alloc64<T>() where T : class
            => new ValueHolder64<T>();
    }
}

#endif