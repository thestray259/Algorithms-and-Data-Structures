using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public static class MatchArray
    {
        // numbers in array must be sorted 
        // remove matches from both arrays, and insert the matching number into a third array to output 

        public static int[] MatchingNumbers(int[] array1, int[] array2)
        {
            List<int> outputArray = new List<int>();

            array1.ToList().Sort(); 
            array2.ToList().Sort(); 

            foreach (var firstNumber in array1)
            {

                foreach (var secondNumber in array2)
                {
                    if (secondNumber == firstNumber)
                    {
                        // add secondNumber to output array 
                        // remove secondNumber from array2 
                        // remove firstNumber from array1

                        outputArray.Add(secondNumber);
                        //array1.Remove(firstNumber); //doesn't work???
                    }
                }
            }

            return outputArray.ToArray(); 
        }
    }
}
