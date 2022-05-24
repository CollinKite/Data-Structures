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

        //Setup our mazes
        public GraphList(List<string> setupLines)
        {
            Graphs = new List<Graph>();
            SetupGraphs(setupLines);
        }

        private void SetupGraphs(List<string> setupLines)
        {

        }
    }
}
