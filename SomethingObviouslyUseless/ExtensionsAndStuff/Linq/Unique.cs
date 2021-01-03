using System.Collections.Generic;
using static ExtensionsAndStuff.ThrowHelper;

namespace ExtensionsAndStuff.Linq
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TSource> Unique<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            first ??= ThrowArgumentNullException(first, nameof(first));
            second ??= ThrowArgumentNullException(second, nameof(second));
            return UniqueIterator(first, second, EqualityComparer<TSource>.Default);
        }

        public static IEnumerable<TSource> Unique<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
        {
            first ??= ThrowArgumentNullException(first, nameof(first));
            second ??= ThrowArgumentNullException(second, nameof(second));
            return UniqueIterator(first, second, comparer);
        }

        private static IEnumerable<TSource> UniqueIterator<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
        {
            var setFirst = new ValueTrackingSet<TSource>(comparer);
            setFirst.UnionWith(first);
            
            var setSecond = new ValueTrackingSet<TSource>(comparer);
            setSecond.UnionWith(second);

            foreach (var element in setFirst.Slots)
                if (element._hasValue && !setSecond.Remove(element._value))
                    yield return element._value;

            foreach (var element in setSecond.Slots)
                if (element._hasValue)
                    yield return element._value;
        }
    }
}