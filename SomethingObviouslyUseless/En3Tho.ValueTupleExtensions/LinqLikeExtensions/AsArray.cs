using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions.LinqLikeExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] AsArray<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple)
            => new[] { tuple.v1, tuple.v2, tuple.v3, tuple.v4, tuple.v5, tuple.v6, tuple.v7 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] AsArray<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple)
            => new[] { tuple.v1, tuple.v2, tuple.v3, tuple.v4, tuple.v5, tuple.v6 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] AsArray<T>(this (T v1, T v2, T v3, T v4, T v5) tuple)
            => new[] { tuple.v1, tuple.v2, tuple.v3, tuple.v4, tuple.v5 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] AsArray<T>(this (T v1, T v2, T v3, T v4) tuple)
            => new[] { tuple.v1, tuple.v2, tuple.v3, tuple.v4 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] AsArray<T>(this (T v1, T v2, T v3) tuple)
            => new[] { tuple.v1, tuple.v2, tuple.v3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] AsArray<T>(this (T v1, T v2) tuple)
            => new[] { tuple.v1, tuple.v2 };
    }
}