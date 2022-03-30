using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class Binary
    {
        public static int SearchBinary(int[] items, int target, int min, int max)
        {
            int mid = (min + max) / 2; 

            if (min >= max)
            {
                if (items[min] == target) return min;
                else return -1; 
            }
            else
            {
                if (items[mid] == target) return mid;
                else if (items[mid] < target) return SearchBinary(items, target, mid + 1, max);
                else return SearchBinary(items, target, min, max - 1); 
            }
        }
    }
}
