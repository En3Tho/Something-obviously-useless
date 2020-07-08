using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ExtensionsAndStuff.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Enumerator which recursively gets elements from IEnumerable of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        private sealed class FlattenEnumerator<T, R> : IEnumerator<T>, IEnumerable<T> where R : IEnumerable<T>
        {
            private readonly Func<T, R> _childCollectionGetter;
            private readonly LinkedList<IEnumerator<T>> _linkedList;
            private LinkedListNode<IEnumerator<T>> _listNode;

            public FlattenEnumerator(IEnumerable<T> source, Func<T, R> childCollectionGetter)
            {
                _childCollectionGetter = childCollectionGetter;
                _linkedList = new LinkedList<IEnumerator<T>>();
                _listNode = _linkedList.AddFirst(source.GetEnumerator());
                Current = default!;
            }

            public bool MoveNext()
            {
                start:
                if (Enumerator.MoveNext())
                {
                    Current = Enumerator.Current;
                    var childCollection = _childCollectionGetter(Current);
                    if (childCollection is {})
                    {
                        var next = _listNode.Next;
                        if (next is null) // recursion is not deep enough, so get a new node.
                            _listNode = _linkedList.AddAfter(_listNode, childCollection.GetEnumerator());
                        else // we have been there and got back to parent sequence. Just reuse node in this case.
                        {
                            next.Value = childCollection.GetEnumerator();
                            _listNode = next;
                        }
                    }

                    return true;
                }

                var prevNode = _listNode.Previous;
                if (prevNode is null) // we're at head node
                {
                    Current = default!;
                    return false;
                }

                ClearNode(_listNode);
                _listNode = prevNode;
                goto start;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void ClearNode(LinkedListNode<IEnumerator<T>> node)
            {
                node.Value.Dispose();
                node.Value = null!; // cleared to somewhat reduce gc pressure in case of deep nesting because we reuse nodes but don't reuse enumerators
            }

            public void Reset()
            {
                _listNode = _linkedList.First!;
                _listNode.Value.Reset();
                Dispose(_listNode.Next!);
                Current = default!;
            }
            
            private IEnumerator<T> Enumerator
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)] get => _listNode.Value;
            }

            public T Current { get; private set; }

            object? IEnumerator.Current => Current;

            public void Dispose() => Dispose(_linkedList.First!);

            private void Dispose(LinkedListNode<IEnumerator<T>> start)
            {
                for (var node = start; node?.Value is {}; node = node.Next)
                    ClearNode(node);
            }

            public IEnumerator<T> GetEnumerator() => this;

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public static IEnumerable<T> Flatten<T, R>(this IEnumerable<T> source, Func<T, R> recursion) where R : IEnumerable<T>
        {
            source ??= ThrowHelper.ThrowArgumentNullException(source, nameof(source));
            return new FlattenEnumerator<T, R>(source, recursion);
        }

        public static List<T> ToListRecursive<T, R>(this IEnumerable<T> source, Func<T, R> recursion) where R : IEnumerable<T>
        {
            source ??= ThrowHelper.ThrowArgumentNullException(source, nameof(source));
            var store = new List<T>();

            static void flattenInternal(IEnumerable<T> source, Func<T, R> recursion, List<T> store)
            {
                foreach (var child in source)
                {
                    store.Add(child);
                    var rec = recursion(child);
                    if (rec is {}) flattenInternal(rec, recursion, store);
                }
            }

            flattenInternal(source, recursion, store);
            return store;
        }
    }
}