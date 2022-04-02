using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public static class ExtensionMethods
    {
        public static string LetterWordToString(this LetterWord word)
        {
            return word.Letter + " Words: " + String.Join(", ", word.Words); 
        }
    }

    public class LetterWord
    {
        public LetterWord(string letter, List<string> words)
        {
            this.Letter = letter;
            this.Words = words; 
        }

        public string Letter { get; set; }
        public List<string> Words { get; set; }
    }

    public class Helpers
    {
        public static void Go()
        {
            //DebugMe(); 

            LetterWord a = new LetterWord("A", new List<string> { "Apple", "Ascend", "Algoriths" });
            LetterWord b = new LetterWord("B", new List<string> { "Bat", "Battle", "Barren" });
            LetterWord c = new LetterWord("C", new List<string> { "Cat", "Car", "Cherry" });
            LetterWord d = new LetterWord("D", new List<string> { "Dog", "Dare", "Drag" });

            List<LetterWord> myLetters = new List<LetterWord>();
            myLetters.Add(b); 
            myLetters.Add(d);

            List<LetterWord> myLetters2 = new List<LetterWord>();
            myLetters2.Add(a); 
            myLetters2.Add(c);

            myLetters.AddRange(myLetters2);

            //LINQ
            LetterWord found = myLetters.FirstOrDefault(letter => letter.Letter == "D");

            if (found == null) Console.WriteLine("Letter not found");

            myLetters = myLetters.OrderBy(m => m.Letter).ToList(); 
            myLetters = myLetters.OrderBy(m => m.Letter).ThenBy(m => m.Letter).ToList(); //to order by one thing, then by another 
            myLetters = myLetters.OrderByDescending(m => m.Letter).ToList();

            List<int> myNumbers = new List<int> { 2, 26, 13, 26, 5, 10 };

            myNumbers.Sort(); // sorts the list

            List<int> distinctValues = myNumbers.Distinct().ToList(); // gets rid of duplicates 

            List<string> allLetters = myLetters.Select(m => m.Letter).ToList(); 
            List<string> allWords = myLetters.SelectMany(m => m.Words).ToList();

            Console.WriteLine(d.LetterWordToString());

            // dictionary stuff 
            Dictionary<int, string> myPeopleDict = new Dictionary<int, string>();

            myPeopleDict.Add(1, "Ted"); // sets new entry in dictionary 
            myPeopleDict[1] = "Paul"; // changes value that is assigned to a key 

            if (myPeopleDict.ContainsKey(1))
            {
                myPeopleDict[1] = myPeopleDict[1] + " is not here. "; 
            }

            foreach (KeyValuePair<int, string> kvp in myPeopleDict)
            {
                //kvp.Key 
                //kvp.Value
            }

            //LINQ Dictionary 
            Dictionary<int, string> fNameResults = // sets the below lines to be in dictionary 
            myPeopleDict.Where(p => p.Value.Contains('F')) // to find all people in dict who's name conatins the letter F
                .ToDictionary(k => k.Key, v => v.Value);

            var person = myPeopleDict.FirstOrDefault(p => p.Key == 1); 

            for (int i = 0, j = 20; i <= j; i++, j--) // could be helpful for assignment 
            {

            }
        }

        public static void DebugMe()
        {
            int glueCrewCount = 3;

            List<int> myNumbers = new List<int>() { 2, 6, 3, 9, 12 };

            for (int i = 0; i < myNumbers.Count; i++)
            {
                Console.WriteLine(myNumbers[i]);
            }

            glueCrewCount = Multiply(glueCrewCount); 
        }

        private static int Multiply(int number)
        {
            return number * number; 
        }
    }
}
