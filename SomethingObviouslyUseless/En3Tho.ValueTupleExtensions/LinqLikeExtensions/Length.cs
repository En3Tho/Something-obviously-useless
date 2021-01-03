#if NETSTANDARD2_1

using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions.LinqLikeExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
        public static int Length<T>(this T tuple) where T : struct, ITuple => tuple.Length;
    }
}

#endif