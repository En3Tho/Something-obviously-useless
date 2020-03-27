using System.Collections.Generic;
using static En3Tho.ValueTupleExtensions.ThrowHelper;

namespace En3Tho.ValueTupleExtensions.LinqToValueTupleExtensions
{
    public static partial class IEnumerableToValueTupleExtensions
    {
        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            
            foreach (var val in source)
                yield return val;
            yield return value;
        }

        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, (TSource, TSource) value)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            
            foreach (var val in source)
                yield return val;
            yield return value.Item1;
            yield return value.Item2;
        }
        
        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, (TSource, TSource, TSource) value)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            
            foreach (var val in source)
                yield return val;
            yield return value.Item1;
            yield return value.Item2;
            yield return value.Item3;
        }
        
        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, (TSource, TSource, TSource, TSource) value)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));

            foreach (var val in source)
                yield return val;
            yield return value.Item1;
            yield return value.Item2;
            yield return value.Item3;
            yield return value.Item4;
        }
        
        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, (TSource, TSource, TSource, TSource, TSource) value)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            
            foreach (var val in source)
                yield return val;
            yield return value.Item1;
            yield return value.Item2;
            yield return value.Item3;
            yield return value.Item4;
            yield return value.Item5;
        }
        
        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, (TSource, TSource, TSource, TSource, TSource, TSource) value)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            
            foreach (var val in source)
                yield return val;
            yield return value.Item1;
            yield return value.Item2;
            yield return value.Item3;
            yield return value.Item4;
            yield return value.Item5;
            yield return value.Item6;
        }
        
        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, (TSource, TSource, TSource, TSource, TSource, TSource, TSource) value)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            
            foreach (var val in source)
                yield return val;
            yield return value.Item1;
            yield return value.Item2;
            yield return value.Item3;
            yield return value.Item4;
            yield return value.Item5;
            yield return value.Item6;
            yield return value.Item7;
        }
    }
}