using System;
using System.Collections.Generic;

namespace En3Tho.ValueTupleExtensions.LinqToValueTupleExtensions
{
    internal struct LastOrDefaultListHelper<TSource>
    {
        public int ItemsFound;
        private readonly IList<TSource> _list;
        private int _index;
      
        public LastOrDefaultListHelper(IList<TSource> list)
        {
            ItemsFound = 0;
            _list = list;
            _index = _list.Count - 1;
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref TSource value4, ref TSource value5, ref TSource value6, ref TSource value7,
            Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5, Func<TSource, bool> predicate6,
            Func<TSource, bool> predicate7)
        {
            do
            {
                var value = _list[_index];
                if (predicate1(value))
                {
                    value1 = value;
                    ItemsFound++;
                    SetValues(ref value2, ref value3, ref value4, ref value5, ref value6, ref value7, predicate2, predicate3, predicate4, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value3, ref value4, ref value5, ref value6, ref value7, predicate1, predicate3, predicate4, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value2, ref value4, ref value5, ref value6, ref value7, predicate1, predicate2, predicate4, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value2, ref value3, ref value5, ref value6, ref value7, predicate1, predicate2, predicate3, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate5(value))
                {
                    value5 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value6, ref value7, predicate1, predicate2, predicate3, predicate4, predicate6, predicate7);
                    return;
                }

                if (predicate6(value))
                {
                    value6 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value5, ref value7, predicate1, predicate2, predicate3, predicate4, predicate5, predicate7);
                    return;
                }

                if (predicate7(value))
                {
                    value7 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value5, ref value6, predicate1, predicate2, predicate3, predicate4, predicate5, predicate6);
                    return;
                }

                _index--;
            } while (_index >= 0);
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref TSource value4, ref TSource value5, ref TSource value6, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5, Func<TSource, bool> predicate6)
        {
            do
            {
                var value = _list[_index];
                if (predicate1(value))
                {
                    value1 = value;
                    ItemsFound++;
                    SetValues(ref value2, ref value3, ref value4, ref value5, ref value6, predicate2, predicate3, predicate4, predicate5, predicate6);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value3, ref value4, ref value5, ref value6, predicate1, predicate3, predicate4, predicate5, predicate6);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value2, ref value4, ref value5, ref value6, predicate1, predicate2, predicate4, predicate5, predicate6);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value2, ref value3, ref value5, ref value6, predicate1, predicate2, predicate3, predicate5, predicate6);
                    return;
                }

                if (predicate5(value))
                {
                    value5 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value6, predicate1, predicate2, predicate3, predicate4, predicate6);
                    return;
                }

                if (predicate6(value))
                {
                    value6 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value5, predicate1, predicate2, predicate3, predicate4, predicate5);
                    return;
                }

                _index--;
            } while (_index >= 0);
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref TSource value4, ref TSource value5, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5)
        {
            do
            {
                var value = _list[_index];
                if (predicate1(value))
                {
                    value1 = value;
                    ItemsFound++;
                    SetValues(ref value2, ref value3, ref value4, ref value5, predicate2, predicate3, predicate4, predicate5);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value3, ref value4, ref value5, predicate1, predicate3, predicate4, predicate5);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value2, ref value4, ref value5, predicate1, predicate2, predicate4, predicate5);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value2, ref value3, ref value5, predicate1, predicate2, predicate3, predicate5);
                    return;
                }

                if (predicate5(value))
                {
                    value5 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value2, ref value3, ref value4, predicate1, predicate2, predicate3, predicate4);
                    return;
                }

                _index--;
            } while (_index >= 0);
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref TSource value4, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4)
        {
            do
            {
                var value = _list[_index];
                if (predicate1(value))
                {
                    value1 = value;
                    ItemsFound++;
                    SetValues(ref value2, ref value3, ref value4, predicate2, predicate3, predicate4);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value3, ref value4, predicate1, predicate3, predicate4);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value2, ref value4, predicate1, predicate2, predicate4);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value2, ref value3, predicate1, predicate2, predicate3);
                    return;
                }

                _index--;
            } while (_index >= 0);
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3)
        {
            do
            {
                var value = _list[_index];
                if (predicate1(value))
                {
                    value1 = value;
                    ItemsFound++;
                    SetValues(ref value2, ref value3, predicate2, predicate3);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value3, predicate1, predicate3);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    ItemsFound++;
                    SetValues(ref value1, ref value2, predicate1, predicate2);
                    return;
                }

                _index--;
            } while (_index >= 0);
        }

        public void SetValues(ref TSource value1, ref TSource value2, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2)
        {
            do
            {
                var value = _list[_index];
                if (predicate1(value))
                {
                    value1 = value;
                    ItemsFound++;
                    SetValues(ref value2, predicate2);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    ItemsFound++;
                    SetValues(ref value1, predicate1);
                    return;
                }

                _index--;
            } while (_index >= 0);
        }

        public void SetValues(ref TSource value1, Func<TSource, bool> predicate1)
        {
            do
            {
                var value = _list[_index];
                if (predicate1(value))
                {
                    value1 = value;
                    ItemsFound++;
                    return;
                }

                _index--;
            } while (_index >= 0);
        }
    }
}