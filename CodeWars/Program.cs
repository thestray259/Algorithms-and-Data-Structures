using System;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] test = { "n", "s", "w", "e", "n", "s", "s", "n", "w", "w" };

            bool answer = Walk.IsValidWalk(test); 
            Console.WriteLine(answer);
        }
    }
}
