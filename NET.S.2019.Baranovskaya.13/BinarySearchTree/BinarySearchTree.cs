namespace BinarySearchTreeTask
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes a binary search tree
    /// </summary>
    /// <typeparam name="T">generic type</typeparam>
    public class BinarySearchTree<T>
    {
        private Node<T> _head;

        private Comparison<T> _compare;

        public BinarySearchTree(T data, Comparison<T> comparator)
        {
            this._head = new Node<T>(data);

            this._compare = comparator ?? Comparer<T>.Default.Compare;
        }

        public BinarySearchTree(List<T> data, Comparison<T> comparator)
        {
            this.Add(data);

            this._compare = comparator ?? Comparer<T>.Default.Compare;
        }

        public void Add(params T[] data)
        {
            List<T> list = new List<T>(data);
            this.Add(list);
        }

        public void Add(IEnumerable<T> newData)
        {
            if (newData == null)
            {
                throw new ArgumentNullException();
            }

            foreach (T data in newData)
            {
                if (data == null)
                {
                    throw new ArgumentNullException();
                }

                Add(_head, data);
            }
        }

        /// <summary>
        /// Performs a preorder traversal
        /// </summary>
        /// <returns>IEnumerable of tree values</returns>
        /// <exception cref="Exception">if tree doesn't contain any nodes</exception>
        public IEnumerable<T> PreorderTraversal()
        {
            if (_head == null)
            {
                throw new Exception("tree is null");
            }

            return Preorder(_head);
        }

        /// <summary>
        /// Performs a in-order traversal
        /// </summary>
        /// <returns>IEnumerable of tree values</returns>
        /// <exception cref="Exception">if tree doesn't contain any nodes</exception>
        public IEnumerable<T> InorderTraversal()
        {
            if (_head == null)
            {
                throw new Exception("tree is null");
            }

            return Preorder(_head);
        }

        /// <summary>
        /// Performs a post-order traversal
        /// </summary>
        /// <returns>IEnumerable of tree values</returns>
        /// <exception cref="Exception">if tree doesn't contain any nodes</exception>
        public IEnumerable<T> PostorderTraversal()
        {
            if (_head == null)
            {
                throw new Exception("tree is null");
            }

            return Preorder(_head);
        }

        /// <summary>
        /// Adds new node to binary tree
        /// </summary>
        /// <param name="currentNode">current node</param>
        /// <param name="data">new data</param>
        /// <returns>binary tree node</returns>
        private Node<T> Add(Node<T> currentNode, T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }

            if (_head == null)
            {
                return _head = new Node<T>(data);
            }

            if (_compare(currentNode.Data, data) > 0)
            {
                currentNode.Left = Add(currentNode.Left, data);
            }
            else
            {
                currentNode.Right = Add(currentNode.Right, data);
            }

            return currentNode;
        }

        /// <summary>
        /// Performs a preorder traversal
        /// </summary>
        /// <param name="node">current node</param>
        /// <returns>tree values</returns>
        private IEnumerable<T> Preorder(Node<T> node)
        {
            yield return node.Data;

            if (node.Left != null)
            {
                foreach (T data in Preorder(node.Left))
                {
                    yield return data;
                }
            }

            if (node.Right != null)
            {
                foreach (T data in Preorder(node.Right))
                {
                    yield return data;
                }
            }
        }

        /// <summary>
        /// Performs a in-order traversal
        /// </summary>
        /// <param name="node">current node</param>
        /// <returns>tree values</returns>
        private IEnumerable<T> Inorder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (T data in Preorder(node.Left))
                {
                    yield return data;
                }
            }

            yield return node.Data;

            if (node.Right != null)
            {
                foreach (T data in Preorder(node.Right))
                {
                    yield return data;
                }
            }
        }

        /// <summary>
        /// Performs a post-order traversal
        /// </summary>
        /// <param name="node">current node</param>
        /// <returns>tree values</returns>
        private IEnumerable<T> Postorder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (T data in Preorder(node.Left))
                {
                    yield return data;
                }
            }

            if (node.Right != null)
            {
                foreach (T data in Preorder(node.Right))
                {
                    yield return data;
                }
            }

            yield return node.Data;
        }
    }
}
