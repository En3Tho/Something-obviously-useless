namespace En3Tho.ValueTupleExtensions.LinqLikeExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
        public static (T7, T6, T5, T4, T3, T2, T1) Reverse<T1, T2, T3, T4, T5, T6, T7>(this (T1, T2, T3, T4, T5, T6, T7) tuple)
            => (tuple.Item7, tuple.Item6, tuple.Item5, tuple.Item4, tuple.Item3, tuple.Item2, tuple.Item1);

        public static (T6, T5, T4, T3, T2, T1) Reverse<T1, T2, T3, T4, T5, T6>(this (T1, T2, T3, T4, T5, T6) tuple)
            => (tuple.Item6, tuple.Item5, tuple.Item4, tuple.Item3, tuple.Item2, tuple.Item1);

        public static (T5, T4, T3, T2, T1) Reverse<T1, T2, T3, T4, T5>(this (T1, T2, T3, T4, T5) tuple)
            => (tuple.Item5, tuple.Item4, tuple.Item3, tuple.Item2, tuple.Item1);

        public static (T4, T3, T2, T1) Reverse<T1, T2, T3, T4>(this (T1, T2, T3, T4) tuple)
            => (tuple.Item4, tuple.Item3, tuple.Item2, tuple.Item1);

        public static (T3, T2, T1) Reverse<T1, T2, T3>(this (T1, T2, T3) tuple)
            => (tuple.Item3, tuple.Item2, tuple.Item1);

        public static (T2, T1) Reverse<T1, T2, T3>(this (T1, T2) tuple)
            => (tuple.Item2, tuple.Item1);
    }
}