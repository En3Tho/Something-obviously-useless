using System;
using System.Linq;

namespace ExtensionsAndStuff.Linq
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static partial class EnumerableExtensions
    {
        public static void Deconstruct<T>(this IEnumerable<T> values, out T v1, out T v2, out T v3)
        {
            using var enumerator = values.GetEnumerator();
            (v1, v2, v3) = (default, default, default);
            for (int i = 0; i < 3; i++)
            {
                if (!enumerator.MoveNext()) throw new ArgumentOutOfRangeException();
                switch (i)
                {
                    case 0:
                        v1 = enumerator.Current;
                        break;
                    case 1:
                        v2 = enumerator.Current;
                        break;
                    case 2:
                        v3 = enumerator.Current;
                        break;
                }
            }
        }
    }
}
