using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    class Packer
    {
        public static int PackBagpack(int[] scores, int[] weights, int capacity)
        {
            int[,] r = new int[scores.Length + 1, capacity + 1];

            for (int i = 0; i < scores.Length; i++) 
            {
                for (int j = 1; j <= capacity; j++)
                {
                    if (weights[i] <= j) // if weight is less than the capacity, keep filling backpack
                    {
                        if (r[i, j] > (scores[i] + r[i, j - weights[i]]))
                        {
                            r[i + 1, j] = r[i, j];
                        }
                        else
                        {
                            r[i + 1, j] = scores[i] + r[i, j - weights[i]];
                        }
                    }
                    else 
                    {
                        r[i + 1, j] = r[i, j];
                    }
                }
            }

            return r[scores.Length, capacity];
        }
    }
}
