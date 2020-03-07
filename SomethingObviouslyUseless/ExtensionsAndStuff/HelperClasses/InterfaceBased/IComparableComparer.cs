using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ExtensionsAndStuff.HelperClasses.DelegateBased
{
    class IComparableComparer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare([AllowNull] T x, [AllowNull] T y) => x.CompareTo(y);

        public static IComparableComparer<T> Default { get; } = new IComparableComparer<T>();
    }
}
