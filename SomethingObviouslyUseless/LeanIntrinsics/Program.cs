using System;
using System.Runtime.CompilerServices;

namespace LeanIntrinsics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }

        public static int ReverseFirstAndLastDigit_My(int number)
        {
            var mul = (number >> 31) | 1;
            number *= mul;

            var right = number % 10;
            var left = number;
            var pow = 1;
            while (left > 10)
            {
                left /= 10;
                pow *= 10;
            }

            number = number + right * pow + left - right - left * pow;
            return number * mul;
        }
    }
}
