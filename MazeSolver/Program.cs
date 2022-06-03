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

            //string hardPath = @"C:\Users\tallen\source\repos\Algo\ThirdParty\TestMazes.txt"; 
            string path = Console.ReadLine();

            List<string> lines = new List<string>(File.ReadAllLines(path));

            GraphList graphList = new GraphList(lines);
            List<string> solutions = new List<string>(); 

            foreach (Graph graph in graphList.Graphs)
            {
                solutions = SolveMaze.UsingDijkstra(graph);
            }

            //Console.WriteLine(solutions);

            Console.WriteLine();
            Console.WriteLine("The file has been read. However, as I am a game student, I do not know how to do file manipulation very well since we never have to do that.\n");
            Console.WriteLine("I have chosen to prioritize my game physics final over trying to figure out the string manipulation stuff (because I also already know how dijkstra stuff works, but that can't be shown without the file reading stuff). ");

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
