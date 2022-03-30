using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class Linear
    {
        public static int SearchLinear(int [] items, int target)
        {
            // search array for the target number 
            // return the index the target number is at 
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == target) return i; 
            }

            // if target not found, return -1 
            return -1;
        }
    }
}
