namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

        public void AddFirst(T item)
        {
            Node node = new Node(item, head);
            head = node;
            Count++;
        }

        public void AddLast(T item)
        {
            Node node = new Node(item);

            if (head == null)
            {
                head = node;
            }
            else
            {
                Node lastNode = head;
                while (lastNode.Next != null)
                {
                    lastNode = lastNode.Next;
                }
                lastNode.Next = node;
            }
            Count++;
        }

        public T GetFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            return head.Element;
        }

        public T GetLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }
            Node node = head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            return node.Element;
        }

        public T RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            Node node = head;
            head = node.Next;
            Count--;
            return node.Element;
        }

        public T RemoveLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            if (head.Next == null)
            {
                T elment = head.Element;
                head = null;
                Count--;
                return elment;
            }

            Node node = head;
            while (node.Next.Next != null)
            {
               
                node = node.Next;
            }

            var remulved = node.Element;
            node.Next = null;
            Count--;
            return remulved;
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