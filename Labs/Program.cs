using AlgoDataStructures;
using System;

namespace Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(0);
            tree.Add(2);
            tree.Add(1);

            Console.WriteLine(tree.ToString());
        }
    }
}
