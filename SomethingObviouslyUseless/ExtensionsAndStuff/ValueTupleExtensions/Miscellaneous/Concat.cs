using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static partial class MiscellaneousExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T) Concat<T>(this (T v1, T v2) tuple, T value)
            => (tuple.v1, tuple.v2, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) Concat<T>(this (T v1, T v2, T v3) tuple, T value)
            => (tuple.v1, tuple.v2, tuple.v3, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3, T v4) tuple, T value)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, T value)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, tuple.v5, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, T value)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, tuple.v5, tuple.v6, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) Concat<T>(this (T v1, T v2) tuple, (T v1, T v2) other)
            => (tuple.v1, tuple.v2, other.v1, other.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2) other)
            => (tuple.v1, tuple.v2, tuple.v3, other.v1, other.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) Concat<T>(this (T v1, T v2) tuple, (T v1, T v2, T v3) other)
            => (tuple.v1, tuple.v2, other.v1, other.v2, other.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2, T v3) other)
            => (tuple.v1, tuple.v2, tuple.v3, other.v1, other.v2, other.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3, T v4) tuple, (T v1, T v2) other)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, other.v1, other.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) Concat<T>(this (T v1, T v2) tuple, (T v1, T v2, T v3, T v4) other)
            => (tuple.v1, tuple.v2, other.v1, other.v2, other.v3, other.v4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, (T v1, T v2) other)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, tuple.v5, other.v1, other.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Concat<T>(this (T v1, T v2) tuple, (T v1, T v2, T v3, T v4, T v5) other)
            => (tuple.v1, tuple.v2, other.v1, other.v2, other.v3, other.v4, other.v5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3, T v4) tuple, (T v1, T v2, T v3) other)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, other.v1, other.v2, other.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2, T v3, T v4) other)
            => (tuple.v1, tuple.v2, tuple.v3, other.v1, other.v2, other.v3, other.v4);
    }
}
