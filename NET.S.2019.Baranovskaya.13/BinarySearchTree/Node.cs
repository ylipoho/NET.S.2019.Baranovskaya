namespace BinarySearchTreeTask
{
    /// <summary>
    /// Describes a binary tree node with a generic type data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        internal Node(T data, Node<T> left = null, Node<T> right = null)
        {
            this.Data = data;
            this.Left = left;
            this.Right = right;
        }
        
        internal Node<T> Left { get; set; }

        internal Node<T> Right { get; set; }

        internal T Data { get; set; }
    }
}
