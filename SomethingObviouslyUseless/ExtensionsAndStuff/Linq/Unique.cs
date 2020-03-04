using System.Collections.Generic;
using System.Linq;
using ExtensionsAndStuff.HelperClasses;

namespace ExtensionsAndStuff.Linq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Unique<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            if (first == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(first));
            }

            if (second == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(second));
            }

            return UniqueIterator(first!, second!, null);
        }

        public static IEnumerable<TSource> Unique<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
        {
            if (first == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(first));
            }

            if (second == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(second));
            }

            return UniqueIterator(first!, second!, comparer);
        }

        private static IEnumerable<TSource> UniqueIterator<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
        {
            Set<TSource> set = new Set<TSource>(comparer);
            set.UnionWith(second);

            foreach (TSource element in first)
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