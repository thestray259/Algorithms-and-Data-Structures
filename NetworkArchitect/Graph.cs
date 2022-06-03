using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect
{
    class Graph
    {
        public List<Vertex> vertices = new List<Vertex>();
        public List<string> setupLines = new List<string>(); 

        public void AddVertex(Vertex vertex)
        {
            vertices.Add(vertex); 
        }

        public Vertex GetVertex(string Id)
        {
            foreach (var vertex in vertices)
            {
                if (vertex.Id == Id) return vertex; 
            }

            return null; 
        }

        public void RemoveConnections(Vertex vertex)
        {
            foreach (var vert in vertices)
            {
                foreach (var edge in vert.connections)
                {
                    if (edge.End.Equals(vertex))
                    {
                        vert.connections.Remove(edge); 
                    }
                }
            }
        }

        public void SetupGraph(List<string> setupLines)
        {
            foreach (var vert in setupLines[0].Split(","))
            {
                vertices.Append(new Vertex(vert)); 
            }
            foreach (var line in setupLines.Skip(0))
            {
                List<string> items = new List<string>();
                items = line.Split(",").ToList();
                var curVert = GetVertex(items[0]); 

                foreach (var vert in items.Skip(0))
                {
                    List<string> val = new List<string>();
                    val = vert.Split(":").ToList();
                    Vertex vertex = GetVertex(val[0]);
                    string weight = val[1];

                    curVert.connections.Append(new Edge(curVert, vertex, int.Parse(weight))); 
                }
            }
        }
    }
}
