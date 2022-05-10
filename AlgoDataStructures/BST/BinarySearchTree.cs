using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures
{
    public class BinarySearchTree<T> where T :IComparable
    {
        public int count;
        Node<T> parentNode = null;
        Node<T> leftNode = null;
        Node<T> rightNode = null;
        IComparer<T> comparer = Comparer<T>.Default;

        public BinaryTreeNode<T> Root { get; set; }
        public int Count { get { return count; } }
        public IComparer<T> Comparer
        {
            get { return comparer; }
            set {
                if (value == null) throw new ArgumentNullException("value");
                if (count > 0) throw new InvalidOperationException("Cannot change the comparator while the collection is non-empty");
                comparer = value;
            }
        }

        public void Add(T value) // do this 
        {
            BinaryTreeNode<T> currentNode = new BinaryTreeNode<T>(value);

            if (Root != null)
            {
                BinaryTreeNode<T> destinationNode = Root; 
                while (destinationNode != null)
                {
                    int result = comparer.Compare(value, destinationNode.Data); 
                    if (result < 0)
                    {
                        if (destinationNode.LeftChild != null) destinationNode = destinationNode.LeftChild; 
                        else
                        {
                            destinationNode.LeftChild = currentNode;
                            currentNode.Parent = currentNode;
                            break; 
                        }
                    }
                    else
                    {
                        if (currentNode.RightChild != null) currentNode = currentNode.RightChild; 
                        else
                        {
                            currentNode.RightChild = currentNode;
                            currentNode.Parent = currentNode;
                            break; 
                        }
                    }
                }
            }
            else Root = currentNode;

            count++; 
        }

        public bool Contains(T value) // do this 
        {
            return false; 
        }

        public void Remove(T value) // do this 
        {

        }

        public void Clear() // do this 
        {

        }

        public int Height() // do this 
        {
            return 0; 
        }

        public T[] ToArray() // do this 
        {
            throw new NotImplementedException(); 
        }

        public string InOrder() // do this 
        {
            throw new NotImplementedException(); 
        }

        public string PreOrder() // do this 
        {
            throw new NotImplementedException(); 
        }

        public string PostOrder() // do this 
        {
            throw new NotImplementedException(); 
        }
    }
}
