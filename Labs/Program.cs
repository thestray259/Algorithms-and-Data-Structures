using AlgoDataStructures;
using System;

namespace Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            //BinarySearchTree<int> tree = new BinarySearchTree<int>();
            AVLTree<int> avl = new AVLTree<int>();

            avl.Add(7);
            avl.Add(8);
            avl.Add(9);
            avl.Add(10);
            avl.Add(11);
            avl.Add(12);
            avl.Add(13);
            avl.Add(24);
            avl.Add(90);
            avl.Add(100);
            avl.Add(110);
            avl.Add(1337);
            avl.Add(1350);
            avl.Add(1400);
            avl.Add(1500);

            foreach (var item in avl.ToArray())
            {
                Console.WriteLine(item + " ");
            }

            //Console.WriteLine("Expected: 24, 10, 1337, 8, 12, 100, 1400, 7, 9, 11, 13, 90, 110, 1350, 1500");

            //Console.WriteLine("Actual: " + avl.BreadthFirst());
            //Console.WriteLine(avl.BreadthFirst() + "Actual: ");

            //tree.Add(24);
            //tree.Add(10);
            //tree.Add(11337);
            //tree.Add(5);
            //tree.Add(3);

            //tree.Remove(24); 

            //Console.WriteLine("Expected: " + "10, 11337");
            //Console.WriteLine("Actual: " + tree.InOrder());
        }
    }
}
