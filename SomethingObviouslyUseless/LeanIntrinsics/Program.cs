using System;
using System.Runtime.CompilerServices;

namespace LeanIntrinsics
{
    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                var a = new int[1];
                var b = new int[4];
                var c = new int[8];
                var d = new int[10];
                var e = new int[20];
                var f = new int[32];
                var g = new int[32];
                
                var aP = (long)Unsafe.AsPointer(ref a[0]) - 16;
                var bP = (long)Unsafe.AsPointer(ref b[0]) - 16;
                var cP = (long)Unsafe.AsPointer(ref c[0]) - 16;
                var dP = (long)Unsafe.AsPointer(ref d[0]) - 16;
                var eP = (long)Unsafe.AsPointer(ref e[0]) - 16;
                var fP = (long)Unsafe.AsPointer(ref f[0]) - 16;
                var gP = (long)Unsafe.AsPointer(ref g[0]) - 16;

                Console.WriteLine($"{nameof(a)}[{a.Length}] starts at: {aP.ToString("X")}");
                Console.WriteLine($"SizeOf {nameof(a)} is {(bP - aP)}");
                Console.WriteLine($"SizeOfElements in {nameof(a)} is {(bP - aP - 16)}");
                Console.WriteLine($"Expected SizeOfElements in {nameof(a)} is {sizeof(int) * a.Length}");

                Console.WriteLine($"{nameof(b)}[{b.Length}] starts at: {bP.ToString("X")}");
                Console.WriteLine($"SizeOf {nameof(b)} is {(cP - bP)}");
                Console.WriteLine($"SizeOfElements in {nameof(b)} is {(cP - bP - 16)}");
                Console.WriteLine($"Expected SizeOfElements in {nameof(b)} is {sizeof(int) * b.Length}");

                Console.WriteLine($"{nameof(c)}[{c.Length}] starts at: {cP.ToString("X")}");
                Console.WriteLine($"SizeOf {nameof(c)} is {(dP - cP)}");
                Console.WriteLine($"SizeOfElements in {nameof(c)} is {(dP - cP - 16)}");
                Console.WriteLine($"Expected SizeOfElements in {nameof(c)} is {sizeof(int) * c.Length}");

                Console.WriteLine($"{nameof(d)}[{d.Length}] starts at: {dP.ToString("X")}");
                Console.WriteLine($"SizeOf {nameof(d)} is {(eP - dP)}");
                Console.WriteLine($"SizeOfElements in {nameof(d)} is {(eP - dP - 16)}");
                Console.WriteLine($"Expected SizeOfElements in {nameof(d)} is {sizeof(int) * d.Length}");

                Console.WriteLine($"{nameof(e)}[{e.Length}] starts at: {eP.ToString("X")}");
                Console.WriteLine($"SizeOf {nameof(e)} is {(fP - eP)}");
                Console.WriteLine($"SizeOfElements in {nameof(e)} is {(fP - eP - 16)}");
                Console.WriteLine($"Expected SizeOfElements in {nameof(e)} is {sizeof(int) * e.Length}");

                Console.WriteLine($"{nameof(f)}[{f.Length}] starts at: {fP.ToString("X")}");
                Console.WriteLine($"SizeOf {nameof(f)} is {(gP - fP)}");
                Console.WriteLine($"SizeOfElements in {nameof(f)} is {(gP - fP - 16)}");
                Console.WriteLine($"Expected SizeOfElements in {nameof(f)} is {sizeof(int) * f.Length}");
            }


            Console.ReadLine();
        }

        public static int ReverseFirstAndLastDigit_My(int number)
        {
            var mul = (number >> 31) | 1;
            number *= mul;

            int right, left, pow;
            right = number % 10;
            left = number;
            pow = 1;
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
