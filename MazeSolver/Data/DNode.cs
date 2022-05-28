using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver.Data
{
    public class DNode
    {
        public DNode(Vertex node, int distance)
        {
            Node = node;
            Distance = distance;
        }

        public Vertex Node { get; set; }
        public int Distance { get; set; }
        public Vertex Previous { get; set; }
        public bool IsVisited { get; set; }
    }
}
