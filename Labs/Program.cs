using AlgoDataStructures;
using System;

namespace Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(24);
            tree.Add(10);
            tree.Add(11337);
            //tree.Add(5);
            //tree.Add(3);

            tree.Remove(24); 

            Console.WriteLine("Expected: " + "10, 11337");
            Console.WriteLine("Actual: " + tree.InOrder());
        }
    }
}
