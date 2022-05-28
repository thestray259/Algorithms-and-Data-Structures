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
        public string DataS { get; set; }
        public int Index { get; set; }
        public List<Edge> Connections { get; set; }

        public Vertex() { }
        public Vertex(char data, int index)
        {
            this.Data = data;
            this.Index = index; 
        }

        public Vertex(string data, int index)
        {
            this.Index = index;
            this.DataS = data;
        }

        public void AddConnection(Edge edge)
        {
            Connections.Add(edge); 
        }
    }
}
