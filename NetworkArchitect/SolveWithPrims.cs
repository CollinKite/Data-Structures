using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkArchitect.Data;

namespace NetworkArchitect
{
    public static class SolveWithPrims
    {
        public static Results Solve(Graph graph)
        {
            List<string> UsedNodes = new();
            Results result = new();
            //Choose a node - we just start with the first node in the graph
            Node vertex = graph.Nodes[0];
            UsedNodes.Add(vertex.Id);
            vertex.IsPartOfTree = true;
            (result.SocketSet, result.CableLength) = SolvePrims(vertex, UsedNodes, 0);
            //Return Result
            return result;
        }

        private static (List<string> SocketSet, int weight) SolvePrims(Node node, List<string> UsedNodes, int Weight)
        {
            //if all edges are marked as added we're done  
            if (node.AllNodesInEdgeListArePartOfTree())
            {
                return (UsedNodes, Weight);
            }
            //else find lowest weight and check if node is added and add it, and then call prims on it
            else
            {
                List<Edge> SortedEdgeList = node.EdgeList;
                    node.EdgeList.Sort(delegate(Edge x, Edge y)
                        {
                            return x.Weight.CompareTo(y.Weight);
                        }
                    ); 
                //Sort the EdgeList by the weights lowest to highest to make below loop easier
                for (int i = 0; i < node.EdgeList.Count; i++)
                {
                    if(!SortedEdgeList[i].EndNode.IsPartOfTree)
                    {
                        Weight += SortedEdgeList[i].Weight;
                        UsedNodes.Add(SortedEdgeList[i].EndNode.Id);
                        SortedEdgeList[i].EndNode.IsPartOfTree = true;
                        (UsedNodes, Weight) = SolvePrims(SortedEdgeList[i].EndNode, UsedNodes, Weight);
                    }
                }
                return (UsedNodes, Weight);
            }
            
        }
    }
}
