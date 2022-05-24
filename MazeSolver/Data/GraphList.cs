using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver.Data
{
    public class GraphList
    {
        public List<Graph> Graphs { get; set; }

        public GraphList(List<string> setupLines)
        {
            Graphs = new List<Graph>();
            SetupGraphs(setupLines); 
        }

        private void SetupGraphs(List<string> setupLines)
        {
            // first line is all of the vertices 
            // following lines are connections 
            // ignore lines that start with // 
            // if there's an empty line, that graph is done and start a new one with the next line 
        }
    }
}
