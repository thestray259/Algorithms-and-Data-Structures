using System;

namespace Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            AlgoDataStructures.SingleLinkedList<int> list = new AlgoDataStructures.SingleLinkedList<int>();
            list.Add(2);
            //list.Add(6);
            //list.Add(12);

            Console.WriteLine(list.ToString());
        }
    }
}
