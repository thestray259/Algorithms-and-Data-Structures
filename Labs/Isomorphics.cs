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
            string[] fileLines;
            string outputText = "";

            Console.WriteLine("Please provide a path to the file: ");
            string path = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(path))
            {
                fileLines = File.ReadAllLines(path);
                List<string> notExact = new List<string>(); 
                List<string> notLoose = new List<string>(); 
                List<string> neither = new List<string>(); 

                // Exact Isos
                Console.WriteLine("Exact Isomorphs: ");
                outputText += "Exact Isomorphs: \n"; 
                Dictionary<string, List<string>> isosExact = ExactIsomorphs(fileLines);
                foreach (var value in isosExact)
                {                    
                    // if value.Value only has 1 object in it
                    //     put in entry into notExact list and don't print 

                    if (value.Value.Count() == 1)
                    {
                        foreach (var word in value.Value)
                        {
                            notExact.Add(word); 
                        }                        
                    }                    
                    else if (value.Value.Count() >= 2)
                    {
                        Console.Write(value.Key + " : ");
                        outputText += value.Key + " : "; 
                        foreach (var word in value.Value)
                        {
                            Console.Write(word + " ");
                            outputText += word + " "; 
                        }
                        Console.WriteLine();
                        outputText += "\n"; 
                    }
                    else Console.Write("Exact Isos not working correctly. ");
                }
                Console.WriteLine(); 

                // Loose Isos
                Console.WriteLine("Loose Isomorphs: ");
                outputText += "Loose Isomorphs: \n";
                Dictionary<string, List<string>> isosLoose = LooseIsomorphs(fileLines);
                foreach (var value in isosLoose)
                {
                    // if value.Value only has 1 object in it
                    //     put in entry into notLoose list and don't print 
                    if (value.Value.Count() == 1)
                    {
                        foreach (var word in value.Value)
                        {
                            notLoose.Add(word);
                        }
                    }
                    else if (value.Value.Count() >= 2)
                    {
                        Console.Write(value.Key + " : ");
                        outputText += value.Key + " : ";
                        foreach (var word in value.Value)
                        {
                            Console.Write(word + " ");
                            outputText += word + " ";
                        }
                        Console.WriteLine();
                        outputText += "\n"; 
                    }
                    else Console.Write("Loose Isos not working correctly. ");
                }
                Console.WriteLine();

                // if word is not exact or loose, list as neither
                // compare notExact and notLoose and pull any repeating entries into a neither list and print the list contents

                foreach (var exactListItem in notExact)
                {
                    foreach (var looseListItem in notLoose)
                    {
                        if (looseListItem == exactListItem)
                        {
                            neither.Add(looseListItem); 
                        }
                    }
                }

                Console.Write("Neither: ");
                outputText += "Neither: \n"; 
                foreach (var nei in neither)
                {
                    Console.Write(nei + " ");
                    outputText += nei + " "; 
                }
                Console.WriteLine();
                outputText += "\n"; 
            }

            // write to .txt file 
            File.WriteAllText("Output.txt", outputText); 
        }

        public static Dictionary<string, List<string>> ExactIsomorphs(string[] lines) // code to get just the exact isomorphs 
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<string> codes = new List<string>();
            List<string> exactIsos = new List<string>();

            foreach (var word in lines) // gets the code of every word and inserts it into codes list  
            {
                string code = ExactIsoID(word);
                dict.Add(word, code);
                codes.Add(code); 
            }

            List<string> distinctCodes = codes.Distinct<string>().ToList();

            foreach (var word in lines) // gets the code of every word and checks it against the distinct codes list to get every exact iso code 
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

        public static Dictionary<string, List<string>> LooseIsomorphs(string[] lines) // code to get just the loose isomorphs // needs to sort numbers in code least to greatest 
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<string> codes = new List<string>();
            List<string> exactIsos = new List<string>();

            foreach (var word in lines) // gets the code of every word and inserts it into codes list  
            {
                string code = LooseIsoID(word);
                dict.Add(word, code);
                codes.Add(code);
            }

            List<string> distinctCodes = codes.Distinct<string>().ToList();

            foreach (var word in lines) // gets the code of every word and checks it against the distinct codes list to get every loose iso code 
            {
                string code = LooseIsoID(word);

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

            List<int> sortedCode = new List<int>(); 

            foreach (var value in dict.Values)
            {
                sortedCode.Add(value); 
            }

            sortedCode.Sort(); 

            foreach (var item in sortedCode)
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
