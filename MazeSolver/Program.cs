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

            string hardPath = @"C:\Users\tallen\source\repos\Algo\ThirdParty\TestMazes.txt"; 
            //string path = Console.ReadLine();

            List<string> lines = new List<string>(File.ReadAllLines(hardPath));

            GraphList graphList = new GraphList(lines);
            List<string> solutions = new List<string>(); 

            foreach (Graph graph in graphList.Graphs)
            {
                solutions = SolveMaze.UsingDijkstra(graph);
            }

            Console.WriteLine(solutions);

            /*            Graph gr = new Graph();
                        GraphList gl = new GraphList();
                        gr.Display();
                        gr.RunDijkstra();
                        gl.InitGraph(@"C:\Users\tallen\source\repos\Algo\ThirdParty\TestMazes.txt");
                        gl.DisplayAdjList();
                        gl.Dfs();
                        Console.ReadLine();*/
        }
    }
}
