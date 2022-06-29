using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect.Data
{
    public class Edge
    {
        public Edge(int weight, Node Start, Node End)
        {
            Weight = weight;
            StartNode = Start;
            EndNode = End;
        }

        public int Weight { get; set; }
        public Node StartNode { get; set; }
        public Node EndNode { get; set; }

    }
}
