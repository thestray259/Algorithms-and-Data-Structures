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
            List<int> a1 = array1.ToList();
            List<int> a2 = array2.ToList();

            a1.Sort();
            a2.Sort(); 

            if (a1.Count >= a2.Count)
            {
                foreach (var a in a1)
                {
                    if (a2.Contains(a))
                    {
                        a2.Remove(a);
                        outputArray.Add(a);
                    }
                }
            }
            else
            {
                foreach (var a in a2)
                {
                    if (a1.Contains(a))
                    {
                        a1.Remove(a);
                        outputArray.Add(a); 
                    }
                }
            }

            return outputArray.ToArray();
        }

        public static int[] RandomArray(int num, int min, int max)
        {
            int[] array = new int[num];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(min, max); 
            }

            return array; 
        }
    }
}
