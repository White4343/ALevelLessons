using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionApp
{
    public static class CircularLinkedListExtensions
    {
        public static LinkedListNode<T> Next<T>(this LinkedListNode<T> node)
        {
            if (node != null && node.List != null)
            {
                return node.Next ?? node.List.First;
            }

            return null;
        }

        public static LinkedListNode<T> Previous<T>(this LinkedListNode<T> node)
        {
            if (node != null && node.List != null)
            {
                return node.Previous ?? node.List.Last;
            }
            return null;
        }
    }

    public class CircularLinkedList<T> : LinkedList<T>
    {
        public T this[int index]
        {
            get
            {
                LinkedListNode<T> current = First;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next ?? First;
                }
                return current.Value;
            }
        }

        public new IEnumerator GetEnumerator()
        {
            return new CircularLinkedListEnumerator<T>(this);
        }

        public void Add(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);

            if (Count == 0)
            {
                AddFirst(newNode);
            }
            else
            {
                AddAfter(Last, newNode);
            }
        }

        public void Remove(T value)
        {
            LinkedListNode<T> nodeToRemove = Find(value);

            if (nodeToRemove != null)
            {
                Remove(nodeToRemove);
            }
        }

        public void Print()
        {
            if (Count == 0)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            LinkedListNode<T> current = First;

            do
            {
                Console.Write(current.Value + " ");
                current = current.Next ?? First;
            }
            while (current != First);
        }
    }

    public class CircularLinkedListEnumerator<T> : IEnumerator<T>
    {
        private LinkedListNode<T> _current;
        public T Current => _current.Value;
        object IEnumerator.Current => Current;

        public CircularLinkedListEnumerator(LinkedList<T> list)
        {
            _current = list.First;
        }

        public bool MoveNext()
        {
            if (_current == null)
            {
                return false;
            }

            _current = _current.Next ?? _current.List.First;
            return true;
        }

        public void Reset()
        {
            _current = _current.List.First;
        }

        public void Dispose() { }
    }
}