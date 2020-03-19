using System.Collections.Generic;
using ExtensionsAndStuff.HelperClasses;

namespace ExtensionsAndStuff.Linq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Unique<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            first ??= ThrowHelper.ThrowArgumentNullException(first, nameof(first));
            second ??= ThrowHelper.ThrowArgumentNullException(second, nameof(second));
            return UniqueIterator(first, second, EqualityComparer<TSource>.Default);
        }

        public static IEnumerable<TSource> Unique<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
        {
            first ??= ThrowHelper.ThrowArgumentNullException(first, nameof(first));
            second ??= ThrowHelper.ThrowArgumentNullException(second, nameof(second));
            return UniqueIterator(first, second, comparer);
        }

        private static IEnumerable<TSource> UniqueIterator<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
        {
            var set = new ValueTrackingSet<TSource>(comparer);
            set.UnionWith(second);

            foreach (var element in first)
            {
                if (!set.Remove(element))
                {
                    yield return element;
                }
            }

            foreach (var element in set.ToEnumerable())
            {
                yield return element;
            }
        }
    }
}