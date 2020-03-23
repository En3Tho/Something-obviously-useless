using System;
using System.Collections.Generic;
using static En3Tho.HelperClasses.ThrowHelper;

namespace En3Tho.ValueTupleExtensions.LinqToValueTupleExtensions
{
    public static partial class ValueTupleEnumerableExtensions
    {
        public static (TSource, TSource) FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate1, Func<TSource, bool> predicate2)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            predicate1 ??= ThrowArgumentNullException(predicate1, nameof(predicate1));
            predicate2 ??= ThrowArgumentNullException(predicate2, nameof(predicate2));
            return FirstOrDefaultInternal(source, predicate1, predicate2, false);
        }

        public static (TSource, TSource, TSource) FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            predicate1 ??= ThrowArgumentNullException(predicate1, nameof(predicate1));
            predicate2 ??= ThrowArgumentNullException(predicate2, nameof(predicate2));
            predicate3 ??= ThrowArgumentNullException(predicate3, nameof(predicate3));
            return FirstOrDefaultInternal(source, predicate1, predicate2, predicate3, false);
        }

        public static (TSource, TSource, TSource, TSource) FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            predicate1 ??= ThrowArgumentNullException(predicate1, nameof(predicate1));
            predicate2 ??= ThrowArgumentNullException(predicate2, nameof(predicate2));
            predicate3 ??= ThrowArgumentNullException(predicate3, nameof(predicate3));
            predicate4 ??= ThrowArgumentNullException(predicate4, nameof(predicate4));
            return FirstOrDefaultInternal(source, predicate1, predicate2, predicate3, predicate4, false);
        }

        public static (TSource, TSource, TSource, TSource, TSource) FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            predicate1 ??= ThrowArgumentNullException(predicate1, nameof(predicate1));
            predicate2 ??= ThrowArgumentNullException(predicate2, nameof(predicate2));
            predicate3 ??= ThrowArgumentNullException(predicate3, nameof(predicate3));
            predicate4 ??= ThrowArgumentNullException(predicate4, nameof(predicate4));
            predicate5 ??= ThrowArgumentNullException(predicate5, nameof(predicate5));
            return FirstOrDefaultInternal(source, predicate1, predicate2, predicate3, predicate4, predicate5, false);
        }

        public static (TSource, TSource, TSource, TSource, TSource, TSource) FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5, Func<TSource, bool> predicate6)
        {
            source ??= ThrowArgumentNullException(source, nameof(source));
            predicate1 ??= ThrowArgumentNullException(predicate1, nameof(predicate1));
            predicate2 ??= ThrowArgumentNullException(predicate2, nameof(predicate2));
            predicate3 ??= ThrowArgumentNullException(predicate3, nameof(predicate3));
            predicate4 ??= ThrowArgumentNullException(predicate4, nameof(predicate4));
            predicate5 ??= ThrowArgumentNullException(predicate5, nameof(predicate5));
            predicate6 ??= ThrowArgumentNullException(predicate6, nameof(predicate6));
            return FirstOrDefaultInternal(source, predicate1, predicate2, predicate3, predicate4, predicate5, predicate6, false);
        }

        public static (TSource, TSource, TSource, TSource, TSource, TSource, TSource) FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate1,
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
            return SingleOrDefaultInternal(source, predicate1, predicate2, predicate3, predicate4, predicate5, predicate6, predicate7, false);
        }

        private static (TSource, TSource) FirstOrDefaultInternal<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate1, Func<TSource, bool> predicate2, bool checkValidity)
        {
            bool found1 = false;
            bool found2 = false;
            var (result1, result2) = (default(TSource), default(TSource));

            if (source is IList<TSource> list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var current = list[i];
                    if (!found1 && predicate1(current))
                    {
                        found1 = true;
                        result1 = current;
                    }

                    if (!found2 && predicate2(current))
                    {
                        found2 = true;
                        result2 = current;
                    }
                    
                    if (found1 && found2)
                        return (result1, result2);
                }
            }
            else
            {
                using IEnumerator<TSource> e = source.GetEnumerator();
                while (e.MoveNext())
                {
                    var current = e.Current;
                    if (!found1 && predicate1(current))
                    {
                        found1 = true;
                        result1 = current;
                    }

                    if (!found2 && predicate2(current))
                    {
                        found2 = true;
                        result2 = current;
                    }
                    
                    if (found1 && found2)
                        return (result1, result2);
                }
            }

            if (checkValidity)
            {
                if (!found1) ThrowInvalidOperationException($"Item not found for {nameof(predicate1)}");
                if (!found2) ThrowInvalidOperationException($"Item not found for {nameof(predicate2)}");
            }

            return (result1, result2);
        }

        private static (TSource, TSource, TSource) FirstOrDefaultInternal<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, bool checkValidity)
        {
            bool found1 = false;
            bool found2 = false;
            bool found3 = false;
            var (result1, result2, result3) =
                (default(TSource), default(TSource), default(TSource));

            if (source is IList<TSource> list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var current = list[i];
                    if (!found1 && predicate1(current))
                    {
                        found1 = true;
                        result1 = current;
                    }

                    if (!found2 && predicate2(current))
                    {
                        found2 = true;
                        result2 = current;
                    }

                    if (!found3 && predicate3(current))
                    {
                        found3 = true;
                        result3 = current;
                    }
                    
                    if (found1 && found2 && found3)
                        return (result1, result2, result3);
                }
            }
            else
            {
                using IEnumerator<TSource> e = source.GetEnumerator();
                while (e.MoveNext())
                {
                    var current = e.Current;
                    if (!found1 && predicate1(current))
                    {
                        found1 = true;
                        result1 = current;
                    }

                    if (!found2 && predicate2(current))
                    {
                        found2 = true;
                        result2 = current;
                    }

                    if (!found3 && predicate3(current))
                    {
                        found3 = true;
                        result3 = current;
                    }
                    
                    if (found1 && found2 && found3)
                        return (result1, result2, result3);
                }
            }

            if (checkValidity)
            {
                if (!found1) ThrowInvalidOperationException($"Item not found for {nameof(predicate1)}");
                if (!found2) ThrowInvalidOperationException($"Item not found for {nameof(predicate2)}");
                if (!found3) ThrowInvalidOperationException($"Item not found for {nameof(predicate3)}");
            }

            return (result1, result2, result3);
        }

        private static (TSource, TSource, TSource, TSource) FirstOrDefaultInternal<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, bool checkValidity)
        {
            bool found1 = false;
            bool found2 = false;
            bool found3 = false;
            bool found4 = false;
            var (result1, result2, result3, result4) =
                (default(TSource), default(TSource), default(TSource), default(TSource));

            if (source is IList<TSource> list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var current = list[i];
                    if (!found1 && predicate1(current))
                    {
                        found1 = true;
                        result1 = current;
                    }

                    if (!found2 && predicate2(current))
                    {
                        found2 = true;
                        result2 = current;
                    }

                    if (!found3 && predicate3(current))
                    {
                        found3 = true;
                        result3 = current;
                    }

                    if (!found4 && predicate4(current))
                    {
                        found4 = true;
                        result4 = current;
                    }
                    
                    if (found1 && found2 && found3 && found4)
                        return (result1, result2, result3, result4);
                }
            }
            else
            {
                using IEnumerator<TSource> e = source.GetEnumerator();
                while (e.MoveNext())
                {
                    var current = e.Current;
                    if (!found1 && predicate1(current))
                    {
                        found1 = true;
                        result1 = current;
                    }

                    if (!found2 && predicate2(current))
                    {
                        found2 = true;
                        result2 = current;
                    }

                    if (!found3 && predicate3(current))
                    {
                        found3 = true;
                        result3 = current;
                    }

                    if (!found4 && predicate4(current))
                    {
                        found4 = true;
                        result4 = current;
                    }
                    
                    if (found1 && found2 && found3 && found4)
                        return (result1, result2, result3, result4);
                }
            }

            if (checkValidity)
            {
                if (!found1) ThrowInvalidOperationException($"Item not found for {nameof(predicate1)}");
                if (!found2) ThrowInvalidOperationException($"Item not found for {nameof(predicate2)}");
                if (!found3) ThrowInvalidOperationException($"Item not found for {nameof(predicate3)}");
                if (!found4) ThrowInvalidOperationException($"Item not found for {nameof(predicate4)}");
            }
            
            return (result1, result2, result3, result4);
        }

        private static (TSource, TSource, TSource, TSource, TSource) FirstOrDefaultInternal<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5, bool checkValidity)
        {
            bool found1 = false;
            bool found2 = false;
            bool found3 = false;
            bool found4 = false;
            bool found5 = false;
            var (result1, result2, result3, result4, result5) =
                (default(TSource), default(TSource), default(TSource), default(TSource), default(TSource));
            
            if (source is IList<TSource> list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var current = list[i];
                    if (!found1 && predicate1(current))
                    {
                        found1 = true;
                        result1 = current;
                    }

                    if (!found2 && predicate2(current))
                    {
                        found2 = true;
                        result2 = current;
                    }

                    if (!found3 && predicate3(current))
                    {
                        found3 = true;
                        result3 = current;
                    }

                    if (!found4 && predicate4(current))
                    {
                        found4 = true;
                        result4 = current;
                    }

                    if (!found5 && predicate5(current))
                    {
                        found5 = true;
                        result5 = current;
                    }

                    if (found1 && found2 && found3 && found4 && found5)
                        return (result1, result2, result3, result4, result5);
                }
            }
            else
            {
                using IEnumerator<TSource> e = source.GetEnumerator();
                while (e.MoveNext())
                {
                    var current = e.Current;
                    if (!found1 && predicate1(current))
                    {
                        found1 = true;
                        result1 = current;
                    }

                    if (!found2 && predicate2(current))
                    {
                        found2 = true;
                        result2 = current;
                    }

                    if (!found3 && predicate3(current))
                    {
                        found3 = true;
                        result3 = current;
                    }

                    if (!found4 && predicate4(current))
                    {
                        found4 = true;
                        result4 = current;
                    }

                    if (!found5 && predicate5(current))
                    {
                        found5 = true;
                        result5 = current;
                    }
                    
                    if (found1 && found2 && found3 && found4 && found5)
                        return (result1, result2, result3, result4, result5);
                }
            }

            if (checkValidity)
            {
                if (!found1) ThrowInvalidOperationException($"Item not found for {nameof(predicate1)}");
                if (!found2) ThrowInvalidOperationException($"Item not found for {nameof(predicate2)}");
                if (!found3) ThrowInvalidOperationException($"Item not found for {nameof(predicate3)}");
                if (!found4) ThrowInvalidOperationException($"Item not found for {nameof(predicate4)}");
                if (!found5) ThrowInvalidOperationException($"Item not found for {nameof(predicate5)}");
            }

            return (result1, result2, result3, result4, result5);
        }

        private static (TSource, TSource, TSource, TSource, TSource, TSource) FirstOrDefaultInternal<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5, Func<TSource, bool> predicate6, bool checkValidity)
        {
            bool found1 = false;
            bool found2 = false;
            bool found3 = false;
            bool found4 = false;
            bool found5 = false;
            bool found6 = false;
            var (result1, result2, result3, result4, result5, result6) =
                (default(TSource), default(TSource), default(TSource), default(TSource), default(TSource), default(TSource));

            if (source is IList<TSource> list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var current = list[i];
                    if (!found1 && predicate1(current))
                    {
                        found1 = true;
                        result1 = current;
                    }

                    if (!found2 && predicate2(current))
                    {
                        found2 = true;
                        result2 = current;
                    }

                    if (!found3 && predicate3(current))
                    {
                        found3 = true;
                        result3 = current;
                    }

                    if (!found4 && predicate4(current))
                    {
                        found4 = true;
                        result4 = current;
                    }

                    if (!found5 && predicate5(current))
                    {
                        found5 = true;
                        result5 = current;
                    }

                    if (!found6 && predicate6(current))
                    {
                        found6 = true;
                        result6 = current;
                    }
                    if (found1 && found2 && found3 && found4 && found5 && found6)
                        return (result1, result2, result3, result4, result5, result6);
                }
            }
            else
            {
                using IEnumerator<TSource> e = source.GetEnumerator();
                while (e.MoveNext())
                {
                    var current = e.Current;
                    if (!found1 && predicate1(current))
                    {
                        found1 = true;
                        result1 = current;
                    }

                    if (!found2 && predicate2(current))
                    {
                        found2 = true;
                        result2 = current;
                    }

                    if (!found3 && predicate3(current))
                    {
                        found3 = true;
                        result3 = current;
                    }

                    if (!found4 && predicate4(current))
                    {
                        found4 = true;
                        result4 = current;
                    }

                    if (!found5 && predicate5(current))
                    {
                        found5 = true;
                        result5 = current;
                    }

                    if (!found6 && predicate6(current))
                    {
                        found6 = true;
                        result6 = current;
                    }
                    
                    if (found1 && found2 && found3 && found4 && found5 && found6)
                        return (result1, result2, result3, result4, result5, result6);
                }
            }

            if (checkValidity)
            {
                if (!found1) ThrowInvalidOperationException($"Item not found for {nameof(predicate1)}");
                if (!found2) ThrowInvalidOperationException($"Item not found for {nameof(predicate2)}");
                if (!found3) ThrowInvalidOperationException($"Item not found for {nameof(predicate3)}");
                if (!found4) ThrowInvalidOperationException($"Item not found for {nameof(predicate4)}");
                if (!found5) ThrowInvalidOperationException($"Item not found for {nameof(predicate5)}");
                if (!found6) ThrowInvalidOperationException($"Item not found for {nameof(predicate6)}");
            }

            return (result1, result2, result3, result4, result5, result6);
        }

        private static (TSource, TSource, TSource, TSource, TSource, TSource, TSource) FirstOrDefaultInternal<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5, Func<TSource, bool> predicate6,
            Func<TSource, bool> predicate7, bool checkValidity)
        {
            bool found1 = false;
            bool found2 = false;
            bool found3 = false;
            bool found4 = false;
            bool found5 = false;
            bool found6 = false;
            bool found7 = false;
            var (result1, result2, result3, result4, result5, result6, result7) =
                (default(TSource), default(TSource), default(TSource), default(TSource), default(TSource), default(TSource), default(TSource));

            if (source is IList<TSource> list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var current = list[i];
                    if (!found1 && predicate1(current))
                    {
                        found1 = true;
                        result1 = current;
                    }

                    if (!found2 && predicate2(current))
                    {
                        found2 = true;
                        result2 = current;
                    }

                    if (!found3 && predicate3(current))
                    {
                        found3 = true;
                        result3 = current;
                    }

                    if (!found4 && predicate4(current))
                    {
                        found4 = true;
                        result4 = current;
                    }

                    if (!found5 && predicate5(current))
                    {
                        found5 = true;
                        result5 = current;
                    }

                    if (!found6 && predicate6(current))
                    {
                        found6 = true;
                        result6 = current;
                    }

                    if (!found7 && predicate7(current))
                    {
                        found7 = true;
                        result7 = current;
                    }
                    
                    if (found1 && found2 && found3 && found4 && found5 && found6 && found7)
                        return (result1, result2, result3, result4, result5, result6, result7);
                }
            }
            else
            {
                using IEnumerator<TSource> e = source.GetEnumerator();
                while (e.MoveNext())
                {
                    var current = e.Current;
                    if (!found1 && predicate1(current))
                    {
                        found1 = true;
                        result1 = current;
                    }

                    if (!found2 && predicate2(current))
                    {
                        found2 = true;
                        result2 = current;
                    }

                    if (!found3 && predicate3(current))
                    {
                        found3 = true;
                        result3 = current;
                    }

                    if (!found4 && predicate4(current))
                    {
                        found4 = true;
                        result4 = current;
                    }

                    if (!found5 && predicate5(current))
                    {
                        found5 = true;
                        result5 = current;
                    }

                    if (!found6 && predicate6(current))
                    {
                        found6 = true;
                        result6 = current;
                    }

                    if (!found7 && predicate7(current))
                    {
                        found7 = true;
                        result7 = current;
                    }
                    
                    if (found1 && found2 && found3 && found4 && found5 && found6 && found7)
                        return (result1, result2, result3, result4, result5, result6, result7);
                }
            }
            
            if (checkValidity)
            {
                if (!found1) ThrowInvalidOperationException($"Item not found for {nameof(predicate1)}");
                if (!found2) ThrowInvalidOperationException($"Item not found for {nameof(predicate2)}");
                if (!found3) ThrowInvalidOperationException($"Item not found for {nameof(predicate3)}");
                if (!found4) ThrowInvalidOperationException($"Item not found for {nameof(predicate4)}");
                if (!found5) ThrowInvalidOperationException($"Item not found for {nameof(predicate5)}");
                if (!found6) ThrowInvalidOperationException($"Item not found for {nameof(predicate6)}");
                if (!found7) ThrowInvalidOperationException($"Item not found for {nameof(predicate7)}");
            }

            return (result1, result2, result3, result4, result5, result6, result7);
        }
    }
}