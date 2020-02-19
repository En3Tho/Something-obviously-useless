using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace LearnIntermediateLanguage.IL
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
