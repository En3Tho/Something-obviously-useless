using System.Collections.Generic;
using System.Reflection.Emit;

namespace En3Tho.ILHelpers.IL
{
    public class ILGenHelper
    {
        public ILGenerator ILGenerator { get; }
        public Dictionary<string, Label> Labels { get; }

        public ILGenHelper(ILGenerator generator)
        {
            ILGenerator = generator;
            Labels = new Dictionary<string, Label>();
        }
    }
}
