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

        public Graph(List<string> setupLines)
        {
            Nodes = new();
            SetupGraph(setupLines);
        }

        private void SetupGraph(List<string> setupLines)
        {
            if(setupLines.Count == 0)
            {
                Console.WriteLine("Error Empty Graph");
                return;
            }
            
            for (int i = 0; i < setupLines.Count; i++)
            {
                
                if (i == 0)
                {
                    //AX1,AX2,AX3,AX4,AX5
                    //Add Nodes
                   string[] nodes = setupLines[i].Split(',');
                    for (int j = 0; j < nodes.Length; j++)
                    {
                        Node node = new(nodes[j]);
                        this.Nodes.Add(node);
                    }
                }
                else
                {
                    //AX4,AX1: 3,AX2: 6,AX3: 4,AX5: 15
                    string[] edges = setupLines[i].Split(',');
                    string StartId = edges[0];
                    Node currentNode = FindNode(StartId);
                    for (int EndEdge = 1; EndEdge < edges.Length; EndEdge++)
                    {
                        string[] EndNodeAndWeight = edges[EndEdge].Split(':');
                        string EndId = EndNodeAndWeight[0];
                        int weight = int.Parse(EndNodeAndWeight[1]);
                        Edge edge = new(weight, FindNode(StartId), FindNode(EndId));
                        currentNode.EdgeList.Add(edge);
                    }

                }

            }

            

        }

        public Node FindNode(string id)
        {
            return Nodes.First(n => n.Id.Equals(id)); //gets all nodes and puts them into n and when the node id matches what was passed through, return it.
        }

        public List<string> GetAllNodeIDs()
        {
            List<string> ids = new();
            for (int i = 0; i < Nodes.Count; i++)
            {
                ids.Add(Nodes[i].Id);
            }
            return ids;
        }
    }
}
