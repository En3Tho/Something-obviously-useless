using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using En3Tho.ValueTupleExtensions.LinqToValueTupleExtensions;

namespace Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    public class FirstOrDefaultBenchmark
    {
        private static readonly Func<int, bool> _6_Getter = x => x == 6;
        private static readonly Func<int, bool> _50_Getter = x => x == 50;
        private static readonly Func<int, bool> _787_Getter = x => x == 787;
        private static readonly Func<int, bool> _999_Getter = x => x == 999;
        
        [Params(10, 100, 1000)] public int Count { get; set; }
        public List<int> Items { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            Items = Enumerable.Range(1, Count).ToList();
        }

        //[Benchmark]
        public void FindFirstOrDefault_50_787_Linq()
        {
            var _50 = Items.FirstOrDefault(_50_Getter);
            var _787 = Items.FirstOrDefault(_787_Getter);
        }

        [Benchmark]
        public void FindFirstOrDefault_50_787_Ext()
        {
            var (_50, _787) = Items.FirstOrDefault(_50_Getter, _787_Getter);
        }

        //[Benchmark]
        public void FindSingleOrDefault_50_787_Linq()
        {
            var _50 = Items.SingleOrDefault(_50_Getter);
            var _787 = Items.SingleOrDefault(_787_Getter);
        }

        //[Benchmark]
        public void FindSingleOrDefault_50_787_Ext()
        {
            var (_50, _787) = Items.SingleOrDefault(_50_Getter, _787_Getter);
        }

        //[Benchmark]
        public void FindLastOrDefault_50_787_Linq()
        {
            var _50 = Items.LastOrDefault(_50_Getter);
            var _787 = Items.LastOrDefault(_787_Getter);
        }

        //[Benchmark]
        public void FindLastOrDefault_50_787_Ext()
        {
            var (_50, _787) = Items.LastOrDefault(_50_Getter, _787_Getter);
        }
        
        //[Benchmark]
        public void FindLastOrDefault_50_787_Ext2()
        {
            var (_50, _787) = Items.LastOrDefault(_50_Getter, _787_Getter);
        }
        
        //[Benchmark]
        public void FindFirstOrDefault_6_50_787_Linq()
        {
            var _6 = Items.FirstOrDefault(_6_Getter);
            var _50 = Items.FirstOrDefault(_50_Getter);
            var _787 = Items.FirstOrDefault(_787_Getter);
        }

        [Benchmark]
        public void FindFirstOrDefault_6_50_787_Ext()
        {
            var (_6, _50, _787) = Items.FirstOrDefault(_6_Getter, _50_Getter, _787_Getter);
        }

        //[Benchmark]
        public void FindSingleOrDefault_6_50_787_Linq()
        {
            var _6 = Items.SingleOrDefault(_6_Getter);
            var _50 = Items.SingleOrDefault(_50_Getter);
            var _787 = Items.SingleOrDefault(_787_Getter);
        }

        //[Benchmark]
        public void FindSingleOrDefault_6_50_787_Ext()
        {
            var (_6, _50, _787) = Items.SingleOrDefault(_6_Getter, _50_Getter, _787_Getter);
        }
        
        //[Benchmark]
        public void FindSingleOrDefault_6_50_787_Ext2()
        {
            var (_6, _50, _787) = Items.SingleOrDefault(_6_Getter, _50_Getter, _787_Getter);
        }

        //[Benchmark]
        public void FindLastOrDefault_6_50_787_Linq()
        {
            var _6 = Items.LastOrDefault(_6_Getter);
            var _50 = Items.LastOrDefault(_50_Getter);
            var _787 = Items.LastOrDefault(_787_Getter);
        }

        //[Benchmark]
        public void FindLastOrDefault_6_50_787_Ext()
        {
            var (_6, _50, _787) = Items.LastOrDefault(_6_Getter, _50_Getter, _787_Getter);
        }
        
        //[Benchmark]
        public void FindLastOrDefault_6_50_787_Ext2()
        {
            var (_6, _50, _787) = Items.LastOrDefault(_6_Getter, _50_Getter, _787_Getter);
        }
        
        //[Benchmark]
        public void FindFirstOrDefault_6_50_787_999_Linq()
        {
            var _6 = Items.FirstOrDefault(_6_Getter);
            var _50 = Items.FirstOrDefault(_50_Getter);
            var _787 = Items.FirstOrDefault(_787_Getter);
            var _999 = Items.FirstOrDefault(_999_Getter);
        }

        [Benchmark]
        public void FindFirstOrDefault_6_50_787_999_Ext()
        {
            var (_6, _50, _787, _999) = Items.FirstOrDefault(_6_Getter, _50_Getter, _787_Getter, _999_Getter);
        }

        //[Benchmark]
        public void FindSingleOrDefault_6_50_787_999_Linq()
        {
            var _6 = Items.SingleOrDefault(_6_Getter);
            var _50 = Items.SingleOrDefault(_50_Getter);
            var _787 = Items.SingleOrDefault(_787_Getter);
            var _999 = Items.SingleOrDefault(_999_Getter);
        }

        //[Benchmark]
        public void FindSingleOrDefault_6_50_787_999_Ext()
        {
            var (_6, _50, _787, _999) = Items.SingleOrDefault(_6_Getter, _50_Getter, _787_Getter,_999_Getter);
        }
        
        //[Benchmark]
        public void FindSingleOrDefault_6_50_787_999_Ext2()
        {
            var (_6, _50, _787, _999) = Items.SingleOrDefault(_6_Getter, _50_Getter, _787_Getter,_999_Getter);
        }

        //[Benchmark]
        public void FindLastOrDefault_6_50_787_999_Linq()
        {
            var _6 = Items.LastOrDefault(_6_Getter);
            var _50 = Items.LastOrDefault(_50_Getter);
            var _787 = Items.LastOrDefault(_787_Getter);
            var _999 = Items.LastOrDefault(_999_Getter);
        }

        //[Benchmark]
        public void FindLastOrDefault_6_50_787_999_Ext()
        {
            var (_6, _50, _787, _999) = Items.LastOrDefault(_6_Getter, _50_Getter, _787_Getter, _999_Getter);
        }
        
        //[Benchmark]
        public void FindLastOrDefault_6_50_787_999_Ext2()
        {
            var (_6, _50, _787, _999) = Items.LastOrDefault(_6_Getter, _50_Getter, _787_Getter, _999_Getter);
        }
    }
}