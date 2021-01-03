using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using ExtensionsAndStuff.RefStructs.SpanList;
using static System.Runtime.CompilerServices.Unsafe;

namespace ExtensionsAndStuff.Unsafe.SpanHeapListExtensions
{
    public readonly unsafe struct SpanHeapListEnumerable<T> : IEnumerable<T>
    {
        private readonly void* _sourceRef;
        private readonly int _sourceLength;
        private readonly void* _arrayRef;
        private readonly int _arrayLength;

        public SpanHeapListEnumerable(SpanHeapList<T>.SpanContainer container)
        {
            if (container.SourceSpan.Length > 0)
            {
                _sourceRef = AsPointer(ref container.SourceSpan[0]);
                _sourceLength = container.SourceSpan.Length;
            }
            else
            {
                _sourceRef = (void*) 0;
                _sourceLength = 0;
            }

            if (container.ArraySpan.Length > 0)
            {
                _arrayRef = AsPointer(ref container.ArraySpan[0]);
                _arrayLength = container.ArraySpan.Length;
            }
            else
            {
                _arrayRef = (void*) 0;
                _arrayLength = 0;
            }
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
            private readonly SpanHeapListEnumerable<T> _wrapper;
            private int _index;
            private T _current;
            private void* _currentRef;
            private int _currentLength;
            
            public Enumerator(SpanHeapListEnumerable<T> wrapper)
            {
                _wrapper = wrapper;
#pragma warning disable CS8653
                _current = default;
#pragma warning restore
                _index = 0;
                _currentRef = wrapper._sourceRef;
                _currentLength = wrapper._sourceLength;
            }

            public bool MoveNext()
            {
                if (_index == _currentLength && !SwitchCurrentAndReturnValue())
                {
#pragma warning disable CS8653
                    _current = default;
#pragma warning restore
                    return false;
                }

                _current = Add(ref AsRef<T>(_currentRef), _index);
                _index++;
                return true;
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            private bool SwitchCurrentAndReturnValue()
            {
                if (_currentRef == _wrapper._arrayRef || _wrapper._arrayLength == 0)
                    return false;
                {
                    _currentRef = _wrapper._arrayRef;
                    _currentLength = _wrapper._arrayLength;
                    _index = 0;
                    return true;
                }
            }
            
            public void Reset()
            {
                _index = 0;
#pragma warning disable CS8653
                _current = default;
#pragma warning restore
                _currentRef = _wrapper._sourceRef;
            }

            [MaybeNull]
            public T Current => _current;

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}