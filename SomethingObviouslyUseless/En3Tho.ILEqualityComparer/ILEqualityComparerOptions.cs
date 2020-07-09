using System;
using System.Linq;
using System.Linq.Expressions;

namespace En3Tho.ILEqualityComparer
{
    public enum MemberEqualityPreference
    {
        MembersThenIEquatableThenEquals,
        MembersThenEqualsThenIEquatable,
        IEquatableThenEqualsThenMembers,
        IEquatableThenMembersThenEquals,
        EqualsThenIEquatableThenMembers,
        EqualsThenMembersThenIEquatable
    }

    public enum ArrayEqualityPreference
    {
        ElementsStructuralEqualityCheck,
        ElementsReferenceEqualityCheck,
        SimpleLengthOnlyCheck
    }

    public enum EqualityGenerationPreference
    {
        IgnoreMemberExpressions,
        FromMemberExpressions
    }

    public sealed class ILEqualityComparerOptions<T>
    {
        internal EqualityGenerationPreference EqualityGenerationPreference { get; }
        public MemberEqualityPreference MemberEqualityPreference { get; /*init*/ set; } // TODO: implement options
        public ArrayEqualityPreference ArrayEqualityPreference { get; /*init*/ set; } // TODO: implement option
        public MemberExpression[] MemberExpressions { get; } // to propertyinfos / fieldinfos

        private ILEqualityComparerOptions(Expression<Func<T, object>>[] expressions, EqualityGenerationPreference equalityGenerationPreference)
        {
            MemberExpressions = expressions.Length == 0
                ? Array.Empty<MemberExpression>()
                : expressions.Select(e => e.Body).Cast<UnaryExpression>().Select(e => e.Operand).Cast<MemberExpression>().ToArray();
            EqualityGenerationPreference = equalityGenerationPreference;
        }

        // todo from member info
        
        public static ILEqualityComparerOptions<T> IgnoreMemberExpressions(params Expression<Func<T, object>>[] expressions)
            => new ILEqualityComparerOptions<T>(expressions, EqualityGenerationPreference.IgnoreMemberExpressions);

        public static ILEqualityComparerOptions<T> FromMemberExpressions(params Expression<Func<T, object>>[] expressions)
            => new ILEqualityComparerOptions<T>(expressions, EqualityGenerationPreference.FromMemberExpressions);
    }
}