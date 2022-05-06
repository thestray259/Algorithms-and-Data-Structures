using System;

namespace Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            AlgoDataStructures.SingleLinkedList<int> list = new AlgoDataStructures.SingleLinkedList<int>();
            list.Add(24);
            list.Add(3);
            list.Add(6);
            list.Add(0);
            list.Add(6);
            list.Add(17);
            list.Add(100);
            list.Add(2014);
            list.Add(122778);
            list.Add(42);

            Console.WriteLine(list.Get(9));
        }
    }
}
