namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.items = new T[capacity];
        }
        public List()
            : this(DEFAULT_CAPACITY)
        {
        }


        public T this[int index]
        {
            get
            {
                ValidIndex(index);
                return items[index];
            }
            set
            {
                ValidIndex(index);
                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (Count == items.Length)
            {
                items = Resize();
            }

            items[this.Count++] = item;
        }

        public bool Contains(T item)
            => items.Take(Count).Any(x => x.Equals(item));

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidIndex(index);

            if (Count == items.Length)
            {
                items.Reverse();
            }

            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if(index == -1)
            {
                return false;
            }
            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            ValidIndex(index);
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            items[Count - 1] = default;
            Count--;
        }

        private T[] Resize()
        {
            T[] copy = new T[items.Length * 2];
            Array.Copy(items, copy, Count);
            return copy;
        }
        private void ValidIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("invalid index geven");
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}