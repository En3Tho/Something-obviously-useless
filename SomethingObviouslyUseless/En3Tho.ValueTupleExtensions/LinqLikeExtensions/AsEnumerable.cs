using System.Collections.Generic;

namespace En3Tho.ValueTupleExtensions.LinqLikeExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple)
        {
            yield return tuple.v1;
            yield return tuple.v2;
            yield return tuple.v3;
            yield return tuple.v4;
            yield return tuple.v5;
            yield return tuple.v6;
            yield return tuple.v7;
        }

        public static IEnumerable<T> AsEnumerable<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple)
        {
            yield return tuple.v1;
            yield return tuple.v2;
            yield return tuple.v3;
            yield return tuple.v4;
            yield return tuple.v5;
            yield return tuple.v6;
        }

        public static IEnumerable<T> AsEnumerable<T>(this (T v1, T v2, T v3, T v4, T v5) tuple)
        {
            yield return tuple.v1;
            yield return tuple.v2;
            yield return tuple.v3;
            yield return tuple.v4;
            yield return tuple.v5;
        }

        public static IEnumerable<T> AsEnumerable<T>(this (T v1, T v2, T v3, T v4) tuple)
        {
            yield return tuple.v1;
            yield return tuple.v2;
            yield return tuple.v3;
            yield return tuple.v4;
        }

        public static IEnumerable<T> AsEnumerable<T>(this (T v1, T v2, T v3) tuple)
        {
            yield return tuple.v1;
            yield return tuple.v2;
            yield return tuple.v3;
        }

        public static IEnumerable<T> AsEnumerable<T>(this (T v1, T v2) tuple)
        {
            yield return tuple.v1;
            yield return tuple.v2;
        }
    }
}