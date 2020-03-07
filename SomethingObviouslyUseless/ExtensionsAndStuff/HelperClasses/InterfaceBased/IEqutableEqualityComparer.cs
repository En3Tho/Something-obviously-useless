using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ExtensionsAndStuff.HelperClasses.InterfaceBased
{
    class IEqutableEqualityComparer<T> : IEqualityComparer<T> where T : IEquatable<T>
    {
        public bool Equals([AllowNull] T x, [AllowNull] T y) => x.Equals(y);

        public int GetHashCode([DisallowNull] T obj) => obj.GetHashCode();

        public static IEqutableEqualityComparer<T> Default { get; } = new IEqutableEqualityComparer<T>();
    }
}
