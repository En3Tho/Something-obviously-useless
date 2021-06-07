namespace En3Tho.ValueTupleExtensions.LinqLikeExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
        public struct ValueTuple7Enumerator<T>
        {
            private readonly (T, T, T, T, T, T, T) _tuple;
            private int _index;

            public T? Current { get; private set; }

            public ValueTuple7Enumerator((T, T, T, T, T, T, T) tuple)
            {
                _tuple = tuple;
                _index = 0;
                Current = default;
            }

            public bool MoveNext()
            {
                switch (_index)
                {
                    case 0:
                        Current = _tuple.Item1;
                        _index++;
                        return true;
                    case 1:
                        Current = _tuple.Item2;
                        _index++;
                        return true;
                    case 2:
                        Current = _tuple.Item3;
                        _index++;
                        return true;
                    case 3:
                        Current = _tuple.Item4;
                        _index++;
                        return true;
                    case 4:
                        Current = _tuple.Item5;
                        _index++;
                        return true;
                    case 5:
                        Current = _tuple.Item6;
                        _index++;
                        return true;
                    case 6:
                        Current = _tuple.Item7;
                        _index++;
                        return true;
                    default:
                        return false;
                }
            }
        }

        public struct ValueTuple6Enumerator<T>
        {
            private readonly (T, T, T, T, T, T) _tuple;
            private int _index;

            public T? Current { get; private set; }

            public ValueTuple6Enumerator((T, T, T, T, T, T) tuple)
            {
                _tuple = tuple;
                _index = 0;
                Current = default;
            }

            public bool MoveNext()
            {
                switch (_index)
                {
                    case 0:
                        Current = _tuple.Item1;
                        _index++;
                        return true;
                    case 1:
                        Current = _tuple.Item2;
                        _index++;
                        return true;
                    case 2:
                        Current = _tuple.Item3;
                        _index++;
                        return true;
                    case 3:
                        Current = _tuple.Item4;
                        _index++;
                        return true;
                    case 4:
                        Current = _tuple.Item5;
                        _index++;
                        return true;
                    case 5:
                        Current = _tuple.Item6;
                        _index++;
                        return true;
                    default:
                        return false;
                }
            }
        }

        public struct ValueTuple5Enumerator<T>
        {
            private readonly (T, T, T, T, T) _tuple;
            private int _index;

            public T? Current { get; private set; }

            public ValueTuple5Enumerator((T, T, T, T, T) tuple)
            {
                _tuple = tuple;
                _index = 0;
                Current = default;
            }

            public bool MoveNext()
            {
                switch (_index)
                {
                    case 0:
                        Current = _tuple.Item1;
                        _index++;
                        return true;
                    case 1:
                        Current = _tuple.Item2;
                        _index++;
                        return true;
                    case 2:
                        Current = _tuple.Item3;
                        _index++;
                        return true;
                    case 3:
                        Current = _tuple.Item4;
                        _index++;
                        return true;
                    case 4:
                        Current = _tuple.Item5;
                        _index++;
                        return true;
                    default:
                        return false;
                }
            }
        }

        public struct ValueTuple4Enumerator<T>
        {
            private readonly (T, T, T, T) _tuple;
            private int _index;

            public T? Current { get; private set; }

            public ValueTuple4Enumerator((T, T, T, T) tuple)
            {
                _tuple = tuple;
                _index = 0;
                Current = default;
            }

            public bool MoveNext()
            {
                switch (_index)
                {
                    case 0:
                        Current = _tuple.Item1;
                        _index++;
                        return true;
                    case 1:
                        Current = _tuple.Item2;
                        _index++;
                        return true;
                    case 2:
                        Current = _tuple.Item3;
                        _index++;
                        return true;
                    case 3:
                        Current = _tuple.Item4;
                        _index++;
                        return true;
                    default:
                        return false;
                }
            }
        }

        public struct ValueTuple3Enumerator<T>
        {
            private readonly (T, T, T) _tuple;
            private int _index;

            public T? Current { get; private set; }

            public ValueTuple3Enumerator((T, T, T) tuple)
            {
                _tuple = tuple;
                _index = 0;
                Current = default;
            }

            public bool MoveNext()
            {
                switch (_index)
                {
                    case 0:
                        Current = _tuple.Item1;
                        _index++;
                        return true;
                    case 1:
                        Current = _tuple.Item2;
                        _index++;
                        return true;
                    case 2:
                        Current = _tuple.Item3;
                        _index++;
                        return true;
                    default:
                        return false;
                }
            }
        }

        public struct ValueTuple2Enumerator<T>
        {
            private readonly (T, T) _tuple;
            private int _index;

            public T? Current { get; private set; }

            public ValueTuple2Enumerator((T, T) tuple)
            {
                _tuple = tuple;
                _index = 0;
                Current = default;
            }

            public bool MoveNext()
            {
                switch (_index)
                {
                    case 0:
                        Current = _tuple.Item1;
                        _index++;
                        return true;
                    case 1:
                        Current = _tuple.Item2;
                        _index++;
                        return true;
                    default:
                        return false;
                }
            }
        }

        public static ValueTuple2Enumerator<T> GetEnumerator<T>(this (T, T) tuple) => new ValueTuple2Enumerator<T>(tuple);
        public static ValueTuple3Enumerator<T> GetEnumerator<T>(this (T, T, T) tuple) => new ValueTuple3Enumerator<T>(tuple);
        public static ValueTuple4Enumerator<T> GetEnumerator<T>(this (T, T, T, T) tuple) => new ValueTuple4Enumerator<T>(tuple);
        public static ValueTuple5Enumerator<T> GetEnumerator<T>(this (T, T, T, T, T) tuple) => new ValueTuple5Enumerator<T>(tuple);
        public static ValueTuple6Enumerator<T> GetEnumerator<T>(this (T, T, T, T, T, T) tuple) => new ValueTuple6Enumerator<T>(tuple);
        public static ValueTuple7Enumerator<T> GetEnumerator<T>(this (T, T, T, T, T, T, T) tuple) => new ValueTuple7Enumerator<T>(tuple);
    }
}