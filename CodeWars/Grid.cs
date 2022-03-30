using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    public class Grid
    {
        public static int NumberOfRectangles(int m, int n)
        {
            return (m * n * (n + 1) * (m + 1)) / 4;
        }
    }
}
