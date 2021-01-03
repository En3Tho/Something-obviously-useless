using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using static System.Runtime.CompilerServices.Unsafe;

namespace ExtensionsAndStuff.Unsafe.SpanExtensions
{
    public readonly unsafe struct SpanEnumerable<T> : IEnumerable<T>
    {
        private readonly void* _sourceRef;
        private readonly int _sourceLength;

        public SpanEnumerable(Span<T> span)
        {
            _sourceRef = AsPointer(ref span[0]);
            _sourceLength = span.Length;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private struct Enumerator : IEnumerator<T>
        {
            private readonly SpanEnumerable<T> _wrapper;
            private int _index;
            private T _current;

            public Enumerator(SpanEnumerable<T> wrapper)
            {
                _wrapper = wrapper;
#pragma warning disable CS8653
                _current = default;
#pragma warning restore
                _index = 0;
            }

            public bool MoveNext()
            {
                if (_index < _wrapper._sourceLength)
                {
                    _current = Add(ref AsRef<T>(_wrapper._sourceRef), _index);
                    _index++;
                    return true;
                }

                Reset();
                return false;
            }

            public void Reset()
            {
                _index = 0;
#pragma warning disable CS8653
                _current = default;
#pragma warning restore
            }

            [MaybeNull]
            public T Current => _current;

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }

    public static class SpanEnumerable
    {
        public static SpanEnumerable<T> Create<T>(Span<T> span) => new SpanEnumerable<T>(span);
    }
}