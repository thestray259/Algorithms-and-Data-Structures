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

            int[] arr = { 4, 2, 1, 5, 3 };

            Console.WriteLine("Expected: " + arr.ToString());
            Console.WriteLine("Actual: " + tree.ToArray());
        }
    }
}
