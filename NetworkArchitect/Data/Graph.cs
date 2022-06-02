using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetworkArchitect.Data
{
    public class Graph
    {
        public List<Node> Nodes { get; set; }

        public Graph(string[] setupLines)
        {
            //AX1,AX2,AX3,AX4,AX5
            //Add Nodes
            string[] Nodes = setupLines[0].Split(',');
            for (int i = 0; i < Nodes.Length; i++)
            {
                Node node = new(Nodes[i]);
                this.Nodes.Add(node);
            }
            //Add Edges
            //AX1,AX4: 3,AX2: 3,AX3: 6
            //AX2,AX1: 3,AX3: 3,AX4: 6
            //AX3,AX2: 3,AX1: 6,AX4: 41
            //AX4,AX1: 3,AX2: 6,AX3: 4,AX5: 15
            //AX5,AX4: 15
            for (int j = 1; j < setupLines.Length; j++)
            {
                string[] currentEdge = setupLines[j].Split(',');
                for (int Edge = 1; Edge < currentEdge.Length; Edge++)
                {
                    string StartId = currentEdge[0];
                    string EndId = currentEdge[Edge];
                    int weight;
                    Regex rx = new Regex(":[0-9]{1,3}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    MatchCollection matches = rx.Matches(EndId);
                }
            }
        }

        public Node FindNode(string id)
        {
            return Nodes.First(n => n.Id.Equals(id)); //gets all nodes and puts them into n and when the node id matches what was passed through, return it.
        }
    }
}
