using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures
{
    public class AVLTree<T> where T : IComparable
    {
        int count;
        public Node Root;
        public Node node = new Node();
        public delegate int CompareDelegate(T v1, T v2);
        public readonly CompareDelegate compare = Comparer<T>.Default.Compare;

        public int Count { get { return count; } }

        public AVLTree()
        {
            Root = null;
            count = 0;
        }

        public AVLTree(CompareDelegate compare) : this() { this.compare = compare; }

        public void Add(T value)
        {
            count++;
            Root = (Root == null) ? new Node(value, null) : Root.Insert(value, compare);
            node.Rebalance();
        }

        public void Remove(T value)
        {
            throw new NotImplementedException();

            //node.Rebalance(); 
        }

        public T[] ToArray()
        {
            T[] array = new T[count];
            int arrayIndex = 0;

            foreach (T item in this) array[arrayIndex++] = item;

            return array;
        }

        public Node Find(T value)
        {
            return Root.Find(value, compare);
        }

        public class Node
        {
            public int height;
            public int BalanceFactor => LeftChild.height - RightChild.height;
            public T Data;

            public Node Parent;
            public Node LeftChild;
            public Node RightChild;

            public Node() { }
            public Node(T value, Node parent)
            {
                this.Data = value;
                this.Parent = parent;
                LeftChild = null;
                RightChild = null;
                height = 1;
            }

            public Node Insert(T value, CompareDelegate compare)
            {
                if (compare(value, this.Data) < 0) return Insert(ref LeftChild, value, compare);
                else return Insert(ref RightChild, value, compare);
            }

            public Node Insert(ref Node node, T value, CompareDelegate compare)
            {
                if (node == null)
                {
                    node = new Node(value, this);
                    return node.Rebalance();
                }
                else return node.Insert(value, compare);
            }

            public Node Find(T value, CompareDelegate compare)
            {
                int cmp = compare(this.Data, value);
                if (cmp == 0) return this;
                else if (cmp > 0) return LeftChild.Find(value, compare);
                else return RightChild.Find(value, compare);
            }

            public Node Rebalance()
            {
                Node v = this;
                Node newRoot = this;
                bool restructured = false;
                while (v != null)
                {
                    if (!restructured && Math.Abs(ChildHeight(v.LeftChild) - ChildHeight(v.RightChild)) > 1)
                    {
                        v = Restructure(v);
                        restructured = true;
                    }
                    v.height = 1 + v.MaxChildHeight();
                    newRoot = v;
                    v = v.Parent;
                }
                return newRoot;
            }

            public static int ChildHeight(Node child)
            {
                return (child == null) ? 0 : child.height;
            }

            public int MaxChildHeight()
            {
                return Math.Max(ChildHeight(LeftChild), ChildHeight(RightChild));
            }

            public Node ChildWithMaxHeight()
            {
                return (ChildHeight(LeftChild) > ChildHeight(RightChild)) ? LeftChild : RightChild;
            }

            public Node Restructure(Node node)
            {
                var node1 = node.ChildWithMaxHeight();
                var node2 = node1.ChildWithMaxHeight();
                Node nodeA, nodeB, nodeC;
                Node T1, T2;
                if (node2 == node1.LeftChild && node1 == node.LeftChild)
                {
                    nodeA = node2; nodeB = node1; nodeC = node;
                    T1 = nodeA.RightChild;
                    T2 = nodeB.RightChild;
                }
                else if (node2 == node1.RightChild && node1 == node.RightChild)
                {
                    nodeA = node; nodeB = node1; nodeC = node2;
                    T1 = nodeB.LeftChild;
                    T2 = nodeC.LeftChild;
                }
                else if (node2 == node1.LeftChild && node1 == node.RightChild)
                {
                    nodeA = node; nodeB = node2; nodeC = node1;
                    T1 = nodeB.LeftChild;
                    T2 = nodeB.RightChild;
                }
                else
                {
                    nodeA = node1; nodeB = node2; nodeC = node;
                    T1 = nodeB.LeftChild;
                    T2 = nodeB.RightChild;
                }
                if (node.Parent != null)
                {
                    if (node == node.Parent.LeftChild)
                        node.Parent.LeftChild = nodeB;
                    else node.Parent.RightChild = nodeB;
                }
                nodeB.Parent = node.Parent;

                nodeB.LeftChild = nodeA;
                nodeA.Parent = nodeB;
                nodeB.RightChild = nodeC;
                nodeC.Parent = nodeB;

                nodeA.RightChild = T1;
                if (T1 != null) T1.Parent = nodeA;
                nodeC.LeftChild = T2;
                if (T2 != null) T2.Parent = nodeC;
                nodeA.height = 1 + nodeA.MaxChildHeight();
                nodeB.height = 1 + nodeB.MaxChildHeight();
                nodeC.height = 1 + nodeC.MaxChildHeight();
                return nodeB;
            }
        }

        // helpers 
        public string BreadthFirst()
        {
            string str = "";
            string returnString = ""; 

            if (Root == null) return ""; 
            //else
            {
                str += BreadthFirstHelper(Root); 
            }

            if (str.Length != 0)
            {
                returnString = str.Remove(str.Length - 2);
            }

            return returnString; 
        }

        public string BreadthFirstHelper(Node node)
        {
            string str = ""; 
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);

            if (node == null) return "";
            if (node.LeftChild == null && node.RightChild == null) return str += node.Data + ", "; 
            
            while (queue.Count != 0)
            {
                Node tempNode = queue.Dequeue();
                str += tempNode.Data + ", "; 
                //Console.Write(tempNode.Data + ", ");

                /*Enqueue left child */
                if (tempNode.LeftChild != null)
                {
                    queue.Enqueue(tempNode.LeftChild);
                }

                /*Enqueue right child */
                if (tempNode.RightChild != null)
                {
                    queue.Enqueue(tempNode.RightChild);
                }
            }

            foreach (var value in queue) str += value + ", "; 

            return str; 
        }

        public IEnumerator<T> GetEnumerator() // works
        {
            foreach (T element in BreadthFirstEnumHealper) yield return element;
        }

        public IEnumerable<T> BreadthFirstEnumHealper
        {
            get
            {
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(Root);
                while (queue.Count != 0)
                {

                    Node tempNode = queue.Dequeue();
                    Console.Write(tempNode.Data + " ");

                    /*Enqueue left child */
                    if (tempNode.LeftChild != null)
                    {
                        queue.Enqueue(tempNode.LeftChild);
                    }

                    /*Enqueue right child */
                    if (tempNode.RightChild != null)
                    {
                        queue.Enqueue(tempNode.RightChild);
                    }
                }

                return default; 
            }
        }
    }
}
