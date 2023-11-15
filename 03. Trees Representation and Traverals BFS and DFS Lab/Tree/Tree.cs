namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;
        private T value;
        private Tree<T> parent;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] childrens)
            : this(value)
        {
            foreach (var child in childrens)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = this.FindNodeWhitBfs(parentKey);

            if (parentNode == null)
            {
                throw new ArgumentNullException();
            }

            parentNode.children.Add(child);
            child.parent = parentNode;
        }

        private Tree<T> FindNodeWhitBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                if (subtree.value.Equals(parentKey))
                {
                    return subtree;
                }

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private void Dfs(Tree<T> node, ICollection<T> result)
        {

            foreach (var child in node.children)
            {
                this.Dfs(child, result);
            }
            result.Add(node.value);

        }

        public IEnumerable<T> OrderDfs()
        {
            var list = new List<T>();
            Dfs(this, list);
            return list;
        }
        public IEnumerable<T> OrderBfs()
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<T>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                result.Add(subtree.value);

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return result;
        }

        public IEnumerable<T> SteckOrderDfs()
        {
            var stack = new Stack<Tree<T>>();
            var result = new Stack<T>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                foreach (var child in node.children)
                {
                    stack.Push(child);
                }

                result.Push(node.value);
            }
            return result;
        }

        public void RemoveNode(T nodeKey)
        {
            var node = FindNodeWhitBfs(nodeKey);

            if (node is null)
            {
                throw new ArgumentNullException();
            }

            var parentNode = node.parent;

            if (parentNode is null)
            {
                throw new ArgumentException();
            }

            parentNode.children.Remove(node);
            node.parent = null;
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstChild = FindNodeWhitBfs(firstKey);
            var secondCild = FindNodeWhitBfs(secondKey);

            if (firstChild == null || secondCild == null)
            {
                throw new ArgumentNullException();
            }

            var firstChildParent = firstChild.parent;
            var secondChildParent = secondCild.parent;

            if (firstChildParent == null || secondChildParent == null)
            {
                throw new ArgumentException();
            }

            var indexOfFirstChildren = firstChildParent.children.IndexOf(firstChild);
            var indexOfSecondChildren = secondChildParent.children.IndexOf(secondCild);

            firstChildParent.children[indexOfFirstChildren] = secondCild;
            secondCild.parent = firstChildParent;
           
            secondChildParent.children[indexOfSecondChildren] = firstChild;
            firstChild.parent = secondChildParent;
           
        }
    }
}
