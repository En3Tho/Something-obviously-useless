using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static partial class MiscellaneousExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut, TOut, TOut, TOut, TOut, TOut, TOut) Cast<TIn, TOut>(this (TIn v1, TIn v2, TIn v3, TIn v4, TIn v5, TIn v6, TIn v7) tuple) where TIn : class where TOut : class
            => ((TOut)(object)tuple.v1, (TOut)(object)tuple.v2, (TOut)(object)tuple.v3, (TOut)(object)tuple.v4, (TOut)(object)tuple.v5, (TOut)(object)tuple.v6, (TOut)(object)tuple.v7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut, TOut, TOut, TOut, TOut, TOut) Cast<TIn, TOut>(this (TIn v1, TIn v2, TIn v3, TIn v4, TIn v5, TIn v6) tuple) where TIn : class where TOut : class
            => ((TOut)(object)tuple.v1, (TOut)(object)tuple.v2, (TOut)(object)tuple.v3, (TOut)(object)tuple.v4, (TOut)(object)tuple.v5, (TOut)(object)tuple.v6);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut, TOut, TOut, TOut, TOut) Cast<TIn, TOut>(this (TIn v1, TIn v2, TIn v3, TIn v4, TIn v5) tuple) where TIn : class where TOut : class
            => ((TOut)(object)tuple.v1, (TOut)(object)tuple.v2, (TOut)(object)tuple.v3, (TOut)(object)tuple.v4, (TOut)(object)tuple.v5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut, TOut, TOut, TOut) Cast<TIn, TOut>(this (TIn v1, TIn v2, TIn v3, TIn v4) tuple) where TIn : class where TOut : class
            => ((TOut)(object)tuple.v1, (TOut)(object)tuple.v2, (TOut)(object)tuple.v3, (TOut)(object)tuple.v4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut, TOut, TOut) Cast<TIn, TOut>(this (TIn v1, TIn v2, TIn v3) tuple) where TIn : class where TOut : class
            => ((TOut)(object)tuple.v1, (TOut)(object)tuple.v2, (TOut)(object)tuple.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut, TOut) Cast<TIn, TOut>(this (TIn v1, TIn v2) tuple) where TIn : class where TOut : class
            => ((TOut)(object)tuple.v1, (TOut)(object)tuple.v2);
    }
}
