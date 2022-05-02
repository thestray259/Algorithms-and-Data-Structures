using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    class FoldArrayInHalf
    {
        public static int[] FoldArray(int[] array, int runs)
        {
            List<int> arrList = new List<int>();

            foreach (var num in array)
            {
                arrList.Add(num); 
            }

            for (int i = 0; i < runs; i++)
            {
                if (arrList.Count == 1) continue;
                else
                {
                    int flip = arrList.Count / 2;

                    for (int j = 0; j < flip; j++)
                    {
                        arrList[j] += arrList[arrList.Count - 1];

                        arrList.RemoveAt(arrList.Count - 1);
                    }
                }
            }

            int[] foldedArray = new int[arrList.Count];
            for (int i = 0; i < arrList.Count; i++)
            {
                foldedArray[i] = arrList[i];
            }

            return foldedArray;
        }
    }
}
