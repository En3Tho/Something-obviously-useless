using System;
using System.Linq.Expressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    public class CompiledExpressionBenchmark
    {
        [Params(10, 30, 70, 100, 300, 700, 1000, 3000, 7000, 10000, 30000, 70000, 100000, 300000, 700000, 1000000)]
        public int N { get; set; }

        private int[] _data;

        private static readonly Func<int[], int> compiledExpression =
            SumEvensExpressionImpl().Compile();

        [GlobalSetup]
        public void GlobalSetup()
        {
            var random = new Random(1234);
            _data = new int[N];
            for (int i = 0; i < N; i++)
            {
                _data[i] = random.Next(1000);
            }
        }

        //[Benchmark]
        public void Test()
        {
            var sum1 =  SumEvensImpl(_data);
            var sum2 = compiledExpression(_data);
            var sum3 = SumEvensWithGoto(_data);
            
            if (sum1 != sum2) throw new Exception();
            if (sum1 != sum3) throw new Exception();
            if (sum2 != sum3) throw new Exception();
        }
        
        [Benchmark]
        public int SumEvens() => SumEvensImpl(_data);

        [Benchmark]
        public int SumEvensCompiledExpression() => compiledExpression(_data);

        [Benchmark]
        public int SumEvensWithGoto() => SumEvensWithGoto(_data);

        [Benchmark]
        public int SumEvensWithForeach() => SumEvensWithForeach(_data);
        
        private static int SumEvensImpl(int[] data)
        {
            int sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                int val = data[i];
                if (val % 2 == 0)
                {
                    sum += val;
                }
            }

            return sum;
        }

        private static int SumEvensWithForeach(int[] data)
        {
            var sum = 0;
            foreach (var value in data)
                sum += value * (value & 1 ^ 1);
            return sum;
        }
        
        private static int SumEvensWithGoto(int[] data)
        {
            var sum = 0;
            var index = 0;
            Loop:
            if (index < data.Length)
            {
                var current = data[index];
                sum += current * (current & 1 ^ 1);
                index++;
                goto Loop;
            }

            return sum;
        }
        
        private static Expression<Func<int[], int>> SumEvensExpressionImpl()
        {
            var dataVar = Expression.Variable(typeof(int[]), "data");
            var sumVar = Expression.Variable(typeof(int), "sum");
            var iVar = Expression.Variable(typeof(int), "i");
            var elemVar = Expression.Variable(typeof(int), "elem");
            var breakLabel = Expression.Label();

            return Expression.Lambda<Func<int[], int>>(
                Expression.Block(
                    new[] { sumVar, iVar },
                    Expression.Assign(sumVar, Expression.Constant(0)),
                    Expression.Assign(iVar, Expression.Constant(0)),
                    Expression.Loop(
                        Expression.IfThenElse(
                            Expression.LessThan(iVar, Expression.ArrayLength(dataVar)),
                            Expression.Block(
                                new[] { elemVar },
                                Expression.Assign(elemVar, Expression.ArrayIndex(dataVar, iVar)),
                                Expression.PostIncrementAssign(iVar),
                                Expression.IfThen(
                                    Expression.Equal(
                                        Expression.Modulo(elemVar, Expression.Constant(2)),
                                        Expression.Constant(0)),
                                    Expression.Assign(sumVar, Expression.Add(sumVar, elemVar)))),
                            Expression.Break(breakLabel)),
                        breakLabel),
                    sumVar),
                dataVar);
        }
    }
}