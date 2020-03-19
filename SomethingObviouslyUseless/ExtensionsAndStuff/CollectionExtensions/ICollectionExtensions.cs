using System;
using System.Collections.Generic;

namespace ExtensionsAndStuff.CollectionExtensions
{
    public static class ICollectionExtensions
    {
        public static TResult[] Map<TSource, TResult>(ICollection<TSource> source, Func<TSource, TResult> mapper)
        {
            var result = new TResult[source.Count];
            int i = 0;
            foreach (var element in source)
                result[i++] = mapper(element);
            return result;
        }
    }
}