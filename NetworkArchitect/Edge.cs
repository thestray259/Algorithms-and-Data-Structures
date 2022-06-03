using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect
{
    class Edge
    {
        public Vertex Start { get; set; }
        public Vertex End { get; set; }
        public int Weight { get; set; }

        public Edge() { } 
        public Edge(Vertex start, Vertex end, int weight)
        {
            this.Start = start;
            this.End = end;
            Weight = weight; 
        }
    }
}
