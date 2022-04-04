using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public static class Palindrome
    {
        public static bool PalindromeCheck(string word)
        {
            string str1 = word.Replace(" ", ""); 
            string str2 = ReverseWord(word.Replace(" ", ""));

            if (str1 == str2)
            {
                Console.WriteLine("true");
                return true;
            }
            else
            {
                Console.WriteLine("false");
                return false;
            }
        }

        public static string ReverseWord(string s)
        {
            char[] charArray = s.Replace(" ", "").ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray); 
        }
    }
}
