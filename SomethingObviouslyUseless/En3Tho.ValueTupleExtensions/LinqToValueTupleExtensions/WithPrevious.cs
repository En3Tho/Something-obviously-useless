using System.Collections.Generic;
using static En3Tho.HelperClasses.ThrowHelper;

namespace En3Tho.ValueTupleExtensions.LinqToValueTupleExtensions
{
    public static partial class ValueTupleEnumerableExtensions
    {
        public static IEnumerable<(TSource, TSource)> WithPrevious<TSource>(this IEnumerable<TSource> source)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            return SelectWithPreviousIterator(source);
        }

        private static IEnumerable<(TSource, TSource)> SelectWithPreviousIterator<TSource>(IEnumerable<TSource> source)
        {
            #pragma warning disable CS8653
            TSource prev = default;
            #pragma warning restore CS8653
            foreach (var value in source)
            {
                yield return (prev, value);
                prev = value;
            }
        }
    }
}