namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node head;
        private Node tail;
        private class Node
        {
            public Node Next { get; set; }
            public Node Prev { get; set; }
            public T Value { get; set; }

            public Node(T value)
            {

                Value = value;

            }
        }


        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node(item);

            if (Count == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.Next = head;
                head.Prev = node;
                head = node;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            var node = new Node(item);

            if (Count == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.Prev = tail;
                tail.Next = node;
                tail = node;
            }

            Count++;
        }

        public T GetFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return head.Value;
        }

        public T GetLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return tail.Value;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            var node = head;

            if (Count == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
                head.Prev = null;
            }
            Count--;

            return node.Value;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            var node = head;

            if (Count == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.Prev;
                tail.Next = null;
            }
            Count--;

            return node.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
         => GetEnumerator();
    }
}