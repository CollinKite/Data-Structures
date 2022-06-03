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
            (result.SocketSet, result.CableLength) = SolvePrims( graph, UsedNodes);
            //Return Result
            return result;
        }

        private static (List<string> SocketSet, int weight) SolvePrims(Graph graph, List<string> UsedNodes)
        {
            int weight = 0;
            //Choose a node - we just start with the first node in the graph
            Node vertex = graph.Nodes[0];
            UsedNodes.Add(vertex.Id);
            vertex.IsPartOfTree = true;
            //Get all edges
            List<Edge> AllEdges = vertex.EdgeList;
            //Sort the edges from lowest to highest weights
            while(!graph.CheckIfAllNodesAreAdded())
            {
                AllEdges.Sort(delegate (Edge x, Edge y)
                {
                    return x.Weight.CompareTo(y.Weight);
                }
                );
                //Get the lowest weight edge while they exist
                if (AllEdges[0] != null)
                {
                    if (!UsedNodes.Contains(AllEdges[0].EndNode.Id))
                    {
                        ///Add Id, Weight, and set bool to true
                        UsedNodes.Add(AllEdges[0].EndNode.Id);
                        weight += AllEdges[0].Weight;
                        AllEdges[0].EndNode.IsPartOfTree = true;
                        //Add All 
                        for (int i = 0; i < AllEdges[0].EndNode.EdgeList.Count; i++)
                        {
                            if (!UsedNodes.Contains(AllEdges[0].EndNode.EdgeList[i].EndNode.Id))
                            {
                                AllEdges.Add(AllEdges[0].EndNode.EdgeList[i]);
                            }
                        }
                        //delete Used Edge
                        AllEdges.RemoveAt(0);
                    }
                    else
                    {
                        //Delete repeating edges from First Node
                        AllEdges.RemoveAt(0);
                    }
                   
                }
            }
            return (UsedNodes, weight);
        }
    }
}
