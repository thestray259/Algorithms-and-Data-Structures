using System;
using System.Collections.Generic;
using System.IO;

namespace NetworkArchitect
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file path:");
            string path = Console.ReadLine();

            List<string> lines = new List<string>(File.ReadAllLines(path));


        }
    }
}
