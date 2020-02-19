using System;
using System.Collections.Generic;
using System.Text;

namespace LearnIntermediateLanguage
{
    public class SomeClass
    {
        public SomeClass(object a, object b, object c, object d)
        {         
            (a, b, c, d).NullCheck();
            (A, B, C, D) = (a, b, c, d);
        }

        public object A { get; }
        public object B { get; }
        public object C { get; }
        public object D { get; }
    }

    public class SomeClass2
    {
        public object A { get; private set; }
        public object B { get; private set; }

        public void SwapAB() => (A, B) = (B, A);
    }
}
