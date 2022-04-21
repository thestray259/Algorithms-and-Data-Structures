using System;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] foldArray = { 1, 2, 3, 4, 5 };

            int[] foldOutput = FoldArrayInHalf.FoldArray(foldArray, 1); 
            foreach (var num in foldOutput)
            {
                Console.WriteLine(num);
            }
        }
    }
}
