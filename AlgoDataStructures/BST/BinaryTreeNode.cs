using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures
{
    public class BinaryTreeNode<T> where T :IComparable
    {
        public BinaryTreeNode() { }
        public BinaryTreeNode(T data)
        {
            this.Data = data;
        }

        BinarySearchTree<T> bst = new BinarySearchTree<T>(); 
        IComparer<T> comparer = Comparer<T>.Default;

        public T Data { get; set; }
        public BinaryTreeNode<T> Parent { get; set; }
        public BinaryTreeNode<T> LeftChild { get; set; }
        public BinaryTreeNode<T> RightChild { get; set; }
        public IComparer<T> Comparer
        {
            get { return comparer; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                if (bst.count > 0) throw new InvalidOperationException("Cannot change the comparator while the collection is non-empty");
                comparer = value;
            }
        }

        public void Add(T value)
        {
            BinaryTreeNode<T> destinationNode = bst.Root;
            int result = comparer.Compare(value, destinationNode.Data);

            if (result < 0) LeftChild = new BinaryTreeNode<T>(value);
            else if (result > 0) RightChild = new BinaryTreeNode<T>(value); 
            else LeftChild = new BinaryTreeNode<T>(value);
        }

        // public void Add(T value) {}
        // value.CompareTo(Data) < 0 
            // if (Left == null) 
                // Left = new Node(value)
            // else Left.Add(value); 
        // value.CompareTo(Data) > 0 
            // switch lefts and rights 
        // value.CompareTo(Data) == 0
            // can allow duplicates (set as left or right, doesn't matter which)
            // could not allow duplicates, and instead increment a duplicate count (makes other methods get kinda funcky) 

        public int Height()
        {
            // ask left for height, if null then 0 
            // ask right for height 
            // compare heights, take greater one 
            // return greater height + 1

            return 0; 
        }

    }
}
