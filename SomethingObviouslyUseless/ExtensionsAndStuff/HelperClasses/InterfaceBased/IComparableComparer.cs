using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExtensionsAndStuff.HelperClasses.DelegateBased
{
    class IComparableComparer<T> : IComparer<T> where T : IComparable<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Compare([AllowNull] T x, [AllowNull] T y) => x.CompareTo(y);

        public static IComparableComparer<T> Default { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; } = new IComparableComparer<T>();
    }
}
