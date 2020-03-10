using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static partial class MiscellaneousExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?, TOut?, TOut?, TOut?, TOut?, TOut?) As<TIn, TOut>(this (TIn v1, TIn v2, TIn v3, TIn v4, TIn v5, TIn v6, TIn v7) tuple) where TOut : class where TIn : class
            => (tuple.v1 as TOut, tuple.v2 as TOut, tuple.v3 as TOut, tuple.v4 as TOut, tuple.v5 as TOut, tuple.v6 as TOut, tuple.v7 as TOut);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?, TOut?, TOut?, TOut?, TOut?) As<TIn, TOut>(this (TIn v1, TIn v2, TIn v3, TIn v4, TIn v5, TIn v6) tuple) where TOut : class where TIn : class
            => (tuple.v1 as TOut, tuple.v2 as TOut, tuple.v3 as TOut, tuple.v4 as TOut, tuple.v5 as TOut, tuple.v6 as TOut);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?, TOut?, TOut?, TOut?) As<TIn, TOut>(this (TIn v1, TIn v2, TIn v3, TIn v4, TIn v5) tuple) where TOut : class where TIn : class
            => (tuple.v1 as TOut, tuple.v2 as TOut, tuple.v3 as TOut, tuple.v4 as TOut, tuple.v5 as TOut);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?, TOut?, TOut?) As<TIn, TOut>(this (TIn v1, TIn v2, TIn v3, TIn v4) tuple) where TOut : class where TIn : class
            => (tuple.v1 as TOut, tuple.v2 as TOut, tuple.v3 as TOut, tuple.v4 as TOut);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?, TOut?) As<TIn, TOut>(this (TIn v1, TIn v2, TIn v3) tuple) where TOut : class where TIn : class
            => (tuple.v1 as TOut, tuple.v2 as TOut, tuple.v3 as TOut);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?) As<TIn, TOut>(this (TIn v1, TIn v2) tuple) where TOut : class where TIn : class
            => (tuple.v1 as TOut, tuple.v2 as TOut);
    }
}
