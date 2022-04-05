using System;

namespace Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            int[] array1;// = new int[4] { 5, 2, 3, 5 }; 
            int[] array2;// = new int[5] { 2, 5, 5, 5, 5 };

            array1 = MatchArray.RandomArray(250000, 1, 1000); 
            array2 = MatchArray.RandomArray(250000, 1, 1000);

            watch.Start();
            int[] output = MatchArray.MatchingNumbers(array1, array2);
            foreach (var item in output)
            {
                Console.Write(item + ", ");
            }
            watch.Stop();

            Console.WriteLine("");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds} ms");
        }
    }
}
