using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BenchmarkDotNet.Attributes;
using ExtensionsAndStuff.Linq;

namespace Benchmarks.BenchmarkDotNet
{
    [MemoryDiagnoser]
    public class FlattenBenchmark
    {
        public NestedCollection Collection { get; set; }
        public int Items { get; private set; }

        private NestedCollection CreateDeepNested(int nestLevel)
        {
            var result = new NestedCollection();
            for (int i = 0; i < 10; i++)
            {
                var temp = result;
                for (int j = 0; j < nestLevel; j++)
                {
                    var inner = new NestedCollection();
                    temp.Children.Add(inner);
                    temp = inner;
                }
            }

            return result;
        }
        
        [Params(10, 100, 1000, 10000)]
        public int NestLevel { get; set; }
        
        [GlobalSetup]
        public void GlobalSetup()
        {
            Collection = CreateDeepNested(NestLevel);
        }

        [Benchmark]
        public IEnumerable<NestedCollection> Flatten()
        {
            return Collection.Flatten(x => x.Children).ToArray();
        }
        
        [Benchmark]
        public IEnumerable<NestedCollection> FlattenToList()
        {
            return Collection.ToListRecursive(x => x.Children);
        }

        [Benchmark]
        public bool ContainsFlatten()
        {
            var col = new NestedCollection();
            return Collection.Flatten(x => x.Children).Any(x => ReferenceEquals(x, col));
        }

        public class NestedCollection : IEnumerable<NestedCollection>
        {
            public List<NestedCollection> Children { get; } = new();

            public IEnumerator<NestedCollection> GetEnumerator()
            {
                return Children.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}