using System;
using System.Collections.Generic;
using System.Linq;

namespace En3Tho.ValueTupleExtensions.LinqToValueTupleExtensions
{
    internal readonly struct FirstOrDefaultEnumerableHelper<TSource>
    {
        private readonly IEnumerator<TSource> _enumerator;

        public FirstOrDefaultEnumerableHelper(IEnumerator<TSource> enumerator)
        {
            _enumerator = enumerator;
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref TSource value4, ref TSource value5, ref TSource value6, ref TSource value7,
            Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5, Func<TSource, bool> predicate6,
            Func<TSource, bool> predicate7)
        {
            do
            {
                var value = _enumerator.Current;
                if (predicate1(value))
                {
                    value1 = value;
                    SetValues(ref value2, ref value3, ref value4, ref value5, ref value6, ref value7, predicate2, predicate3, predicate4, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    SetValues(ref value1, ref value3, ref value4, ref value5, ref value6, ref value7, predicate1, predicate3, predicate4, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    SetValues(ref value1, ref value2, ref value4, ref value5, ref value6, ref value7, predicate1, predicate2, predicate4, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value5, ref value6, ref value7, predicate1, predicate2, predicate3, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate5(value))
                {
                    value5 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value6, ref value7, predicate1, predicate2, predicate3, predicate4, predicate6, predicate7);
                    return;
                }

                if (predicate6(value))
                {
                    value6 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value5, ref value7, predicate1, predicate2, predicate3, predicate4, predicate5, predicate7);
                    return;
                }

                if (predicate7(value))
                {
                    value7 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value5, ref value6, predicate1, predicate2, predicate3, predicate4, predicate5, predicate6);
                    return;
                }
            }
            while (_enumerator.MoveNext());
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref TSource value4, ref TSource value5, ref TSource value6, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5, Func<TSource, bool> predicate6)
        {
            do
            {
                var value = _enumerator.Current;
                if (predicate1(value))
                {
                    value1 = value;
                    SetValues(ref value2, ref value3, ref value4, ref value5, ref value6, predicate2, predicate3, predicate4, predicate5, predicate6);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    SetValues(ref value1, ref value3, ref value4, ref value5, ref value6, predicate1, predicate3, predicate4, predicate5, predicate6);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    SetValues(ref value1, ref value2, ref value4, ref value5, ref value6, predicate1, predicate2, predicate4, predicate5, predicate6);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value5, ref value6, predicate1, predicate2, predicate3, predicate5, predicate6);
                    return;
                }

                if (predicate5(value))
                {
                    value5 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value6, predicate1, predicate2, predicate3, predicate4, predicate6);
                    return;
                }

                if (predicate6(value))
                {
                    value6 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value5, predicate1, predicate2, predicate3, predicate4, predicate5);
                    return;
                }
            }
            while (_enumerator.MoveNext());
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref TSource value4, ref TSource value5, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5)
        {
            do
            {
                var value = _enumerator.Current;
                if (predicate1(value))
                {
                    value1 = value;
                    SetValues(ref value2, ref value3, ref value4, ref value5, predicate2, predicate3, predicate4, predicate5);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    SetValues(ref value1, ref value3, ref value4, ref value5, predicate1, predicate3, predicate4, predicate5);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    SetValues(ref value1, ref value2, ref value4, ref value5, predicate1, predicate2, predicate4, predicate5);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value5, predicate1, predicate2, predicate3, predicate5);
                    return;
                }

                if (predicate5(value))
                {
                    value5 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value4, predicate1, predicate2, predicate3, predicate4);
                    return;
                }
            }
            while (_enumerator.MoveNext());
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref TSource value4, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4)
        {
            do
            {
                var value = _enumerator.Current;
                if (predicate1(value))
                {
                    value1 = value;
                    SetValues(ref value2, ref value3, ref value4, predicate2, predicate3, predicate4);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    SetValues(ref value1, ref value3, ref value4, predicate1, predicate3, predicate4);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    SetValues(ref value1, ref value2, ref value4, predicate1, predicate2, predicate4);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    SetValues(ref value1, ref value2, ref value3, predicate1, predicate2, predicate3);
                    return;
                }
            }
            while (_enumerator.MoveNext());
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3)
        {
            do
            {
                var value = _enumerator.Current;
                if (predicate1(value))
                {
                    value1 = value;
                    SetValues(ref value2, ref value3, predicate2, predicate3);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    SetValues(ref value1, ref value3, predicate1, predicate3);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    SetValues(ref value1, ref value2, predicate1, predicate2);
                    return;
                }
            }
            while (_enumerator.MoveNext());
        }

        public void SetValues(ref TSource value1, ref TSource value2, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2)
        {
            do
            {
                var value = _enumerator.Current;
                if (predicate1(value))
                {
                    value1 = value;
                    SetValues(ref value2, predicate2);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    SetValues(ref value1, predicate1);
                    return;
                }
            }
            while (_enumerator.MoveNext());
        }

        public void SetValues(ref TSource value1, Func<TSource, bool> predicate1)
        {
            do
            {
                var value = _enumerator.Current;
                if (predicate1(value))
                {
                    value1 = value;
                    return;
                }
            }
            while (_enumerator.MoveNext());
        }
    }

    internal struct FirstOrDefaultListHelper<TSource>
    {
        private readonly IList<TSource> _list;
        private int _index;
        private readonly int _count;

        public FirstOrDefaultListHelper(IList<TSource> list)
        {
            _index = 0;
            _list = list;
            _count = _list.Count;
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
                    SetValues(ref value2, ref value3, ref value4, ref value5, ref value6, ref value7, predicate2, predicate3, predicate4, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    SetValues(ref value1, ref value3, ref value4, ref value5, ref value6, ref value7, predicate1, predicate3, predicate4, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    SetValues(ref value1, ref value2, ref value4, ref value5, ref value6, ref value7, predicate1, predicate2, predicate4, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value5, ref value6, ref value7, predicate1, predicate2, predicate3, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate5(value))
                {
                    value5 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value6, ref value7, predicate1, predicate2, predicate3, predicate4, predicate6, predicate7);
                    return;
                }

                if (predicate6(value))
                {
                    value6 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value5, ref value7, predicate1, predicate2, predicate3, predicate4, predicate5, predicate7);
                    return;
                }

                if (predicate7(value))
                {
                    value7 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value5, ref value6, predicate1, predicate2, predicate3, predicate4, predicate5, predicate6);
                    return;
                }

                _index++;
            }
            while (_index < _count);
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
                    SetValues(ref value2, ref value3, ref value4, ref value5, ref value6, predicate2, predicate3, predicate4, predicate5, predicate6);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    SetValues(ref value1, ref value3, ref value4, ref value5, ref value6, predicate1, predicate3, predicate4, predicate5, predicate6);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    SetValues(ref value1, ref value2, ref value4, ref value5, ref value6, predicate1, predicate2, predicate4, predicate5, predicate6);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value5, ref value6, predicate1, predicate2, predicate3, predicate5, predicate6);
                    return;
                }

                if (predicate5(value))
                {
                    value5 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value6, predicate1, predicate2, predicate3, predicate4, predicate6);
                    return;
                }

                if (predicate6(value))
                {
                    value6 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value5, predicate1, predicate2, predicate3, predicate4, predicate5);
                    return;
                }

                _index++;
            }
            while (_index < _count);
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
                    SetValues(ref value2, ref value3, ref value4, ref value5, predicate2, predicate3, predicate4, predicate5);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    SetValues(ref value1, ref value3, ref value4, ref value5, predicate1, predicate3, predicate4, predicate5);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    SetValues(ref value1, ref value2, ref value4, ref value5, predicate1, predicate2, predicate4, predicate5);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value5, predicate1, predicate2, predicate3, predicate5);
                    return;
                }

                if (predicate5(value))
                {
                    value5 = value;
                    SetValues(ref value1, ref value2, ref value3, ref value4, predicate1, predicate2, predicate3, predicate4);
                    return;
                }

                _index++;
            }
            while (_index < _count);
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
                    SetValues(ref value2, ref value3, ref value4, predicate2, predicate3, predicate4);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    SetValues(ref value1, ref value3, ref value4, predicate1, predicate3, predicate4);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    SetValues(ref value1, ref value2, ref value4, predicate1, predicate2, predicate4);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    SetValues(ref value1, ref value2, ref value3, predicate1, predicate2, predicate3);
                    return;
                }

                _index++;
            }
            while (_index < _count);
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
                    SetValues(ref value2, ref value3, predicate2, predicate3);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    SetValues(ref value1, ref value3, predicate1, predicate3);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    SetValues(ref value1, ref value2, predicate1, predicate2);
                    return;
                }

                _index++;
            }
            while (_index < _count);
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
                    SetValues(ref value2, predicate2);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    SetValues(ref value1, predicate1);
                    return;
                }

                _index++;
            }
            while (_index < _count);
        }

        public void SetValues(ref TSource value1, Func<TSource, bool> predicate1)
        {
            do
            {
                var value = _list[_index];
                if (predicate1(value))
                {
                    value1 = value;
                    return;
                }

                _index++;
            }
            while (_index < _count);
        }
    }

    internal struct FirstEnumerableHelper<TSource>
    {
        private readonly IEnumerator<TSource> _enumerator;

        public FirstEnumerableHelper(IEnumerator<TSource> enumerator)
        {
            _enumerator = enumerator;
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref TSource value4, ref TSource value5, ref TSource value6, ref TSource value7, ref bool found1,
            ref bool found2, ref bool found3, ref bool found4, ref bool found5, ref bool found6, ref bool found7,
            Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5, Func<TSource, bool> predicate6,
            Func<TSource, bool> predicate7)
        {
            do
            {
                var value = _enumerator.Current;
                if (predicate1(value))
                {
                    value1 = value;
                    found1 = true;
                    SetValues(ref value2, ref value3, ref value4, ref value5, ref value6, ref value7, ref found2, ref found3, ref found4, ref found5, ref found6, ref found7, predicate2, predicate3,
                        predicate4, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    found2 = true;
                    SetValues(ref value1, ref value3, ref value4, ref value5, ref value6, ref value7, ref found1, ref found3, ref found4, ref found5, ref found6, ref found7, predicate1, predicate3,
                        predicate4, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    found3 = true;
                    SetValues(ref value1, ref value2, ref value4, ref value5, ref value6, ref value7, ref found1, ref found2, ref found4, ref found5, ref found6, ref found7, predicate1, predicate2,
                        predicate4, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    found4 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value5, ref value6, ref value7, ref found1, ref found2, ref found3, ref found5, ref found6, ref found7, predicate1, predicate2,
                        predicate3, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate5(value))
                {
                    value5 = value;
                    found5 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value6, ref value7, ref found1, ref found2, ref found3, ref found4, ref found6, ref found7, predicate1, predicate2,
                        predicate3, predicate4, predicate6, predicate7);
                    return;
                }

                if (predicate6(value))
                {
                    value6 = value;
                    found6 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value5, ref value7, ref found1, ref found2, ref found3, ref found4, ref found5, ref found7, predicate1, predicate2,
                        predicate3, predicate4, predicate5, predicate7);
                    return;
                }

                if (predicate7(value))
                {
                    value7 = value;
                    found7 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value5, ref value6, ref found1, ref found2, ref found3, ref found4, ref found5, ref found6, predicate1, predicate2,
                        predicate3, predicate4, predicate5, predicate6);
                    return;
                }
            }
            while (_enumerator.MoveNext());
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref TSource value4, ref TSource value5, ref TSource value6, ref bool found1, ref bool found2, ref bool found3,
            ref bool found4, ref bool found5, ref bool found6, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5, Func<TSource, bool> predicate6)
        {
            do
            {
                var value = _enumerator.Current;
                if (predicate1(value))
                {
                    value1 = value;
                    found1 = true;
                    SetValues(ref value2, ref value3, ref value4, ref value5, ref value6, ref found2, ref found3, ref found4, ref found5, ref found6, predicate2, predicate3, predicate4, predicate5,
                        predicate6);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    found2 = true;
                    SetValues(ref value1, ref value3, ref value4, ref value5, ref value6, ref found1, ref found3, ref found4, ref found5, ref found6, predicate1, predicate3, predicate4, predicate5,
                        predicate6);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    found3 = true;
                    SetValues(ref value1, ref value2, ref value4, ref value5, ref value6, ref found1, ref found2, ref found4, ref found5, ref found6, predicate1, predicate2, predicate4, predicate5,
                        predicate6);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    found4 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value5, ref value6, ref found1, ref found2, ref found3, ref found5, ref found6, predicate1, predicate2, predicate3, predicate5,
                        predicate6);
                    return;
                }

                if (predicate5(value))
                {
                    value5 = value;
                    found5 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value6, ref found1, ref found2, ref found3, ref found4, ref found6, predicate1, predicate2, predicate3, predicate4,
                        predicate6);
                    return;
                }

                if (predicate6(value))
                {
                    value6 = value;
                    found6 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value5, ref found1, ref found2, ref found3, ref found4, ref found5, predicate1, predicate2, predicate3, predicate4,
                        predicate5);
                    return;
                }
            }
            while (_enumerator.MoveNext());
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref TSource value4, ref TSource value5, ref bool found1, ref bool found2, ref bool found3, ref bool found4,
            ref bool found5, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5)
        {
            do
            {
                var value = _enumerator.Current;
                if (predicate1(value))
                {
                    value1 = value;
                    found1 = true;
                    SetValues(ref value2, ref value3, ref value4, ref value5, ref found2, ref found3, ref found4, ref found5, predicate2, predicate3, predicate4, predicate5);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    found2 = true;
                    SetValues(ref value1, ref value3, ref value4, ref value5, ref found1, ref found3, ref found4, ref found5, predicate1, predicate3, predicate4, predicate5);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    found3 = true;
                    SetValues(ref value1, ref value2, ref value4, ref value5, ref found1, ref found2, ref found4, ref found5, predicate1, predicate2, predicate4, predicate5);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    found4 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value5, ref found1, ref found2, ref found3, ref found5, predicate1, predicate2, predicate3, predicate5);
                    return;
                }

                if (predicate5(value))
                {
                    value5 = value;
                    found5 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref found1, ref found2, ref found3, ref found4, predicate1, predicate2, predicate3, predicate4);
                    return;
                }
            }
            while (_enumerator.MoveNext());
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref TSource value4, ref bool found1, ref bool found2, ref bool found3, ref bool found4,
            Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4)
        {
            do
            {
                var value = _enumerator.Current;
                if (predicate1(value))
                {
                    value1 = value;
                    found1 = true;
                    SetValues(ref value2, ref value3, ref value4, ref found2, ref found3, ref found4, predicate2, predicate3, predicate4);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    found2 = true;
                    SetValues(ref value1, ref value3, ref value4, ref found1, ref found3, ref found4, predicate1, predicate3, predicate4);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    found3 = true;
                    SetValues(ref value1, ref value2, ref value4, ref found1, ref found2, ref found4, predicate1, predicate2, predicate4);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    found4 = true;
                    SetValues(ref value1, ref value2, ref value3, ref found1, ref found2, ref found3, predicate1, predicate2, predicate3);
                    return;
                }
            }
            while (_enumerator.MoveNext());
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref bool found1, ref bool found2, ref bool found3, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3)
        {
            do
            {
                var value = _enumerator.Current;
                if (predicate1(value))
                {
                    value1 = value;
                    found1 = true;
                    SetValues(ref value2, ref value3, ref found2, ref found3, predicate2, predicate3);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    found2 = true;
                    SetValues(ref value1, ref value3, ref found1, ref found3, predicate1, predicate3);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    found3 = true;
                    SetValues(ref value1, ref value2, ref found1, ref found2, predicate1, predicate2);
                    return;
                }
            }
            while (_enumerator.MoveNext());
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref bool found1, ref bool found2, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2)
        {
            do
            {
                var value = _enumerator.Current;
                if (predicate1(value))
                {
                    value1 = value;
                    found1 = true;
                    SetValues(ref value2, ref found2, predicate2);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    found2 = true;
                    SetValues(ref value1, ref found1, predicate1);
                    return;
                }
            }
            while (_enumerator.MoveNext());
        }

        public void SetValues(ref TSource value1, ref bool found1, Func<TSource, bool> predicate1)
        {
            do
            {
                var value = _enumerator.Current;
                if (predicate1(value))
                {
                    value1 = value;
                    found1 = true;
                    return;
                }
            }
            while (_enumerator.MoveNext());
        }
    }

    internal struct FirstListHelper<TSource>
    {
        private readonly IList<TSource> _list;
        private int _index;
        private readonly int _count;

        public FirstListHelper(IList<TSource> list)
        {
            _index = 0;
            _list = list;
            _count = _list.Count;
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref TSource value4, ref TSource value5, ref TSource value6, ref TSource value7, ref bool found1,
            ref bool found2, ref bool found3, ref bool found4, ref bool found5, ref bool found6, ref bool found7,
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
                    found1 = true;
                    SetValues(ref value2, ref value3, ref value4, ref value5, ref value6, ref value7, ref found2, ref found3, ref found4, ref found5, ref found6, ref found7, predicate2, predicate3,
                        predicate4, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    found2 = true;
                    SetValues(ref value1, ref value3, ref value4, ref value5, ref value6, ref value7, ref found1, ref found3, ref found4, ref found5, ref found6, ref found7, predicate1, predicate3,
                        predicate4, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    found3 = true;
                    SetValues(ref value1, ref value2, ref value4, ref value5, ref value6, ref value7, ref found1, ref found2, ref found4, ref found5, ref found6, ref found7, predicate1, predicate2,
                        predicate4, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    found4 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value5, ref value6, ref value7, ref found1, ref found2, ref found3, ref found5, ref found6, ref found7, predicate1, predicate2,
                        predicate3, predicate5, predicate6, predicate7);
                    return;
                }

                if (predicate5(value))
                {
                    value5 = value;
                    found5 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value6, ref value7, ref found1, ref found2, ref found3, ref found4, ref found6, ref found7, predicate1, predicate2,
                        predicate3, predicate4, predicate6, predicate7);
                    return;
                }

                if (predicate6(value))
                {
                    value6 = value;
                    found6 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value5, ref value7, ref found1, ref found2, ref found3, ref found4, ref found5, ref found7, predicate1, predicate2,
                        predicate3, predicate4, predicate5, predicate7);
                    return;
                }

                if (predicate7(value))
                {
                    value7 = value;
                    found7 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value5, ref value6, ref found1, ref found2, ref found3, ref found4, ref found5, ref found6, predicate1, predicate2,
                        predicate3, predicate4, predicate5, predicate6);
                    return;
                }

                _index++;
            }
            while (_index < _count);
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref TSource value4, ref TSource value5, ref TSource value6, ref bool found1, ref bool found2, ref bool found3,
            ref bool found4, ref bool found5, ref bool found6, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5, Func<TSource, bool> predicate6)
        {
            do
            {
                var value = _list[_index];
                if (predicate1(value))
                {
                    value1 = value;
                    found1 = true;
                    SetValues(ref value2, ref value3, ref value4, ref value5, ref value6, ref found2, ref found3, ref found4, ref found5, ref found6, predicate2, predicate3, predicate4, predicate5,
                        predicate6);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    found2 = true;
                    SetValues(ref value1, ref value3, ref value4, ref value5, ref value6, ref found1, ref found3, ref found4, ref found5, ref found6, predicate1, predicate3, predicate4, predicate5,
                        predicate6);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    found3 = true;
                    SetValues(ref value1, ref value2, ref value4, ref value5, ref value6, ref found1, ref found2, ref found4, ref found5, ref found6, predicate1, predicate2, predicate4, predicate5,
                        predicate6);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    found4 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value5, ref value6, ref found1, ref found2, ref found3, ref found5, ref found6, predicate1, predicate2, predicate3, predicate5,
                        predicate6);
                    return;
                }

                if (predicate5(value))
                {
                    value5 = value;
                    found5 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value6, ref found1, ref found2, ref found3, ref found4, ref found6, predicate1, predicate2, predicate3, predicate4,
                        predicate6);
                    return;
                }

                if (predicate6(value))
                {
                    value6 = value;
                    found6 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref value5, ref found1, ref found2, ref found3, ref found4, ref found5, predicate1, predicate2, predicate3, predicate4,
                        predicate5);
                    return;
                }

                _index++;
            }
            while (_index < _count);
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref TSource value4, ref TSource value5, ref bool found1, ref bool found2, ref bool found3, ref bool found4,
            ref bool found5, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4, Func<TSource, bool> predicate5)
        {
            do
            {
                var value = _list[_index];
                if (predicate1(value))
                {
                    value1 = value;
                    found1 = true;
                    SetValues(ref value2, ref value3, ref value4, ref value5, ref found2, ref found3, ref found4, ref found5, predicate2, predicate3, predicate4, predicate5);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    found2 = true;
                    SetValues(ref value1, ref value3, ref value4, ref value5, ref found1, ref found3, ref found4, ref found5, predicate1, predicate3, predicate4, predicate5);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    found3 = true;
                    SetValues(ref value1, ref value2, ref value4, ref value5, ref found1, ref found2, ref found4, ref found5, predicate1, predicate2, predicate4, predicate5);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    found4 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value5, ref found1, ref found2, ref found3, ref found5, predicate1, predicate2, predicate3, predicate5);
                    return;
                }

                if (predicate5(value))
                {
                    value5 = value;
                    found5 = true;
                    SetValues(ref value1, ref value2, ref value3, ref value4, ref found1, ref found2, ref found3, ref found4, predicate1, predicate2, predicate3, predicate4);
                    return;
                }

                _index++;
            }
            while (_index < _count);
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref TSource value4, ref bool found1, ref bool found2, ref bool found3, ref bool found4,
            Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3, Func<TSource, bool> predicate4)
        {
            do
            {
                var value = _list[_index];
                if (predicate1(value))
                {
                    value1 = value;
                    found1 = true;
                    SetValues(ref value2, ref value3, ref value4, ref found2, ref found3, ref found4, predicate2, predicate3, predicate4);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    found2 = true;
                    SetValues(ref value1, ref value3, ref value4, ref found1, ref found3, ref found4, predicate1, predicate3, predicate4);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    found3 = true;
                    SetValues(ref value1, ref value2, ref value4, ref found1, ref found2, ref found4, predicate1, predicate2, predicate4);
                    return;
                }

                if (predicate4(value))
                {
                    value4 = value;
                    found4 = true;
                    SetValues(ref value1, ref value2, ref value3, ref found1, ref found2, ref found3, predicate1, predicate2, predicate3);
                    return;
                }

                _index++;
            }
            while (_index < _count);
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref TSource value3, ref bool found1, ref bool found2, ref bool found3, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2, Func<TSource, bool> predicate3)
        {
            do
            {
                var value = _list[_index];
                if (predicate1(value))
                {
                    value1 = value;
                    found1 = true;
                    SetValues(ref value2, ref value3, ref found2, ref found3, predicate2, predicate3);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    found2 = true;
                    SetValues(ref value1, ref value3, ref found1, ref found3, predicate1, predicate3);
                    return;
                }

                if (predicate3(value))
                {
                    value3 = value;
                    found3 = true;
                    SetValues(ref value1, ref value2, ref found1, ref found2, predicate1, predicate2);
                    return;
                }

                _index++;
            }
            while (_index < _count);
        }

        public void SetValues(ref TSource value1, ref TSource value2, ref bool found1, ref bool found2, Func<TSource, bool> predicate1,
            Func<TSource, bool> predicate2)
        {
            do
            {
                var value = _list[_index];
                if (predicate1(value))
                {
                    value1 = value;
                    found1 = true;
                    SetValues(ref value2, ref found2, predicate2);
                    return;
                }

                if (predicate2(value))
                {
                    value2 = value;
                    found2 = true;
                    SetValues(ref value1, ref found1, predicate1);
                    return;
                }

                _index++;
            }
            while (_index < _count);
        }

        public void SetValues(ref TSource value1, ref bool found1, Func<TSource, bool> predicate1)
        {
            do
            {
                var value = _list[_index];
                if (predicate1(value))
                {
                    value1 = value;
                    found1 = true;
                    return;
                }

                _index++;
            }
            while (_index < _count);
        }
    }
}