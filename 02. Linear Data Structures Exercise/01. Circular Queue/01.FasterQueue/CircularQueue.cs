namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private const int capasity = 4;
        private T[] elements;
        private int startIndex;
        private int endIndex;
        public CircularQueue()
        {
            elements = new T[capasity];
        }

        public int Count { get; private set; }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = elements[startIndex];
            elements[startIndex] = default;
            Count--;
            startIndex = (startIndex + 1) % elements.Length;
            return element;
        }

        public void Enqueue(T item)
        {
            if (Count >= elements.Length)
            {
                Grow();
            }

            elements[endIndex] = item;
            endIndex = (endIndex + 1) % elements.Length;
            Count++;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return elements[startIndex];
        }

        public T[] ToArray()
        {

            T[] array = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                array[i] = elements[(startIndex + i) % elements.Length];
            }

            return array;
        }

        private void Grow()
        {
            elements = CopyElements();
            startIndex = 0;
            endIndex = Count;
        }

        private T[] CopyElements()
        {
            T[] array = new T[elements.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                array[i] = elements[(startIndex + i) % elements.Length];
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int curentIndex = 0; curentIndex < Count; curentIndex++)
            {
                yield return elements[(startIndex + curentIndex) % elements.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }

}
