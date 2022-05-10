using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures.BST
{
    public class BinarySearchTree<T> where T :IComparable
    {
        public BinaryTreeNode<T> Root { get; set; }
    }
}
