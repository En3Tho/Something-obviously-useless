using System;
using System.Collections.Generic;

namespace En3Tho.ValueTupleExtensions.LinqToValueTupleExtensions
{
    public static partial class IEnumerableToValueTupleExtensions
    {
        public static IEnumerable<(TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7)> Select<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(
            this IEnumerable<TSource> source, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4,
            Func<TSource, TResult5> mapper5, Func<TSource, TResult6> mapper6, Func<TSource, TResult7> mapper7)
        {
            source ??= ThrowHelper.ThrowArgumentNullException(source, nameof(source));
            mapper1 ??= ThrowHelper.ThrowArgumentNullException(mapper1, nameof(mapper1));
            mapper2 ??= ThrowHelper.ThrowArgumentNullException(mapper2, nameof(mapper2));
            mapper3 ??= ThrowHelper.ThrowArgumentNullException(mapper3, nameof(mapper3));
            mapper4 ??= ThrowHelper.ThrowArgumentNullException(mapper4, nameof(mapper4));
            mapper5 ??= ThrowHelper.ThrowArgumentNullException(mapper5, nameof(mapper5));
            mapper6 ??= ThrowHelper.ThrowArgumentNullException(mapper6, nameof(mapper6));
            mapper7 ??= ThrowHelper.ThrowArgumentNullException(mapper7, nameof(mapper7));
            return SelectInternal(source, mapper1, mapper2, mapper3, mapper4, mapper5, mapper6, mapper7);
        }

        private static IEnumerable<(TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7)>
            SelectInternal<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(IEnumerable<TSource> source, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2,
                Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4, Func<TSource, TResult5> mapper5, Func<TSource, TResult6> mapper6, Func<TSource, TResult7> mapper7)
        {
            foreach (var value in source)
                yield return (mapper1(value), mapper2(value), mapper3(value), mapper4(value), mapper5(value), mapper6(value), mapper7(value));
        }

        public static IEnumerable<(TResult1, TResult2, TResult3, TResult4, TResult5, TResult6)> Select<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(
            this IEnumerable<TSource> source, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4,
            Func<TSource, TResult5> mapper5, Func<TSource, TResult6> mapper6)
        {
            source ??= ThrowHelper.ThrowArgumentNullException(source, nameof(source));
            mapper1 ??= ThrowHelper.ThrowArgumentNullException(mapper1, nameof(mapper1));
            mapper2 ??= ThrowHelper.ThrowArgumentNullException(mapper2, nameof(mapper2));
            mapper3 ??= ThrowHelper.ThrowArgumentNullException(mapper3, nameof(mapper3));
            mapper4 ??= ThrowHelper.ThrowArgumentNullException(mapper4, nameof(mapper4));
            mapper5 ??= ThrowHelper.ThrowArgumentNullException(mapper5, nameof(mapper5));
            mapper6 ??= ThrowHelper.ThrowArgumentNullException(mapper6, nameof(mapper6));
            return SelectInternal(source, mapper1, mapper2, mapper3, mapper4, mapper5, mapper6);
        }

        private static IEnumerable<(TResult1, TResult2, TResult3, TResult4, TResult5, TResult6)> SelectInternal<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(
            IEnumerable<TSource> source, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4,
            Func<TSource, TResult5> mapper5, Func<TSource, TResult6> mapper6)
        {
            foreach (var value in source)
                yield return (mapper1(value), mapper2(value), mapper3(value), mapper4(value), mapper5(value), mapper6(value));
        }

