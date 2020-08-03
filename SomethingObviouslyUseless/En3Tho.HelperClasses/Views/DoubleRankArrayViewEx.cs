using System.Collections;
using System.Collections.Generic;

namespace En3Tho.HelperClasses.Views
{
    internal static class DoubleRankArrayViewEx
    {
        public static DoubleRankArrayView<T> AsDoubleRank<T>(this T[] array, int rowWidth) => new DoubleRankArrayView<T>(array, rowWidth);
        public static DoubleRankIListView<T> AsDoubleRank<T>(this IList<T> ilist, int rowWidth) => new DoubleRankIListView<T>(ilist, rowWidth);
        public static DoubleRankBitArrayView AsDoubleRank<T>(this BitArray bitarray, int rowWidth) => new DoubleRankBitArrayView(bitarray, rowWidth);
    }
}