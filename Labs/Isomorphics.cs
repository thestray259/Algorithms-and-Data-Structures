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

        public static void CreateIsomorphs()
        {
            //Go();
            string[] fileLines; 

            Console.WriteLine("Please provide a path to the file: ");
            string path = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(path))
            {
                fileLines = File.ReadAllLines(path);

/*                var exactIsos = ExactIsomorphs(fileLines);
                foreach (var key in exactIsos.Keys)
                {
                    foreach (var listValue in exactIsos[key])
                    {
                        Console.WriteLine(exactIsos.Keys + " -> " + listValue);

                    }
                }*/

                Console.WriteLine("Exact Isomorphs: "); 
                foreach (var value in ExactIsomorphs(fileLines))
                {
                    Console.WriteLine(value.Key + " : " + value.Value.ToString()); 
                }
            }

            //LooseIsomorphs(lines); 

            // if word is not exact or loose, list as neither
        }

        public static Dictionary<string, List<string>> ExactIsomorphs(string[] lines) // code to get just the exact isomorphs 
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<string> codes = new List<string>();
            List<string> exactIsos = new List<string>();

            List<string> distinctCodes = codes.Distinct<string>().ToList();

            foreach (var word in lines)
            {
                string code = ExactIsoID(word);
                dict.Add(word, code);
                codes.Add(code); 
            }            

            foreach (var word in lines)
            {
                string code = ExactIsoID(word);

                if (distinctCodes.Contains(code))
                {
                    exactIsos.Add(word); 
                }
            }

            // master dictionary to hold codes and words 
            Dictionary<string, List<string>> masterDict = new Dictionary<string, List<string>>(); 

            foreach (var isoCode in distinctCodes)
            {
                List<string> tempWords = new List<string>(); 

                foreach (KeyValuePair<string, string> entry in dict)
                {
                    if (entry.Value == isoCode)
                    {
                        tempWords.Add(entry.Key);
                    }
                }

                masterDict.Add(isoCode, tempWords); 
            }

            return masterDict; 
        }

        public static string LooseIsomorphs(string[] lines) // code to get just the loose isomorphs 
        {


            return ""; 
        }

        public static string ExactIsoID(string word) // code to get just the iso code for exact isos 
        {
            char[] wordChars = word.ToCharArray();
            List<char> charList = new List<char>();
            string isoCode = ""; 

            foreach (char letter in wordChars)
            {
                if (!charList.Contains(letter))
                {
                    charList.Add(letter); 
                }
                isoCode += charList.IndexOf(letter) + " "; 
            }

            return isoCode.Trim(); 
        }

        public static string LooseIsoID(string word) // code to get just the iso code for loose isos 
        {
            char[] wordChars = word.ToCharArray();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            string isoCode = "";

            foreach (char letter in wordChars)
            {
                if (dict.ContainsKey(letter))
                {
                    dict[letter] += 1; 
                }
                else
                {
                    dict.Add(letter, 1); 
                }
            }

            foreach (var item in dict.Values)
            {
                isoCode += item + " "; 
            }

            return isoCode.Trim(); 
        }

        public static string GetName(string line)
        {
            //code here

            return ""; 
        }
    }
}
