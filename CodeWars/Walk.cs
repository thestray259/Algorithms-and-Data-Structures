using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    class Walk
    {
        public static bool IsValidWalk(string[] walk)
        {
            //insert brilliant code here
            if (walk.Length == 10)
            {
                int n = 0; 
                int s = 0; 
                int w = 0; 
                int e = 0; 
                // if all n's - all s's = 0 and all w's - all e's = 0 return true 
                foreach (var north in walk)
                {
                    if (north == "n") n++;
                }
                foreach (var south in walk)
                {
                    if (south == "s") s++;
                }
                foreach (var west in walk)
                {
                    if (west == "w") w++;
                }
                foreach (var east in walk)
                {
                    if (east == "e") e++;
                }

                if (n - s == 0 && w - e == 0)
                {
                    return true;
                }
                else return false; 
            }

            return false; 
        }
    }
}
