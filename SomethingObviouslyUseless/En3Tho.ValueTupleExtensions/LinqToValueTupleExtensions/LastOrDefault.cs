using System;
using System.Collections.Generic;
using static En3Tho.ValueTupleExtensions.ThrowHelper;

namespace En3Tho.ValueTupleExtensions.LinqToValueTupleExtensions
{
    public static partial class IEnumerableToValueTupleExtensions
    {
        public static (TSource, TSource) LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate1, Func<TSource, bool> predicate2)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            predicate1 ??= ThrowArgumentNullException(predicate1, nameof(predicate1));
            predicate2 ??= ThrowArgumentNullException(predicate2, nameof(predicate2));

            var (result1, result2) = (default(TSource)!, default(TSource)!);
            if (source is IList<TSource> list)
            {
                var helper = new LastOrDefaultListHelper<TSource>(list);
                helper.SetValues(ref result1, ref result2, predicate1, predicate2);
            }
            else
            {
                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    var helper = new LastOrDefaultEnumerableHelper<TSource>(enumerator);
                    helper.SetValues(ref result1, ref result2, predicate1, predicate2);
                }
            }

            return (result1, result2);
        }

        public static (TSource, TSource, TSource) LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            predicate1 ??= ThrowArgumentNullException(predicate1, nameof(predicate1));
            predicate2 ??= ThrowArgumentNullException(predicate2, nameof(predicate2));
            predicate3 ??= ThrowArgumentNullException(predicate3, nameof(predicate3));

            var (result1, result2, result3) = (default(TSource)!, default(TSource)!, default(TSource)!);
            if (source is IList<TSource> list)
            {
                var helper = new LastOrDefaultListHelper<TSource>(list);
                helper.SetValues(ref result1, ref result2, ref result3, predicate1, predicate2, predicate3);
            }
            else
            {
                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    var helper = new LastOrDefaultEnumerableHelper<TSource>(enumerator);
                    helper.SetValues(ref result1, ref result2, ref result3, predicate1, predicate2, predicate3);
                }
            }

            return (result1, result2, result3);
        }

        public static (TSource, TSource, TSource, TSource) LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            predicate1 ??= ThrowArgumentNullException(predicate1, nameof(predicate1));
            predicate2 ??= ThrowArgumentNullException(predicate2, nameof(predicate2));
            predicate3 ??= ThrowArgumentNullException(predicate3, nameof(predicate3));
            predicate4 ??= ThrowArgumentNullException(predicate4, nameof(predicate4));

            var (result1, result2, result3, result4) = (default(TSource)!, default(TSource)!, default(TSource)!, default(TSource)!);
            if (source is IList<TSource> list)
            {
                var helper = new LastOrDefaultListHelper<TSource>(list);
                helper.SetValues(ref result1, ref result2, ref result3, ref result4, predicate1, predicate2, predicate3, predicate4);
            }
            else
            {
                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    var helper = new LastOrDefaultEnumerableHelper<TSource>(enumerator);
                    helper.SetValues(ref result1, ref result2, ref result3, ref result4, predicate1, predicate2, predicate3, predicate4);
                }
            }

            return (result1, result2, result3, result4);
        }

        public static (TSource, TSource, TSource, TSource, TSource) LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            predicate1 ??= ThrowArgumentNullException(predicate1, nameof(predicate1));
            predicate2 ??= ThrowArgumentNullException(predicate2, nameof(predicate2));
            predicate3 ??= ThrowArgumentNullException(predicate3, nameof(predicate3));
            predicate4 ??= ThrowArgumentNullException(predicate4, nameof(predicate4));
            predicate5 ??= ThrowArgumentNullException(predicate5, nameof(predicate5));

            var (result1, result2, result3, result4, result5) = (default(TSource)!, default(TSource)!, default(TSource)!, default(TSource)!, default(TSource)!);
            if (source is IList<TSource> list)
            {
                var helper = new LastOrDefaultListHelper<TSource>(list);
                helper.SetValues(ref result1, ref result2, ref result3, ref result4, ref result5, predicate1, predicate2, predicate3, predicate4, predicate5);
            }
            else
            {
                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    var helper = new LastOrDefaultEnumerableHelper<TSource>(enumerator);
                    helper.SetValues(ref result1, ref result2, ref result3, ref result4, ref result5, predicate1, predicate2, predicate3, predicate4, predicate5);
                }
            }

            return (result1, result2, result3, result4, result5);
        }

        public static (TSource, TSource, TSource, TSource, TSource, TSource) LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5, Func<TSource, bool> predicate6)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            predicate1 ??= ThrowArgumentNullException(predicate1, nameof(predicate1));
            predicate2 ??= ThrowArgumentNullException(predicate2, nameof(predicate2));
            predicate3 ??= ThrowArgumentNullException(predicate3, nameof(predicate3));
            predicate4 ??= ThrowArgumentNullException(predicate4, nameof(predicate4));
            predicate5 ??= ThrowArgumentNullException(predicate5, nameof(predicate5));
            predicate6 ??= ThrowArgumentNullException(predicate6, nameof(predicate6));

            var (result1, result2, result3, result4, result5, result6) = (default(TSource)!, default(TSource)!, default(TSource)!, default(TSource)!, default(TSource)!, default(TSource)!);
            if (source is IList<TSource> list)
            {
                var helper = new LastOrDefaultListHelper<TSource>(list);
                helper.SetValues(ref result1, ref result2, ref result3, ref result4, ref result5, ref result6, predicate1, predicate2, predicate3, predicate4, predicate5, predicate6);
            }
            else
            {
                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    var helper = new LastOrDefaultEnumerableHelper<TSource>(enumerator);
                    helper.SetValues(ref result1, ref result2, ref result3, ref result4, ref result5, ref result6, predicate1, predicate2, predicate3, predicate4, predicate5, predicate6);
                }
            }

            return (result1, result2, result3, result4, result5, result6);
        }

        public static (TSource, TSource, TSource, TSource, TSource, TSource, TSource) LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5, Func<TSource, bool> predicate6,
            Func<TSource, bool> predicate7)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            predicate1 ??= ThrowArgumentNullException(predicate1, nameof(predicate1));
            predicate2 ??= ThrowArgumentNullException(predicate2, nameof(predicate2));
            predicate3 ??= ThrowArgumentNullException(predicate3, nameof(predicate3));
            predicate4 ??= ThrowArgumentNullException(predicate4, nameof(predicate4));
            predicate5 ??= ThrowArgumentNullException(predicate5, nameof(predicate5));
            predicate6 ??= ThrowArgumentNullException(predicate6, nameof(predicate6));
            predicate7 ??= ThrowArgumentNullException(predicate7, nameof(predicate7));

            var (result1, result2, result3, result4, result5, result6, result7) =
                (default(TSource)!, default(TSource)!, default(TSource)!, default(TSource)!, default(TSource)!, default(TSource)!, default(TSource)!);
            if (source is IList<TSource> list)
            {
                var helper = new LastOrDefaultListHelper<TSource>(list);
                helper.SetValues(ref result1, ref result2, ref result3, ref result4, ref result5, ref result6, ref result7, predicate1, predicate2, predicate3, predicate4, predicate5, predicate6,
                    predicate7);
            }
            else
            {
                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    var helper = new LastOrDefaultEnumerableHelper<TSource>(enumerator);
                    helper.SetValues(ref result1, ref result2, ref result3, ref result4, ref result5, ref result6, ref result7, predicate1, predicate2, predicate3, predicate4, predicate5, predicate6,
                        predicate7);
                }
            }

            return (result1, result2, result3, result4, result5, result6, result7);
        }
    }
}