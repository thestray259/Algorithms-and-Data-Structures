using System;
using System.Collections.Generic; 
using System.IO;
using MazeSolver.Data; 

namespace MazeSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file path:");

            //string hardPath = "C:\Users\tallen\source\repos\Algo\ThirdParty\TestMazes.txt"; 
            string path = Console.ReadLine();

            List<string> lines = new List<string>(File.ReadAllLines(path));

            GraphList graphList = new GraphList(lines); 

            foreach (Graph graph in graphList.Graphs)
            {
                List<string> solutions = SolveMaze.UsingDijkstra(graph); 
            }
        }
    }
}
