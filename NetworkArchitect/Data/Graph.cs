using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect.Data
{
    public class Graph
    {
        public List<Node> Nodes { get; set; }

        public Graph(string[] setupLines)
        {
            Nodes = new();
            //setup graph
        }

        public Node FindNode(string id)
        {
            return Nodes.First(n => n.Id.Equals(id)); //gets all nodes and puts them into n and when the node id matches what was passed through, return it.
        }
    }
}
