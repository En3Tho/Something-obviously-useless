using System.Reflection.Emit;

namespace En3Tho.ILHelpers.MemberHolders
{
    public abstract class MemberHolder
    {
        public abstract ILGenerator Load(ILGenerator valueOrEmptyGen);  // should be dynamic method builder in the future
        public abstract ILGenerator Store(ILGenerator valueOrEmptyGen); // should be dynamic method builder in the future
    }
}