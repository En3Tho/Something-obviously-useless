using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using static En3Tho.ValueTupleExtensions.ThrowHelper;

namespace En3Tho.ValueTupleExtensions.LinqToValueTupleExtensions
{
    public static partial class IEnumerableToValueTupleExtensions
    {
        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));

            yield return value;
            foreach (var val in source)
                yield return val;
        }

        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, (TSource, TSource) value)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));

            yield return value.Item1;
            yield return value.Item2;
            foreach (var val in source)
                yield return val;
        }

        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, (TSource, TSource, TSource) value)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));

            yield return value.Item1;
            yield return value.Item2;
            yield return value.Item3;
            foreach (var val in source)
                yield return val;
        }

        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, (TSource, TSource, TSource, TSource) value)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));

            yield return value.Item1;
            yield return value.Item2;
            yield return value.Item3;
            yield return value.Item4;
            foreach (var val in source)
                yield return val;
        }

        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, (TSource, TSource, TSource, TSource, TSource) value)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));

            yield return value.Item1;
            yield return value.Item2;
            yield return value.Item3;
            yield return value.Item4;
            yield return value.Item5;
            foreach (var val in source)
                yield return val;
        }

        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, (TSource, TSource, TSource, TSource, TSource, TSource) value)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));

            yield return value.Item1;
            yield return value.Item2;
            yield return value.Item3;
            yield return value.Item4;
            yield return value.Item5;
            yield return value.Item6;
            foreach (var val in source)
                yield return val;
        }

        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, (TSource, TSource, TSource, TSource, TSource, TSource, TSource) value)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));

            yield return value.Item1;
            yield return value.Item2;
            yield return value.Item3;
            yield return value.Item4;
            yield return value.Item5;
            yield return value.Item6;
            yield return value.Item7;
            foreach (var val in source)
                yield return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second) => second.Concat(first);
    }
}