using System;
using System.Collections.Generic;
using En3Tho.ILEqualityComparer;

#nullable disable

namespace LearnIntermediateLanguage
{
    public struct A
    {
        public Guid Guid;
        public int Int2;
        public C CC { get; }

        public A(Guid i, int int2, string str, C cc)
        {
            Guid = i;
            Int2 = int2;
            Str = str;
            CC = cc;
        }

        public string Str { get; }
    }

    public class B
    {
        public Guid Int;
        public int Int2 { get; }
        public C[] CC { get; }

        public B(Guid i, int int2, string str, C[] cc)
        {
            Int = i;
            Int2 = int2;
            Str = str;
            CC = cc;
        }

        public string Str { get; }
    }

    public class C
    {
        public object O { get; } = new object();

        public bool Equals(C other) => true;
        
        public override bool Equals(object obj) => true;
        public override int GetHashCode() => 0;
    }

    public class D { }

    class Program
    {
        static void Main(string[] args)
        {
            DynamicMethods.GetIlComparer();
            var gesad = ILEqualityComparer<D>.Default;
            var g = Guid.NewGuid();
            var gg = Guid.NewGuid();
            var geq = ILEqualityComparer<Guid>.Default;
            var geqd = EqualityComparer<Guid>.Default;
            
            var gehc = geq.GetHashCode(g);
            var gehh = g.GetHashCode();
            var gehd = geqd.GetHashCode(g);
            var gehcb = HashCode.Combine(g);
            
            var ges = ILEqualityComparer<string>.Default;
            var str = "lol";
            
            var gech = ILEqualityComparer<char>.Default;
            
            var gechhc = gech.Equals('a', 'a');
            var gechhc2 = gech.Equals('a', 'b');
            var gechhc3 = gech.GetHashCode('a');
            var gechhc4 = 'a'.GetHashCode();
            
            var ns = ges.Equals(null, str);
            var sn = ges.Equals(str, null);
            var nn = ges.Equals(null, null);
            var ss = ges.Equals(str, str);
            var sss = ges.Equals(str, "lol2");
            
            var ghcn = ges.GetHashCode(null);
            var ghcs = ges.GetHashCode(str);
            var ghcs2 = str.GetHashCode();
            
            var equalsC = ILEqualityComparer<C>.Default;
            var c = new C();
            var c2 = new C();
            
            var a = new A(Guid.Empty, 15, "15", c);
            var a2 = new A(Guid.Empty, 15, "15", c);
            var a3 = new A(Guid.Empty, 35, "15", new C());
            var equalsA = ILEqualityComparer<A>.Default;
            
            
            var b = new B(Guid.Empty, 15, null, new[] { new C() });
            var b2 = new B(Guid.Empty, 15, null, new[] { new C() });
            var b3 = new B(Guid.Empty, 15, "35", new[] { new C() });
            var equalsB = ILEqualityComparer<B>.Default;

            var ileqmembersA = ILEqualityComparer<A>.Create(ILEqualityComparerOptions<A>.FromMemberExpressions(x => x.Int2, x => x.Guid));
            var ileqmembersB = ILEqualityComparer<B>.Create(ILEqualityComparerOptions<B>.FromMemberExpressions(x => x.Int2, x => x.Int));
            
            var ileqignmembersA = ILEqualityComparer<A>.Create(ILEqualityComparerOptions<A>.IgnoreMemberExpressions(x => x.Int2, x => x.Guid));
            var ileqignmembersB = ILEqualityComparer<B>.Create(ILEqualityComparerOptions<B>.IgnoreMemberExpressions(x => x.Int2, x => x.Int));
            
            Console.WriteLine($"A1 equals A2: {equalsA.Equals(a, a2)}");
            Console.WriteLine($"C1 equals C2: {equalsC.Equals(c, c2)}");
            Console.WriteLine($"B1 equals B2: {equalsB.Equals(b, b2)}");
            
            Console.WriteLine($"A1 equals A3: {equalsA.Equals(a, a3)}");
            Console.WriteLine($"B1 equals B3: {equalsB.Equals(b, b3)}");
            
            Console.WriteLine($"A1 equals (expr) A2: {ileqmembersA.Equals(a, a2)}");
            Console.WriteLine($"B1 equals (expr) B2: {ileqmembersB.Equals(b, b2)}");
            
            Console.WriteLine($"A1 equals (expr) A3: {ileqmembersA.Equals(a, a3)}");
            Console.WriteLine($"B1 equals (expr) B3: {ileqmembersB.Equals(b, b3)}");
            
            Console.WriteLine($"A1 equals (ignexpr) A2: {ileqignmembersA.Equals(a, a2)}");
            Console.WriteLine($"B1 equals (ignexpr) B2: {ileqignmembersB.Equals(b, b2)}");
            
            Console.WriteLine($"A1 equals (ignexpr) A3: {ileqignmembersA.Equals(a, a3)}");
            Console.WriteLine($"B1 equals (ignexpr) B3: {ileqignmembersB.Equals(b, b3)}");
            
            Console.WriteLine($"A1 hashcode: {equalsA.GetHashCode(a)}");
            Console.WriteLine($"B1 hashcode: {equalsB.GetHashCode(b)}");
            
            Console.WriteLine($"A2 hashcode: {equalsA.GetHashCode(a2)}");
            Console.WriteLine($"B2 hashcode: {equalsB.GetHashCode(b2)}");
            
            Console.WriteLine($"A3 hashcode: {equalsA.GetHashCode(a3)}");
            Console.WriteLine($"B3 hashcode: {equalsB.GetHashCode(b3)}");

            Console.ReadLine();
        }
    }
}