using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace En3Tho.ILEqualityComparer
{
    /// <summary>
    /// Auto-Generated IL Comparer. Works as EqualityComparer.Default for simple types. Uses HashCode.Combine as HashCodeFunction.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ILEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _equals;
        private readonly Func<T, int> _ghc;

        private ILEqualityComparer(bool includePrivateMembers) :
            this(ILEqualityComparerGenerator.GenerateEqualsFunc<T>(includePrivateMembers), ILEqualityComparerGenerator.GenerateGetHashCodeFunc<T>(includePrivateMembers)) { }

        private ILEqualityComparer(PropertyInfo[] properties, FieldInfo[] fields) :
            this(ILEqualityComparerGenerator.GenerateEqualsFunc<T>(properties, fields), ILEqualityComparerGenerator.GenerateGetHashCodeFunc<T>(properties, fields)) { }

        private ILEqualityComparer(Func<T, T, bool> equals, Func<T, int> ghc)
        {
            _equals = equals;
            _ghc = ghc;
        }

        /// <summary>
        /// Returns a comparer using all public properties and fields
        /// </summary>
        public static ILEqualityComparer<T> Default { get; } = new ILEqualityComparer<T>(false);

        /// <summary>
        /// Returns a comparer using only provided members
        /// </summary>
        /// <param name="expressions"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ILEqualityComparer<T> FromMemberExpressions(params Expression<Func<T, object>>[] expressions)
        {
            if (expressions.Length < 1)
                throw new ArgumentException(nameof(expressions));

            var memberExpressions = expressions.Select(e => e.Body).Cast<UnaryExpression>().Select(ue => ue.Operand).Cast<MemberExpression>().Distinct().ToArray();

            var properties = memberExpressions.Select(e => e.Member).OfType<PropertyInfo>().ToArray();
            var fields = memberExpressions.Select(e => e.Member).OfType<FieldInfo>().ToArray();

            return new ILEqualityComparer<T>(properties, fields);
        }

        // TODO: FromSpecifiedEqualityExpression ?

        /// <summary>
        /// Returns a comparer using all public properties and fields and ignoring provided members
        /// </summary>
        /// <param name="expressions"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ILEqualityComparer<T> FromIgnoreMemberExpressions(params Expression<Func<T, object>>[] expressions)
        {
            if (expressions.Length < 1)
                throw new ArgumentException(nameof(expressions));

            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;

            var memberExpressions = expressions.Select(e => e.Body).Cast<UnaryExpression>().Select(ue => ue.Operand).Cast<MemberExpression>().ToArray();
            var properties = typeof(T).GetProperties(flags).Except(memberExpressions.Select(me => me.Member).OfType<PropertyInfo>()).ToArray();
            var fields = typeof(T).GetFields(flags).Except(memberExpressions.Select(me => me.Member).OfType<FieldInfo>()).ToArray();

            return new ILEqualityComparer<T>(properties, fields);
        }

        /// <summary>
        /// Returns a comparer using all public and private properties and fields
        /// </summary>
        /// <returns></returns>
        public static ILEqualityComparer<T> WithPrivateMembers() => new ILEqualityComparer<T>(true);

        /// <summary>
        /// Returns a comparer using all public (and private) properties
        /// </summary>
        /// <param name="includePrivateMembers"></param>
        /// <returns></returns>
        public static ILEqualityComparer<T> WithPropertiesOnly(bool includePrivateMembers = false)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance | (includePrivateMembers ? BindingFlags.NonPublic : default);
            return new ILEqualityComparer<T>(typeof(T).GetProperties(flags), Array.Empty<FieldInfo>());
        }

        /// <summary>
        /// Returns a comparer using all public (and private) fields
        /// </summary>
        /// <param name="includePrivateMembers"></param>
        /// <returns></returns>
        public static ILEqualityComparer<T> WithFieldsOnly(bool includePrivateMembers = false)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance | (includePrivateMembers ? BindingFlags.NonPublic : default);
            return new ILEqualityComparer<T>(Array.Empty<PropertyInfo>(), typeof(T).GetFields(flags));
        }

        public bool Equals([AllowNull] T x, [AllowNull] T y) => ReferenceEquals(x, y)
                                                             || x is {} && y is {} && _equals(x, y);

        public int GetHashCode([DisallowNull] T obj) => obj is {} ? _ghc(obj) : 0;
    }
}