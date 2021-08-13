using System;
using System.Collections.Generic;
using Xunit;

namespace AutoDecoratorGenerator.Tests
{
    public partial class DictionaryDecorator<TKey, TValue>
    {
        [Decorate]
        private readonly Dictionary<TKey, TValue> _dictionary;

        public DictionaryDecorator(Dictionary<TKey, TValue> dictionary)
        {
            _dictionary = dictionary;
        }
    }

    public readonly ref partial struct SpanDecorator<T>
    {
        [Decorate]
        private readonly Span<T> _span;
        public SpanDecorator(Span<T> span)
        {
            _span = span;
        }
    }

    public class GeneratedTests
    {
        [Fact]
        public void DictionaryTest()
        {
            var dictionary = new Dictionary<int, int>
            {
                { 10, 10 }
            };

            var decorator = new DictionaryDecorator<int, int>(dictionary);
            Assert.True(decorator.ContainsKey(10));
        }

        [Fact]
        public void SpanTest()
        {
            Span<int> span = stackalloc int[] { 1, 2, 3 };
            var decorator = new SpanDecorator<int>(span);
            Assert.Equal(span[0], decorator[0]);
        }
    }
}