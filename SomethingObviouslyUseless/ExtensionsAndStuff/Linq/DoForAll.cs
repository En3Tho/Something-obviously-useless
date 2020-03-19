using System;
using System.Collections.Generic;
using ExtensionsAndStuff.HelperClasses;

namespace ExtensionsAndStuff.Linq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> DoForAll<TSource>(this IEnumerable<TSource> enumerable, Action<TSource> action)
        {
            enumerable ??= ThrowHelper.ThrowArgumentNullException(enumerable, nameof(enumerable));
            action ??= ThrowHelper.ThrowArgumentNullException(action, nameof(action));
            return DoForAllIterator(enumerable, action);
        }

        private static IEnumerable<TSource> DoForAllIterator<TSource>(IEnumerable<TSource> enumerable, Action<TSource> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
                yield return item;
            }
        }
    }
}