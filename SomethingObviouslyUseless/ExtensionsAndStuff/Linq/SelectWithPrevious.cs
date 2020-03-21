﻿using System;
using System.Collections.Generic;
using static En3Tho.HelperClasses.ThrowHelper;

namespace ExtensionsAndStuff.Linq
{
    public static partial class Enumerable
    {
        public static IEnumerable<(TResult, TResult)> SelectWithPrevious<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            selector ??= ThrowArgumentNullException(selector, nameof(selector));
            return SelectWithPreviousIterator(source, selector);
        }

        private static IEnumerable<(TResult, TResult)> SelectWithPreviousIterator<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            #pragma warning disable CS8653
            TResult prev = default;
            #pragma warning restore CS8653
            foreach (var value in source)
            {
                var result = selector(value);
                yield return (prev, result);
                prev = result;
            }
        }
    }
}