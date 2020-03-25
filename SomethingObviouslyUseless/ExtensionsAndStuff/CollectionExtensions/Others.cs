using System;
using System.Collections.Generic;

namespace ExtensionsAndStuff.CollectionExtensions
{
    public static class Others
    {
        public static TResult[] Map<TSource, TResult>(this IList<TSource> source, Func<TSource, TResult> mapper)
        {
            var result = new TResult[source.Count];
            for (int j = 0; j < source.Count; j++) { result[j] = mapper(source[j]); }

            return result;
        }
        
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