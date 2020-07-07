using System;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace LearnIntermediateLanguage
{
    public class A
    {
        public int Int;
        public int Int2;
        public C CC { get; }
        public A(int i, int int2, string str, C cc)
        {
            Int = i;
            Int2 = int2;
            Str = str;
            CC = cc;
        }
        public string Str { get; }
    }

    public class B
    {
        public int Int;
        public int Int2 { get; }
        public C CC { get; }
        public B(int i, int int2, string str, C cc)
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
        public object O { get; }

        public override bool Equals(object? obj) => true;
        public override int GetHashCode() => 0;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            DynamicMethods.TestDuplicate();
            
            A a = new A(10, 15, null, new C());
            A a2 = new A(10, 15, null, new C());
            A a3 = new A(10, 15, "35", new C());
            var equalsA = ILEqualityComparer<A>.Default;

            B b = new B(10, 15, null, new C());
            B b2 = new B(10, 15, null, new C());
            B b3 = new B(10, 15, "35", new C());
            var equalsB = ILEqualityComparer<B>.Default;

            var ileqmembersA = ILEqualityComparer<A>.FromMemberExpressions(x => x.Int2, x => x.Int);
            var ileqmembersB = ILEqualityComparer<B>.FromMemberExpressions(x => x.Int2, x => x.Int);

            Console.WriteLine($"A1 equals A2: {equalsA.Equals(a, a2)}");
            Console.WriteLine($"B1 equals B2: {equalsB.Equals(b, b2)}");

            Console.WriteLine($"A1 equals A3: {equalsA.Equals(a, a3)}");
            Console.WriteLine($"B1 equals B3: {equalsB.Equals(b, b3)}");
            
            Console.WriteLine($"A1 equals (expr) A2: {ileqmembersA.Equals(a, a2)}");
            Console.WriteLine($"B1 equals (expr) B2: {ileqmembersB.Equals(b, b2)}");

            Console.WriteLine($"A1 equals (expr) A3: {ileqmembersA.Equals(a, a3)}");
            Console.WriteLine($"B1 equals (expr) B3: {ileqmembersB.Equals(b, b3)}");
            
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
