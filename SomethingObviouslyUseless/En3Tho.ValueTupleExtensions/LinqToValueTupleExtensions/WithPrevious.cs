using System.Collections.Generic;
using static En3Tho.ValueTupleExtensions.ThrowHelper;

namespace En3Tho.ValueTupleExtensions.LinqToValueTupleExtensions
{
    public static partial class IEnumerableToValueTupleExtensions
    {
        public static IEnumerable<(TSource, TSource)> WithPrevious<TSource>(this IEnumerable<TSource> source)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            return WithPreviousIterator(source);
        }

        private static IEnumerable<(TSource, TSource)> WithPreviousIterator<TSource>(IEnumerable<TSource> source)
        {
            // TODO nullable generics?
#pragma warning disable CS8653, CS8619
            using var enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
            {
                var prev = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    yield return (prev, current);
                    prev = current;
                }
            }
#pragma warning restore CS8653
        }
    }
}