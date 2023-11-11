namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class Stack<T> : IAbstractStack<T>
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

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            var nod = new Node(item, top);
            top = nod;
            Count++;
        }

        public T Pop()
        {
            if (top == null)
            {
                throw new InvalidOperationException("colection is Empty");
            }
            var oldTop = top;
            if (top.Next != null)
            {
                top = top.Next;
            }
            else
            {
                top = null;
            }

            Count--;
            return oldTop.Element;
        }

        public T Peek()
        {
            if (top == null)
            {
                throw new InvalidOperationException("colection is Empty");
            }
            return top.Element;
        }

        public bool Contains(T item)
        {
            var note = top;
            while (note != null)
            {
                if (item.Equals(note.Element))
                {
                    return true;
                }

                note = note.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var note = top;
            while(note != null)
            {
                yield return note.Element;
                note = note.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }


}