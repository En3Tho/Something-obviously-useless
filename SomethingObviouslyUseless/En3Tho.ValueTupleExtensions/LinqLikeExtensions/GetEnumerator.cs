namespace En3Tho.ValueTupleExtensions.LinqLikeExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
        public static Tuple2Enumerator<T> GetEnumerator<T>(this (T, T) values) => new Tuple2Enumerator<T>(values);
        public static Tuple3Enumerator<T> GetEnumerator<T>(this (T, T, T) values) => new Tuple3Enumerator<T>(values);
        public static Tuple4Enumerator<T> GetEnumerator<T>(this (T, T, T, T) values) => new Tuple4Enumerator<T>(values);
        public static Tuple5Enumerator<T> GetEnumerator<T>(this (T, T, T, T, T) values) => new Tuple5Enumerator<T>(values);
        public static Tuple6Enumerator<T> GetEnumerator<T>(this (T, T, T, T, T, T) values) => new Tuple6Enumerator<T>(values);
        public static Tuple7Enumerator<T> GetEnumerator<T>(this (T, T, T, T, T, T, T) values) => new Tuple7Enumerator<T>(values);

        public ref struct Tuple2Enumerator<T>
        {
            private readonly (T, T) _values;
            private int _count;
            public Tuple2Enumerator((T, T) values) => (Current, _count, _values) = (default!, 0, values);

            public bool MoveNext()
            {
                var (current, result) = _count switch
                {
                    0 => (_values.Item1, true),
                    1 => (_values.Item2, true),
                    _ => (default!, false)
                };
                (Current, _count) = (current!, _count + 1);
                return result;
            }            

            public void Reset() => (Current, _count) = (default!, 0);
            public T Current { get; private set; }
            public void Dispose() { }
        }
        
        public ref struct Tuple3Enumerator<T>
        {
            private readonly (T, T, T) _values;
            private int _count;
            public Tuple3Enumerator((T, T, T) values) => (Current, _count, _values) = (default!, 0, values);

            public bool MoveNext()
            {
                var (current, result) = _count switch
                {
                    0 => (_values.Item1, true),
                    1 => (_values.Item2, true),
                    2 => (_values.Item3, true),
                    _ => (default!, false)
                };
                (Current, _count) = (current!, _count + 1);
                return result;
            }

            public void Reset() => (Current, _count) = (default!, 0);
            public T Current { get; private set; }
            public void Dispose() { }
        }
        
        public ref struct Tuple4Enumerator<T>
        {
            private readonly (T, T, T, T) _values;
            private int _count;
            public Tuple4Enumerator((T, T, T, T) values) => (Current, _count, _values) = (default!, 0, values);

            public bool MoveNext()
            {
                var (current, result) = _count switch
                {
                    0 => (_values.Item1, true),
                    1 => (_values.Item2, true),
                    2 => (_values.Item3, true),
                    3 => (_values.Item4, true),
                    _ => (default!, false)
                };
                (Current, _count) = (current!, _count + 1);
                return result;
            }

            public void Reset() => (Current, _count) = (default!, 0);
            public T Current { get; private set; }
            public void Dispose() { }
        }
        
        public ref struct Tuple5Enumerator<T>
        {
            private readonly (T, T, T, T, T) _values;
            private int _count;
            public Tuple5Enumerator((T, T, T, T, T) values) => (Current, _count, _values) = (default!, 0, values);

            public bool MoveNext()
            {
                var (current, result) = _count switch
                {
                    0 => (_values.Item1, true),
                    1 => (_values.Item2, true),
                    2 => (_values.Item3, true),
                    3 => (_values.Item4, true),
                    4 => (_values.Item5, true),
                    _ => (default!, false)
                };
                (Current, _count) = (current!, _count + 1);
                return result;
            }

            public void Reset() => (Current, _count) = (default!, 0);
            public T Current { get; private set; }
            public void Dispose() { }
        }
        
        public ref struct Tuple6Enumerator<T>
        {
            private readonly (T, T, T, T, T, T) _values;
            private int _count;
            public Tuple6Enumerator((T, T, T, T, T, T) values) => (Current, _count, _values) = (default!, 0, values);

            public bool MoveNext()
            {
                var (current, result) = _count switch
                {
                    0 => (_values.Item1, true),
                    1 => (_values.Item2, true),
                    2 => (_values.Item3, true),
                    3 => (_values.Item4, true),
                    4 => (_values.Item5, true),
                    5 => (_values.Item6, true),
                    _ => (default!, false)
                };
                (Current, _count) = (current!, _count + 1);
                return result;
            }

            public void Reset() => (Current, _count) = (default!, 0);
            public T Current { get; private set; }
            public void Dispose() { }
        }
        
        public ref struct Tuple7Enumerator<T>
        {
            private readonly (T, T, T, T, T, T, T) _values;
            private int _count;
            public Tuple7Enumerator((T, T, T, T, T, T, T) values) => (Current, _count, _values) = (default!, 0, values);

            public bool MoveNext()
            {
                var (current, result) = _count switch
                {
                    0 => (_values.Item1, true),
                    1 => (_values.Item2, true),
                    2 => (_values.Item3, true),
                    3 => (_values.Item4, true),
                    4 => (_values.Item5, true),
                    5 => (_values.Item6, true),
                    6 => (_values.Item7, true),
                    _ => (default!, false)
                };
                (Current, _count) = (current!, _count + 1);
                return result;
            }

            public void Reset() => (Current, _count) = (default!, 0);
            public T Current { get; private set; }
            public void Dispose() { }
        }
    }
}