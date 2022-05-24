using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver.Data
{
    public class Vertex
    {
        public char Data { get; set; }
        public int Index { get; set; }
        public List<Edge> Connections { get; set; }

        public void AddConnection(Edge edge)
        {
            Connections.Add(edge); 
        }
    }
}
