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
        public int height; 
        IComparer<T> comparer = Comparer<T>.Default;

        public BinarySearchTree() { }

        public BinaryTreeNode<T> Root { get; set; }
        public int Count { get { return count; } }
        public int HeightCount { get { return height; } }
        public IComparer<T> Comparer
        {
            get { return comparer; }
            set {
                if (value == null) throw new ArgumentNullException("value");
                if (count > 0) throw new InvalidOperationException("Cannot change the comparator while the collection is non-empty");
                comparer = value;
            }
        }

        public void Add(T value) // works 
        {
            // what Beardall wants me to do 
/*            if (Root == null) Root = new BinaryTreeNode<T>(value);
            else Root.Add(value);
            count++; */

            // what I'm actually doing 
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
                            currentNode.Parent = destinationNode;
                            break; 
                        }
                    }
                    else
                    {
                        if (destinationNode.RightChild != null) destinationNode = destinationNode.RightChild; 
                        else
                        {
                            destinationNode.RightChild = currentNode;
                            currentNode.Parent = destinationNode;
                            break; 
                        }
                    }
                }
            }
            else Root = currentNode;

            count++; 
        }

        public bool Contains(T value) // works 
        {
            return Find(value) != null; 
        }

        public void Remove(T value) // works 
        {
            BinaryTreeNode<T> node = Find(value);
            RemoveNode(node);

            count--; 
        }

        public void Clear() // works 
        {
            Root = null;
            count = 0; 
        }

        public int Height() // do this 
        {
            // root height = 1 
            // traverse down each left and right node to find max height 
            // return max height 

            return HeightCount; 
        }

        public T[] ToArray() // needs to be tested/getEnum needs to be done first 
        {
            //BinarySearchTree<T> tree = new BinarySearchTree<T>();

            T[] array = new T[count];
            int arrayIndex = 0;

            //foreach (T item in this) array[arrayIndex++] = item;
            return array; 
        }

        public string InOrder() // doesn't work
        {
            BinaryTreeNode<T> prevNode = null; 
            BinaryTreeNode<T> currentNode = Root; 
            BinaryTreeNode<T> nextNode = null;
            string returnString = "";
            string helperString = "";

            for (int i = 0; i < Count; i++)
            {
                while (currentNode != null)
                {
                    helperString += InOrderHelper(currentNode);

                    if (i < Count - 1) returnString += helperString + ", ";
                    else if (i == Count - 1) returnString += helperString;
                    else Console.WriteLine("Something went wrong in InOrder()");

                    helperString = ""; 
                    //currentNode = nextNode;
                }
            }

            return returnString; 
        }

        public string PreOrder() // doesn't work 
        {
            BinaryTreeNode<T> currentNode = Root; 

            string returnString = "";

            if (currentNode == null) return ""; 
            else
            {
                returnString += PreOrderHelper(currentNode);
            }

            return returnString; 
        }

        public string PostOrder() // do this 
        {
            throw new NotImplementedException(); 
        }

        // helper guys 

/*        public IEnumerator<T> GetEnumerator() // need InOrder done first 
        {
            foreach (T element in InOrder) yield return element; 
        }*/

        public BinaryTreeNode<T> Find(T node) //works
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

        public void RemoveNode(BinaryTreeNode<T> node) // works 
        {
            if (node != null)
            {
                BinaryTreeNode<T> nextNode = new BinaryTreeNode<T>();

                if ((node.LeftChild == null) && (node.RightChild == null)) nextNode = null; // no children, so no next node
                else if (node.RightChild == null) nextNode = node.LeftChild;
                else if (node.LeftChild == null) nextNode = node.RightChild; 
                else // nextNode is leftmost node on right branch 
                {
                    nextNode = node.RightChild;
                    while (nextNode.LeftChild != null) nextNode = nextNode.LeftChild;

                    node.Data = nextNode.Data; // swap value with nextNode, then delete nextNode
                    RemoveNode(nextNode); 
                }

                if (node.Parent != null) // deleted node's parent now points to nextNode
                {
                    if (node.Parent.RightChild == node) node.Parent.RightChild = nextNode; 
                    if (node.Parent.LeftChild == node) node.Parent.LeftChild = nextNode; 
                }

                // nextNode's new parent is the deleted node's parent 
                if (nextNode != null) nextNode.Parent = node.Parent;
                // nextNode becomes new root 
                if (node == Root) Root = nextNode;
            }
        } 

        public string InOrderHelper(BinaryTreeNode<T> node)
        {
            string returnString = ""; 
            if (node != null)
            {
                InOrderHelper(node.LeftChild);
                returnString += node.Data; 
                InOrderHelper(node.RightChild); 
            }
            return returnString; 
        }

        public string PreOrderHelper(BinaryTreeNode<T> node)
        {
            string returnString = "";

            if (node == null) return "";
            returnString += node.Data + ", ";

            if (node.LeftChild == null && node.RightChild == null) return returnString += node.Data;

            if (node.LeftChild != null) // left subtree 
            {
                //returnString += "("; 
                if (node.LeftChild.LeftChild == null && node.LeftChild.RightChild == null) returnString += PreOrderHelper(node.LeftChild);
                else returnString += PreOrderHelper(node.LeftChild) + ", ";
                //returnString += ")"; 
            }

            if (node.RightChild != null) // right subtree
            {
                //returnString += "(";
                if (node.RightChild.LeftChild == null && node.RightChild.RightChild == null) returnString += PreOrderHelper(node.RightChild);
                else returnString += PreOrderHelper(node.RightChild) + ", ";
                //returnString += ")";
            }

            return returnString; 
        }
    }
}
