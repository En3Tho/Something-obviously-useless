using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3) Concat<T1, T2, T3>(this (T1 v1, T2 v2) tuple, T3 value)
            => (tuple.v1, tuple.v2, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4) Concat<T1, T2, T3, T4>(this (T1 v1, T2 v2, T3 v3) tuple, T4 value)
            => (tuple.v1, tuple.v2, tuple.v3, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5) Concat<T1, T2, T3, T4, T5>(this (T1 v1, T2 v2, T3 v3, T4 v4) tuple, T5 value)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5, T6) Concat<T1, T2, T3, T4, T5, T6>(this (T1 v1, T2 v2, T3 v3, T4 v4, T5 v5) tuple, T6 value)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, tuple.v5, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5, T6, T7) Concat<T1, T2, T3, T4, T5, T6, T7>(this (T1 v1, T2 v2, T3 v3, T4 v4, T5 v5, T6 v6) tuple, T7 value)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, tuple.v5, tuple.v6, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4) Concat<T1, T2, T3, T4>(this (T1 v1, T2 v2) tuple, (T3 v1, T4 v2) other)
            => (tuple.v1, tuple.v2, other.v1, other.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5) Concat<T1, T2, T3, T4, T5>(this (T1 v1, T2 v2, T3 v3) tuple, (T4 v1, T5 v2) other)
            => (tuple.v1, tuple.v2, tuple.v3, other.v1, other.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5) Concat<T1, T2, T3, T4, T5>(this (T1 v1, T2 v2) tuple, (T3 v1, T4 v2, T5 v3) other)
            => (tuple.v1, tuple.v2, other.v1, other.v2, other.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5, T6) Concat<T1, T2, T3, T4, T5, T6>(this (T1 v1, T2 v2, T3 v3) tuple, (T4 v1, T5 v2, T6 v3) other)
            => (tuple.v1, tuple.v2, tuple.v3, other.v1, other.v2, other.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5, T6) Concat<T1, T2, T3, T4, T5, T6>(this (T1 v1, T2 v2, T3 v3, T4 v4) tuple, (T5 v1, T6 v2) other)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, other.v1, other.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5, T6) Concat<T1, T2, T3, T4, T5, T6>(this (T1 v1, T2 v2) tuple, (T3 v1, T4 v2, T5 v3, T6 v4) other)
            => (tuple.v1, tuple.v2, other.v1, other.v2, other.v3, other.v4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5, T6, T7) Concat<T1, T2, T3, T4, T5, T6, T7>(this (T1 v1, T2 v2, T3 v3, T4 v4, T5 v5) tuple, (T6 v1, T7 v2) other)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, tuple.v5, other.v1, other.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5, T6, T7) Concat<T1, T2, T3, T4, T5, T6, T7>(this (T1 v1, T2 v2) tuple, (T3 v1, T4 v2, T5 v3, T6 v4, T7 v5) other)
            => (tuple.v1, tuple.v2, other.v1, other.v2, other.v3, other.v4, other.v5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5, T6, T7) Concat<T1, T2, T3, T4, T5, T6, T7>(this (T1 v1, T2 v2, T3 v3, T4 v4) tuple, (T5 v1, T6 v2, T7 v3) other)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, other.v1, other.v2, other.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5, T6, T7) Concat<T1, T2, T3, T4, T5, T6, T7>(this (T1 v1, T2 v2, T3 v3) tuple, (T4 v1, T5 v2, T6 v3, T7 v4) other)
            => (tuple.v1, tuple.v2, tuple.v3, other.v1, other.v2, other.v3, other.v4);
    }
}
