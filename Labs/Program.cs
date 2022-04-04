using System;

namespace Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[5] { 2, 3, 3, 5, 5 }; 
            int[] array2 = new int[5] { 2, 5, 5, 5, 5 }; 

            int[] output = MatchArray.MatchingNumbers(array1, array2);
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }
    }
}
