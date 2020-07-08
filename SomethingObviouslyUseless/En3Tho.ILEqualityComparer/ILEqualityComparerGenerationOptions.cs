namespace En3Tho.ILEqualityComparer
{
    internal enum MemberEqualityPreference
    {
        MembersThenIEquatableThenEquals,
        MembersThenEqualsThenIEquatable,
        IEquatableThenEqualsThenMembers,
        IEquatableThenMembersThenEquals,
        IEquatableThenEquals,
        EqualsThenIEquatableThenMembers,
        EqualsThenMembersThenIEquatable
    }

    internal enum ArrayEqualityPreference
    {
        FullEqualityCheck,
        ReferenceOnlyCheck,
        LengthOnlyCheck
    }

    internal class ILEqualityComparerGenerationOptions
    {
        public MemberEqualityPreference MemberEqualityPreference { get; set; }
        public ArrayEqualityPreference ArrayEqualityPreference { get; set; }
        public bool IncludePrivateMembers { get; set; }
    }
}