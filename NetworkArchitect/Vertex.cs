using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect
{
    class Vertex
    {
        public string Id { get; set; }
        public List<Edge> connections = new List<Edge>();
        public bool IsIntree { get; set; } = false;


        public Vertex() { }
        public Vertex(string id) { this.Id = id; }

        public void AddConnection(Edge edge)
        {
            connections.Add(edge); 
        }

        public Edge GetSmallestEdge()
        {
            Edge smallest = connections[0]; 
            foreach (var connection in connections)
            {
                if (connection.Weight < smallest.Weight) smallest = connection;
            }

            return smallest; 
        }
    }
}
