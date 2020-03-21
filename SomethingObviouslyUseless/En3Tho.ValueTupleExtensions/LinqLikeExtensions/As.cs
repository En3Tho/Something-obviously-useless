using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?, TOut?, TOut?, TOut?, TOut?, TOut?) As<TOut>(this (object v1, object v2, object v3, object v4, object v5, object v6, object v7) tuple) where TOut : class
            => (tuple.v1 as TOut, tuple.v2 as TOut, tuple.v3 as TOut, tuple.v4 as TOut, tuple.v5 as TOut, tuple.v6 as TOut, tuple.v7 as TOut);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?, TOut?, TOut?, TOut?, TOut?) As<TOut>(this (object v1, object v2, object v3, object v4, object v5, object v6) tuple) where TOut : class
            => (tuple.v1 as TOut, tuple.v2 as TOut, tuple.v3 as TOut, tuple.v4 as TOut, tuple.v5 as TOut, tuple.v6 as TOut);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?, TOut?, TOut?, TOut?) As<TOut>(this (object v1, object v2, object v3, object v4, object v5) tuple) where TOut : class
            => (tuple.v1 as TOut, tuple.v2 as TOut, tuple.v3 as TOut, tuple.v4 as TOut, tuple.v5 as TOut);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?, TOut?, TOut?) As<TOut>(this (object v1, object v2, object v3, object v4) tuple) where TOut : class
            => (tuple.v1 as TOut, tuple.v2 as TOut, tuple.v3 as TOut, tuple.v4 as TOut);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?, TOut?) As<TOut>(this (object v1, object v2, object v3) tuple) where TOut : class
            => (tuple.v1 as TOut, tuple.v2 as TOut, tuple.v3 as TOut);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?) As<TOut>(this (object v1, object v2) tuple) where TOut : class
            => (tuple.v1 as TOut, tuple.v2 as TOut);
    }
}
