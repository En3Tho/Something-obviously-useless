using System.Reflection.Emit;
using En3Tho.ILHelpers.IL;

namespace En3Tho.ILHelpers.MemberHolders
{
    internal sealed class ArgumentHolder : MemberHolder
    {
        public int Index { get; }
        public ArgumentHolder(int index) => Index = index;
        public override ILGenerator Load(ILGenerator valueOrEmptyGen) => valueOrEmptyGen.LoadArgument(Index);
        public override ILGenerator Store(ILGenerator valueOrEmptyGen) => valueOrEmptyGen.StoreArgument(Index);
    }
}