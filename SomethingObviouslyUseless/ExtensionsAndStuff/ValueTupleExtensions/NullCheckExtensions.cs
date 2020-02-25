using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static class NullCheckExtensions
    {
        public static void NullCheck<T>(this T value)
            where T : class
        {
            _ = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static void NullCheck<T1, T2>(in this (T1, T2) value)
            where T1 : class where T2 : class
        {
            _ = value.Item1 ?? throw new ArgumentNullException(nameof(value.Item1));
            _ = value.Item2 ?? throw new ArgumentNullException(nameof(value.Item2));
        }

        public static void NullCheck<T1, T2, T3>(in this (T1, T2, T3) value)
            where T1 : class where T2 : class where T3 : class
        {
            _ = value.Item1 ?? throw new ArgumentNullException(nameof(value.Item1));
            _ = value.Item2 ?? throw new ArgumentNullException(nameof(value.Item2));
            _ = value.Item3 ?? throw new ArgumentNullException(nameof(value.Item3));
        }

        public static void NullCheck<T1, T2, T3, T4>(in this (T1, T2, T3, T4) value)
            where T1 : class where T2 : class where T3 : class where T4 : class
        {
            _ = value.Item1 ?? throw new ArgumentNullException(nameof(value.Item1));
            _ = value.Item2 ?? throw new ArgumentNullException(nameof(value.Item2));
            _ = value.Item3 ?? throw new ArgumentNullException(nameof(value.Item3));
            _ = value.Item4 ?? throw new ArgumentNullException(nameof(value.Item4));
        }

        public static void NullCheck<T1, T2, T3, T4, T5>(in this (T1, T2, T3, T4, T5) value)
            where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class
        {
            _ = value.Item1 ?? throw new ArgumentNullException(nameof(value.Item1));
            _ = value.Item2 ?? throw new ArgumentNullException(nameof(value.Item2));
            _ = value.Item3 ?? throw new ArgumentNullException(nameof(value.Item3));
            _ = value.Item4 ?? throw new ArgumentNullException(nameof(value.Item4));
            _ = value.Item5 ?? throw new ArgumentNullException(nameof(value.Item5));
        }

        public static void NullCheck<T1, T2, T3, T4, T5, T6>(in this (T1, T2, T3, T4, T5, T6) value)
            where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class
        {
            _ = value.Item1 ?? throw new ArgumentNullException(nameof(value.Item1));
            _ = value.Item2 ?? throw new ArgumentNullException(nameof(value.Item2));
            _ = value.Item3 ?? throw new ArgumentNullException(nameof(value.Item3));
            _ = value.Item4 ?? throw new ArgumentNullException(nameof(value.Item4));
            _ = value.Item5 ?? throw new ArgumentNullException(nameof(value.Item5));
            _ = value.Item6 ?? throw new ArgumentNullException(nameof(value.Item6));
        }

        public static void NullCheck<T1, T2, T3, T4, T5, T6, T7>(in this (T1, T2, T3, T4, T5, T6, T7) value)
            where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class
        {
            _ = value.Item1 ?? throw new ArgumentNullException(nameof(value.Item1));
            _ = value.Item2 ?? throw new ArgumentNullException(nameof(value.Item2));
            _ = value.Item3 ?? throw new ArgumentNullException(nameof(value.Item3));
            _ = value.Item4 ?? throw new ArgumentNullException(nameof(value.Item4));
            _ = value.Item5 ?? throw new ArgumentNullException(nameof(value.Item5));
            _ = value.Item6 ?? throw new ArgumentNullException(nameof(value.Item6));
            _ = value.Item7 ?? throw new ArgumentNullException(nameof(value.Item7));
        }
    }
}
