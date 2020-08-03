using System;
using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses
{
    public readonly struct MultiComparison<T>
        : IComparable, IComparable<T>, IComparable<MultiComparison<T>>,
            IEquatable<T>, IEquatable<MultiComparison<T>>
        where T : IComparable<T>, IEquatable<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is MultiComparison<T> other && Equals(other);

#if !NETSTANDARD2_0
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(Value, Result);
        #else
        [MethodImpl(MethodImplOptions.AggressiveInlining)] // TODO: HashCode class to .NetStandard 2.0
        public override int GetHashCode() => Value.GetHashCode() ^ (Result ? 1 : 0);
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(object? obj) => obj switch
        {
            T value                  => CompareTo(value),
            MultiComparison<T> value => CompareTo(value),
            _                        => throw new ArgumentException("Not supported object type")
        };

        private readonly T Value;
        private readonly bool Result;

        public MultiComparison(T value, bool result)
        {
            Value = value;
            Result = result;
        }

        public MultiComparison(T value)
        {
            Value = value;
            Result = true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MultiComparison<T> operator <(MultiComparison<T> x, MultiComparison<T> y) => new MultiComparison<T>(x.Value, x.Value.CompareTo(y.Value) < 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MultiComparison<T> operator >(MultiComparison<T> x, MultiComparison<T> y) => new MultiComparison<T>(x.Value, x.Value.CompareTo(y.Value) > 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MultiComparison<T> operator <=(MultiComparison<T> x, MultiComparison<T> y) => new MultiComparison<T>(x.Value, x.Value.CompareTo(y.Value) <= 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MultiComparison<T> operator >=(MultiComparison<T> x, MultiComparison<T> y) => new MultiComparison<T>(x.Value, x.Value.CompareTo(y.Value) >= 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MultiComparison<T> operator ==(MultiComparison<T> x, MultiComparison<T> y) => new MultiComparison<T>(x.Value, x.Value.Equals(y.Value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MultiComparison<T> operator !=(MultiComparison<T> x, MultiComparison<T> y) => new MultiComparison<T>(x.Value, !x.Value.Equals(y.Value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MultiComparison<T> operator <(MultiComparison<T> x, T y) => new MultiComparison<T>(x.Value, x.Value.CompareTo(y) < 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MultiComparison<T> operator >(MultiComparison<T> x, T y) => new MultiComparison<T>(x.Value, x.Value.CompareTo(y) > 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MultiComparison<T> operator <=(MultiComparison<T> x, T y) => new MultiComparison<T>(x.Value, x.Value.CompareTo(y) <= 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MultiComparison<T> operator >=(MultiComparison<T> x, T y) => new MultiComparison<T>(x.Value, x.Value.CompareTo(y) >= 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MultiComparison<T> operator ==(MultiComparison<T> x, T y) => new MultiComparison<T>(x.Value, x.Value.Equals(y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MultiComparison<T> operator !=(MultiComparison<T> x, T y) => new MultiComparison<T>(x.Value, !x.Value.Equals(y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(T other) => Value.CompareTo(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(MultiComparison<T> other) => Value.CompareTo(other.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(T other) => Value.Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(MultiComparison<T> other) => Value.Equals(other.Value);

        public static implicit operator bool(MultiComparison<T> comp) => comp.Result;
    }

    public static class MultiComparisonEx
    {
        public static MultiComparison<T> ToMultiComparison<T>(this T value) where T : IComparable<T>, IEquatable<T> => new MultiComparison<T>(value);
    }
}