        public static IEnumerable<(TResult1, TResult2, TResult3, TResult4, TResult5)> Select<TSource, TResult1, TResult2, TResult3, TResult4, TResult5>(this IEnumerable<TSource> source,
            Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4, Func<TSource, TResult5> mapper5)
        {
            source ??= ThrowHelper.ThrowArgumentNullException(source, nameof(source));
            mapper1 ??= ThrowHelper.ThrowArgumentNullException(mapper1, nameof(mapper1));
            mapper2 ??= ThrowHelper.ThrowArgumentNullException(mapper2, nameof(mapper2));
            mapper3 ??= ThrowHelper.ThrowArgumentNullException(mapper3, nameof(mapper3));
            mapper4 ??= ThrowHelper.ThrowArgumentNullException(mapper4, nameof(mapper4));
            mapper5 ??= ThrowHelper.ThrowArgumentNullException(mapper5, nameof(mapper5));
            return SelectInternal(source, mapper1, mapper2, mapper3, mapper4, mapper5);
        }

        private static IEnumerable<(TResult1, TResult2, TResult3, TResult4, TResult5)> SelectInternal<TSource, TResult1, TResult2, TResult3, TResult4, TResult5>(
            IEnumerable<TSource> source, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4,
            Func<TSource, TResult5> mapper5)
        {
            foreach (var value in source)
                yield return (mapper1(value), mapper2(value), mapper3(value), mapper4(value), mapper5(value));
        }

        public static IEnumerable<(TResult1, TResult2, TResult3, TResult4)> Select<TSource, TResult1, TResult2, TResult3, TResult4>(this IEnumerable<TSource> source,
            Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4)
        {
            source ??= ThrowHelper.ThrowArgumentNullException(source, nameof(source));
            mapper1 ??= ThrowHelper.ThrowArgumentNullException(mapper1, nameof(mapper1));
            mapper2 ??= ThrowHelper.ThrowArgumentNullException(mapper2, nameof(mapper2));
            mapper3 ??= ThrowHelper.ThrowArgumentNullException(mapper3, nameof(mapper3));
            mapper4 ??= ThrowHelper.ThrowArgumentNullException(mapper4, nameof(mapper4));
            return SelectInternal(source, mapper1, mapper2, mapper3, mapper4);
        }

        private static IEnumerable<(TResult1, TResult2, TResult3, TResult4)> SelectInternal<TSource, TResult1, TResult2, TResult3, TResult4>(
            IEnumerable<TSource> source, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4)
        {
            foreach (var value in source)
                yield return (mapper1(value), mapper2(value), mapper3(value), mapper4(value));
        }

        public static IEnumerable<(TResult1, TResult2, TResult3)> Select<TSource, TResult1, TResult2, TResult3>(this IEnumerable<TSource> source,
            Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3)
        {
            source ??= ThrowHelper.ThrowArgumentNullException(source, nameof(source));
            mapper1 ??= ThrowHelper.ThrowArgumentNullException(mapper1, nameof(mapper1));
            mapper2 ??= ThrowHelper.ThrowArgumentNullException(mapper2, nameof(mapper2));
            mapper3 ??= ThrowHelper.ThrowArgumentNullException(mapper3, nameof(mapper3));
            return SelectInternal(source, mapper1, mapper2, mapper3);
        }

        private static IEnumerable<(TResult1, TResult2, TResult3)> SelectInternal<TSource, TResult1, TResult2, TResult3>(
            IEnumerable<TSource> source, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3)
        {
            foreach (var value in source)
                yield return (mapper1(value), mapper2(value), mapper3(value));
        }

        public static IEnumerable<(TResult1, TResult2)> Select<TSource, TResult1, TResult2>(this IEnumerable<TSource> source, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2)
        {
            source ??= ThrowHelper.ThrowArgumentNullException(source, nameof(source));
            mapper1 ??= ThrowHelper.ThrowArgumentNullException(mapper1, nameof(mapper1));
            mapper2 ??= ThrowHelper.ThrowArgumentNullException(mapper2, nameof(mapper2));
            return SelectInternal(source, mapper1, mapper2);
        }

        private static IEnumerable<(TResult1, TResult2)> SelectInternal<TSource, TResult1, TResult2>(IEnumerable<TSource> source, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2)
        {
            foreach (var value in source)
                yield return (mapper1(value), mapper2(value));
        }
    }
}