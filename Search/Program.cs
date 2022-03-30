using System;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] items = { 2, 10, 15, 24, 30, 36, 42, 55, 68, 90, 105, 206 };
            int target = 90;

            //int index = Linear.SearchLinear(items, target); 
            int index = Binary.SearchBinary(items, target, 0, items.Length - 1); 

            if (index != -1)
            {
                Console.WriteLine(target + " was found at index: " + index);
                Console.WriteLine("Item at index is: " + items[index]);
            }
            else Console.WriteLine(target + " was not found in the array. ");

            Console.ReadLine(); 
        }
    }
}
