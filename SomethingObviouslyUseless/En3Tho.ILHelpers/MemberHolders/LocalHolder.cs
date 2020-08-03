using System.Reflection.Emit;
using En3Tho.ILHelpers.IL;

namespace En3Tho.ILHelpers.MemberHolders
{
    internal sealed class LocalHolder : MemberHolder
    {
        public LocalBuilder Builder { get; }
        public LocalHolder(LocalBuilder builder) => Builder = builder;
        public override ILGenerator Load(ILGenerator valueOrEmptyGen) => valueOrEmptyGen.LoadLocal(Builder.LocalIndex);
        public override ILGenerator Store(ILGenerator valueOrEmptyGen) => valueOrEmptyGen.StoreLocal(Builder.LocalIndex);
    }
}