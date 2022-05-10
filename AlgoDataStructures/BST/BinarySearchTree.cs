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

        public void Add(T value) // works?
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

        public bool Contains(T value) // should work, test keeps failing though 
        {
            return Find(value) != null; 
        }

        public void Remove(T value) // do this 
        {

        }

        public void Clear() // works 
        {
            Root = null;
            count = 0; 
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

        public string PreOrder() // doesn't work 
        {
            BinaryTreeNode<T> prevNode = null; 
            BinaryTreeNode<T> currentNode = Root; 
            BinaryTreeNode<T> nextNode = null;

            string returnString = ""; 

            for (int i = 0; i < Count; i++)
            {
                if (prevNode == null || prevNode == currentNode.Parent)
                {
                    prevNode = currentNode;
                    nextNode = currentNode.LeftChild;
                }

                if (nextNode == null || prevNode == currentNode.LeftChild)
                {
                    prevNode = currentNode;
                    nextNode = currentNode.RightChild;
                }

                if (nextNode == null || prevNode == currentNode.RightChild)
                {
                    prevNode = currentNode;
                    nextNode = currentNode.Parent;
                }

                if (i < Count) returnString += currentNode.Data + ", ";
                else if (i == Count) returnString += currentNode.Data;
                else Console.WriteLine("Something went wrong in PreOrder");

                currentNode = nextNode;
            }

/*            while (currentNode != null)
            {
                if (prevNode == null || prevNode == currentNode.Parent)
                {
                    prevNode = currentNode;
                    nextNode = currentNode.LeftChild; 
                }

                if (nextNode == null || prevNode == currentNode.LeftChild)
                {
                    prevNode = currentNode;
                    nextNode = currentNode.RightChild; 
                }

                if (nextNode == null || prevNode == currentNode.RightChild)
                {
                    prevNode = currentNode;
                    nextNode = currentNode.Parent; 
                }

                returnString += currentNode.Data + " "; 
                currentNode = nextNode; 
            }*/

            return returnString; 
        }

        public string PostOrder() // do this 
        {
            throw new NotImplementedException(); 
        }

        // helper guys 

        public BinaryTreeNode<T> Find(T node)
        {
            BinaryTreeNode<T> currentNode = Root; 

            while (currentNode != null)
            {
                int result = comparer.Compare(node, currentNode.Data);

                if (result == 0) return currentNode;
                else if (result < 0) currentNode = currentNode.LeftChild;
                else currentNode = currentNode.RightChild; 


            }

            return null; 
        }
    }
}
