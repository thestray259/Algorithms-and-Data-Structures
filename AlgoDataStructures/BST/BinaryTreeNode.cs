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
        public BinaryTreeNode(int v) { }
        public BinaryTreeNode(T data)
        {
            this.Data = data;
        }

        public BinaryTreeNode(T data, BinaryTreeNode<T> next)
        {
            this.Data = data;
            this.Next = next;
        }

        public T Data { get; set; }

        public BinaryTreeNode<T> Next { get; set; }
        //public BinaryTreeNode<T> Prev { get; set; }
        public BinaryTreeNode<T> Parent { get; set; }
        public BinaryTreeNode<T> LeftChild { get; set; }
        public BinaryTreeNode<T> RightChild { get; set; }
    }
}
