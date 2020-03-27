using System;
using System.Collections.Generic;

namespace En3Tho.ValueTupleExtensions.CollectionsToValueTupleExtensions
{
    public static partial class ICollectionToValueTupleExtensions
    {
        public static TResult[] Map<TSource, TResult>(this ICollection<TSource> source, Func<TSource, TResult> mapper)
        {
            var result = new TResult[source.Count];
            int j = 0;
            foreach (var obj in source) { result[j++] = mapper(obj); }
            return result;
        }

        public static (TResult1[], TResult2[]) Map<TSource, TResult1, TResult2>(this ICollection<TSource> source, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2)
        {
            var mapper = new ArrayMapper<TSource, TResult1, TResult2>(source.Count, mapper1, mapper2);
            int j = 0;
            foreach (var obj in source)
            {
                var val = obj;
                mapper.Map(ref val, j++);
            }

            return (mapper.Result1, mapper.Result2);
        }

        public static (TResult1[], TResult2[], TResult3[]) Map<TSource, TResult1, TResult2, TResult3>(this ICollection<TSource> source, Func<TSource, TResult1> mapper1,
            Func<TSource, TResult2> mapper2,
            Func<TSource, TResult3> mapper3)
        {
            var mapper = new ArrayMapper<TSource, TResult1, TResult2, TResult3>(source.Count, mapper1, mapper2, mapper3);
            int j = 0;
            foreach (var obj in source)
            {
                var val = obj;
                mapper.Map(ref val, j++);
            }

            return (mapper.Result1, mapper.Result2, mapper.Result3);
        }

        public static (TResult1[], TResult2[], TResult3[], TResult4[]) Map<TSource, TResult1, TResult2, TResult3, TResult4>(this ICollection<TSource> source, Func<TSource, TResult1> mapper1,
            Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4)
        {
            var mapper = new ArrayMapper<TSource, TResult1, TResult2, TResult3, TResult4>(source.Count, mapper1, mapper2, mapper3, mapper4);
            int j = 0;
            foreach (var obj in source)
            {
                var val = obj;
                mapper.Map(ref val, j++);
            }

            return (mapper.Result1, mapper.Result2, mapper.Result3, mapper.Result4);
        }

        public static (TResult1[], TResult2[], TResult3[], TResult4[], TResult5[]) Map<TSource, TResult1, TResult2, TResult3, TResult4, TResult5>(this ICollection<TSource> source,
            Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4, Func<TSource, TResult5> mapper5)
        {
            var mapper = new ArrayMapper<TSource, TResult1, TResult2, TResult3, TResult4, TResult5>(source.Count, mapper1, mapper2, mapper3, mapper4, mapper5);
            int j = 0;
            foreach (var obj in source)
            {
                var val = obj;
                mapper.Map(ref val, j++);
            }

            return (mapper.Result1, mapper.Result2, mapper.Result3, mapper.Result4, mapper.Result5);
        }

        public static (TResult1[], TResult2[], TResult3[], TResult4[], TResult5[], TResult6[]) Map<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(
            this ICollection<TSource> source,
            Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4, Func<TSource, TResult5> mapper5,
            Func<TSource, TResult6> mapper6)
        {
            var mapper = new ArrayMapper<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(source.Count, mapper1, mapper2, mapper3, mapper4, mapper5, mapper6);
            int j = 0;
            foreach (var obj in source)
            {
                var val = obj;
                mapper.Map(ref val, j++);
            }

            return (mapper.Result1, mapper.Result2, mapper.Result3, mapper.Result4, mapper.Result5, mapper.Result6);
        }

        public static (TResult1[], TResult2[], TResult3[], TResult4[], TResult5[], TResult6[], TResult7[]) Map<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(
            this ICollection<TSource> source, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4,
            Func<TSource, TResult5> mapper5, Func<TSource, TResult6> mapper6, Func<TSource, TResult7> mapper7)
        {
            var mapper = new ArrayMapper<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(source.Count, mapper1, mapper2, mapper3, mapper4, mapper5, mapper6, mapper7);
            int j = 0;
            foreach (var obj in source)
            {
                var val = obj;
                mapper.Map(ref val, j++);
            }

            return (mapper.Result1, mapper.Result2, mapper.Result3, mapper.Result4, mapper.Result5, mapper.Result6, mapper.Result7);
        }
    }
}