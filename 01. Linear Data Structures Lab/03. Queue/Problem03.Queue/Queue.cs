namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }

            public Node(T element)
                : this(element, null)
            {
                Element = element;
            }
        }

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if (head == null)
            {
                head = new Node(item);
                Count++;
                return;
            }
            var node = head;
            while (node.Next != null)
            {
                node = node.Next;
            }

            node.Next = new Node(item);
            Count++;
        }

        public T Dequeue()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            var node = head;
            head = head.Next;
            Count--;
            return node.Element;
        }

        public T Peek()
        {
            if(head == null)
            {
                throw new InvalidOperationException();
            }
            
            return head.Element;
        }

        public bool Contains(T item)
        {
            var node = head;
            while (node != null)
            {
                if (item.Equals(node.Element))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = head;
            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}