using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public static class Isomorphics
    {
        public static void Go()
        {
            Console.WriteLine("Please provide a path to the file: ");
            string path = Console.ReadLine(); 

            if (!string.IsNullOrWhiteSpace(path))
            {
                string[] lines = File.ReadAllLines(path); 
            }
        }

        public static void CreateIsomorphs(string[] lines)
        {
            // code here 
        }

        public static void ExactIsomorphs(string[] lines)
        {
            // code to get just the exact isomorphs 
        }

        public static void LooseIsomorphs(string[] lines)
        {
            // code to get just the loose isomorphs 
        }

        public static string GetName(string line)
        {
            //code here

            return ""; 
        }
    }
}
