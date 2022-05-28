using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeSolver.Data;
namespace MazeSolver
{
    public static class SolveMaze
    {
        public static List<string> UsingDijkstra(Graph graph)
        {
            List<DNode> dijkstraNodes = SetupDijkstra(graph);
            FillInDijkstraChart(dijkstraNodes);
            return new List<string> { findDijkstraSolution(dijkstraNodes, graph) };
        
        }

        private static string findDijkstraSolution(List<DNode> dijkstraNodes, Graph graph)
        {
            DNode end = dijkstraNodes.First(d => d.Node == graph.End);
            StringBuilder builder = new StringBuilder(); //Memory Effiect than concatnation - makes it an object. Better because strings are inmutable
            while(end.Previous != null)
            {
                builder.Insert(0, " " + end.Node.Data);
                end = dijkstraNodes.First(d => d.Node == end.Previous);
            }
            builder.Insert(0, end.Node.Data);
            string solution = builder.ToString();
            if (solution.Contains(graph.Start.Data))
            {
                return solution;
            }
            return "No Solution";
        }

        private static void FillInDijkstraChart(List<DNode> dijkstraNodes)
        {
            while (dijkstraNodes.Any(d => !d.IsVisited))
            {
                DNode lowestDistance = dijkstraNodes.Where(n => !n.IsVisited).OrderBy(n => n.Distance).First();
                lowestDistance.IsVisited = true;

                foreach (Edge e in lowestDistance.Node.Connections)
                {
                    DNode found = dijkstraNodes.First(d => d.Node == e.End);
                    if (!found.IsVisited)
                    {
                        int distance = lowestDistance.Distance + e.Weight;
                        if (found.Distance > distance)
                        {
                            found.Distance = distance;
                            found.Previous = lowestDistance.Node;
                        }
                    }
                }
            }
        }
        private static List<DNode> SetupDijkstra(Graph graph)
        {
            List<DNode> dijkstraNodes = new(); //Chart of nodes
            //List nodes and create chart
            for (int i = 0; i < graph.nodes.Count; i++)
            {
                Vertex thisOne = graph.nodes[i];
                int Distance = thisOne == graph.Start ? 0 : Int32.MaxValue;
                DNode node = new DNode(thisOne, Distance);
                dijkstraNodes.Add(node);
            }
            return dijkstraNodes;
        }
        
    }
}
