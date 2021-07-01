using System;
using FSharpDiscriminatedUnion.Test.FSharp;

namespace FSharpDiscriminatedUnion.Test.CSharp
{
    class Program
    {
        public int Value => Value;

        public int Ch;

        public int Value2 { set => Value2 = value; }

        public void Lol()
        {
            Ch = Ch;
        }

        static void Main(string[] args)
        {
            UnionToConsume union = UnionToConsume.NewA(10);
            var result = union switch // CS8509
            {
                UnionToConsume.A a => 1,
                UnionToConsume.B b => 2
            };

            Environment.Exit(result);
        }
    }
}
