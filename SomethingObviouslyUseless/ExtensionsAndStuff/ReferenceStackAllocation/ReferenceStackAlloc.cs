#if !NETSTANDARD2_0

using System;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.ReferenceStackAllocation
{
    public static class ReferenceStackAlloc
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReferenceValueHolder4<T> Alloc4<T>() where T : class
            => new ReferenceValueHolder4<T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReferenceValueHolder8<T> Alloc8<T>() where T : class
            => new ReferenceValueHolder8<T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReferenceValueHolder16<T> Alloc16<T>() where T : class
            => new ReferenceValueHolder16<T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReferenceValueHolder32<T> Alloc32<T>() where T : class
            => new ReferenceValueHolder32<T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReferenceValueHolder64<T> Alloc64<T>() where T : class
            => new ReferenceValueHolder64<T>();
    }
}

#endif