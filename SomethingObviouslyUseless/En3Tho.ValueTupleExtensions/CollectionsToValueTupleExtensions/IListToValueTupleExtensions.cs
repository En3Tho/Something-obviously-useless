using System;
using System.Collections.Generic;

namespace En3Tho.ValueTupleExtensions.CollectionsToValueTupleExtensions
{
    public static class IListToValueTupleExtensions
    {
        public static (TResult1[], TResult2[]) Map<TSource, TResult1, TResult2>(this IList<TSource> source, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2)
        {
            var mapper = new ArrayMapper<TSource, TResult1, TResult2>(source.Count, mapper1, mapper2);
            for (int j = 0; j < source.Count; j++)
            {
                var value = source[j];
                mapper.Map(ref value, j);
            }

            return (mapper.Result1, mapper.Result2);
        }

        public static (TResult1[], TResult2[], TResult3[]) Map<TSource, TResult1, TResult2, TResult3>(this IList<TSource> source, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2,
            Func<TSource, TResult3> mapper3)
        {
            var mapper = new ArrayMapper<TSource, TResult1, TResult2, TResult3>(source.Count, mapper1, mapper2, mapper3);
            for (int j = 0; j < source.Count; j++)
            {
                var value = source[j];
                mapper.Map(ref value, j);
            }

            return (mapper.Result1, mapper.Result2, mapper.Result3);
        }

        public static (TResult1[], TResult2[], TResult3[], TResult4[]) Map<TSource, TResult1, TResult2, TResult3, TResult4>(this IList<TSource> source, Func<TSource, TResult1> mapper1,
            Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4)
        {
            var mapper = new ArrayMapper<TSource, TResult1, TResult2, TResult3, TResult4>(source.Count, mapper1, mapper2, mapper3, mapper4);
            for (int j = 0; j < source.Count; j++)
            {
                var value = source[j];
                mapper.Map(ref value, j);
            }

            return (mapper.Result1, mapper.Result2, mapper.Result3, mapper.Result4);
        }

        public static (TResult1[], TResult2[], TResult3[], TResult4[], TResult5[]) Map<TSource, TResult1, TResult2, TResult3, TResult4, TResult5>(this IList<TSource> source,
            Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4, Func<TSource, TResult5> mapper5)
        {
            var mapper = new ArrayMapper<TSource, TResult1, TResult2, TResult3, TResult4, TResult5>(source.Count, mapper1, mapper2, mapper3, mapper4, mapper5);
            for (int j = 0; j < source.Count; j++)
            {
                var value = source[j];
                mapper.Map(ref value, j);
            }

            return (mapper.Result1, mapper.Result2, mapper.Result3, mapper.Result4, mapper.Result5);
        }

        public static (TResult1[], TResult2[], TResult3[], TResult4[], TResult5[], TResult6[]) Map<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(this IList<TSource> source,
            Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4, Func<TSource, TResult5> mapper5,
            Func<TSource, TResult6> mapper6)
        {
            var mapper = new ArrayMapper<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(source.Count, mapper1, mapper2, mapper3, mapper4, mapper5, mapper6);
            for (int j = 0; j < source.Count; j++)
            {
                var value = source[j];
                mapper.Map(ref value, j);
            }

            return (mapper.Result1, mapper.Result2, mapper.Result3, mapper.Result4, mapper.Result5, mapper.Result6);
        }

        public static (TResult1[], TResult2[], TResult3[], TResult4[], TResult5[], TResult6[], TResult7[]) Map<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(
            this IList<TSource> source, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4,
            Func<TSource, TResult5> mapper5, Func<TSource, TResult6> mapper6, Func<TSource, TResult7> mapper7)
        {
            var mapper = new ArrayMapper<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(source.Count, mapper1, mapper2, mapper3, mapper4, mapper5, mapper6, mapper7);
            for (int j = 0; j < source.Count; j++)
            {
                var value = source[j];
                mapper.Map(ref value, j);
            }

            return (mapper.Result1, mapper.Result2, mapper.Result3, mapper.Result4, mapper.Result5, mapper.Result6, mapper.Result7);
        }
    }
}