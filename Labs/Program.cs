using AlgoDataStructures;
using System;

namespace Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(5);
            tree.Add(3);

            Console.WriteLine("Expected: 4, 2, 1, 3, 5");
            Console.WriteLine("Actual: " + tree.PreOrderHelper(tree.Root));

        }
    }
}
