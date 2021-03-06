﻿using System;
using System.Collections.Generic;
using static ExtensionsAndStuff.ThrowHelper;

namespace ExtensionsAndStuff.Linq
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> enumerable, Action<TSource> action)
        {
            enumerable ??= ThrowArgumentNullException(enumerable, nameof(enumerable));
            action ??= ThrowArgumentNullException(action, nameof(action));
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