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
    public sealed class ILEqualityComparer<T> : IEqualityComparer<T>
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
        /// Full structural equality comparer for all public properties and fields
        /// </summary>
        public static ILEqualityComparer<T> Default { get; } = new ILEqualityComparer<T>(false);

        /// <summary>
        /// Returns a custom comparer with specified options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public static ILEqualityComparer<T> Create(ILEqualityComparerOptions<T> options) // move all logic to generator
        {
            PropertyInfo[] properties;
            FieldInfo[] fields;

            var memberExpressions = options.MemberExpressions;
            if (options.EqualityGenerationPreference == EqualityGenerationPreference.IgnoreMemberExpressions)
            {
                properties = typeof(T).GetProperties();
                fields = typeof(T).GetFields();
                if (memberExpressions.Length != 0)
                {
                    properties = properties.Except(memberExpressions.Select(me => me.Member).OfType<PropertyInfo>()).ToArray();
                    fields = fields.Except(memberExpressions.Select(me => me.Member).OfType<FieldInfo>()).ToArray();
                }
            }
            else
            {
                properties = memberExpressions.Select(e => e.Member).OfType<PropertyInfo>().ToArray();
                fields = memberExpressions.Select(e => e.Member).OfType<FieldInfo>().ToArray();
            }

            var eq = ILEqualityComparerGenerator.GenerateEqualsFunc<T>(properties, fields);
            var ghc = ILEqualityComparerGenerator.GenerateGetHashCodeFunc<T>(properties, fields);
            return new ILEqualityComparer<T>(eq, ghc);
        }

        public bool Equals([AllowNull] T x, [AllowNull] T y) => ReferenceEquals(x, y)
                                                                                || (x, y) is ({}, {}) && _equals(x, y);

        public int GetHashCode(T obj) => obj is {} ? _ghc(obj) : 0;
    }
}