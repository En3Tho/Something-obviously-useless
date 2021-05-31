// using System.Collections.Generic;
// using System.Linq;
//
// namespace En3Tho.HelperClasses.Collections
// {
//     public class CircularLinkedList<T>
//     {
//         private readonly LinkedList<T> _linkedList;
//         public LinkedListNode<T> Head => _linkedList.First;
//         private LinkedListNode<T> Current;
//
//         public CircularLinkedList(int count)
//         {
//             _linkedList = new LinkedList<T>();
//
//             for (int i = 0; i < count - 1; i++)
//             {
//                 _linkedList.AddLast(default(T));
//             }
//
//             _linkedList.AddLast(_linkedList.First);
//
//             Current = current;
//         }
//
//         public void WriteValue(T value)
//     }
// }