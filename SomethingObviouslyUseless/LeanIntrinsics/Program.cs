using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnIntrinsics
{
    public static class IntExtensions
    {
        public static void ChangeValue(this ref int value, int newValue) => value = newValue;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var x = 10;
            x.ChangeValue(20);
            Console.WriteLine(x);
            Console.ReadLine();
        }
    }
}


