using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace MazeSolver.Data
{
    public class Graph
    {
        public List<Vertex> Vertices { get; set; }
        public Vertex Start { get; set; }
        public Vertex End { get; set; }
        public int graphSize;
        public StreamReader streamReader; 
        public int[,] adjMatrix;
        public const int infinity = 9999;

        public Graph()
        {
            Vertices = new List<Vertex>();
            streamReader = new StreamReader(@"C:\Users\tallen\source\repos\Algo\ThirdParty\TestMazes.txt");

            CreateGraph(); 
        }

        private void CreateGraph()
        {
            //get the graph size first
            graphSize = Convert.ToInt32(streamReader.ReadLine()) + 1;//non-zero arrays, add 1
            adjMatrix = new int[graphSize, graphSize];
            for (int i = 0; i < graphSize; i++)
            {
                adjMatrix[i, 0] = i;
            }

            if (streamReader.EndOfStream)//check if we're done
            {
                return;
            }

            //init vertices
            Vertices.Add(new Vertex("    ", -1));//no zero index to be used

            for (int i = 1; i < graphSize; i++)
            {
                string[] line = streamReader.ReadLine().Split(',');
                Vertices.Add(new Vertex(line[0], Convert.ToInt32(line[1])));
            }

            if (streamReader.EndOfStream)//check if we're done
            {
                return;
            }

            //initialize the adjacency matrix
            while (!streamReader.EndOfStream)
            {
                string[] line = streamReader.ReadLine().Split(',');
                int fromNode = Convert.ToInt32(line[0]);
                int toNode = Convert.ToInt32(line[1]);
                int cost = Convert.ToInt32(line[2]);
                AddEdge(fromNode, toNode, cost);
            }
        }

        public void AddVertex(Vertex vertex)
        {
            Vertices.Add(vertex); 
        }

        public Vertex GetVertex(char data)
        {
            return Vertices.FirstOrDefault(v => v.Data == data); 
        }

        public void RunDijkstra()//runs dijkstras algorithm on the adjacency matrix
        {
            Console.WriteLine("***********Dijkstra's Shortest Path***********");
            int[] distance = new int[graphSize];
            int[] previous = new int[graphSize];

            for (int i = 1; i < graphSize; i++)
            {
                distance[i] = infinity;
                previous[i] = 0;
            }

            int source = 1;
            //distance = 0; // threw error so commented out 
            PriorityQueue<int> pq = new PriorityQueue<int>();
            //enqueue the source
            pq.Enqueue(source, adjMatrix[0,0]); // edited adjMatrix cuz error

            //insert all remaining vertices into the pq
            for (int i = 1; i < graphSize; i++)
            {
                for (int j = 1; j < graphSize; j++)
                {
                    if (adjMatrix[i, j] > 0)
                    {
                        pq.Enqueue(i, adjMatrix[i, j]);
                    }
                }
            }

            while (!pq.Empty())
            {
                int u = pq.Dequeue_min();

                for (int v = 1; v < graphSize; v++)//scan each row fully
                {
                    if (adjMatrix[u, v] > 0)//if there is an adjacent node
                    {
                        int alt = distance[u] + adjMatrix[u, v];
                        if (alt < distance[v])
                        {
                            distance[v] = alt;
                            previous[v] = u;
                            pq.Enqueue(u, distance[v]);
                        }
                    }
                }
            }
            //distance to 1..2..3..4..5..6 etc lie inside each index

            for (int i = 1; i < graphSize; i++)
            {
                Console.WriteLine("Distance from {0} to {1}: {2}", source, i, distance[i]);
            }

            PrintPath(previous, source, graphSize - 1);
        }

        private static void PrintPath(int[] path, int start, int end) 
        {
            Console.WriteLine("Shortest path from source to destination:");
            int temp = end;
            Stack<int> s = new Stack<int>();

            while (temp != start)
            {
                s.Push(temp);
                temp = path[temp];
            }

            Console.Write("{0} ", temp); //print source

            while (s.Count != 0)
            {
                Console.Write("{0} ", s.Pop()); //print successive nodes to destination
            }
        }

        public void AddEdge(int vertexA, int vertexB, int distance)
        {
            if (vertexA > 0 && vertexB > 0 && vertexA <= graphSize && vertexB <= graphSize)
            {
                adjMatrix[vertexA, vertexB] = distance;
            }
        }

        public void RemoveEdge(int vertexA, int vertexB)
        {
            if (vertexA > 0 && vertexB > 0 && vertexA <= graphSize && vertexB <= graphSize)
            {
                adjMatrix[vertexA, vertexB] = 0;
            }
        }

        public bool Adjacent(int vertexA, int vertexB)
        {   //checks whether two vertices are adjacent, returns true or false
            return (adjMatrix[vertexA, vertexB] > 0);
        }

        public int Length(int vertex_u, int vertex_v)//returns a distance between 2 nodes
        {
            return adjMatrix[vertex_u, vertex_v];
        }

        public void Display() //displays the adjacency matrix
        {
            Console.WriteLine("***********Adjacency Matrix Representation***********");
            Console.WriteLine("Number of nodes: {0}\n", graphSize - 1);
            foreach (Vertex v in Vertices)
            {
                Console.Write("{0}\t", v.Data);
            }
            Console.WriteLine();//newline for the graph display
            for (int i = 1; i < graphSize; i++)
            {
                Console.Write("{0}\t", Vertices[adjMatrix[i, 0]].Data);
                for (int j = 1; j < graphSize; j++)
                {
                    Console.Write("{0}\t", adjMatrix[i, j]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("Read the graph from left to right");
            Console.WriteLine("Example: Node A has an edge to Node C with distance: {0}",
                Length(1, 3));
        }

        private void DisplayNodeData(int v)//displays data/description for a node
        {
            Console.WriteLine(Vertices[v].Data);
        }
    }
}
