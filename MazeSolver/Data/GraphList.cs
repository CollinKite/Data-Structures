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
            if(setupLines.Count == 0)
            {
                return;
            }
            Graph graph = new();
            int mazeIndex = 0;
            for (int line = 0; line < setupLines.Count; line++)
            {
                //A,B,C,D,E,F
                if (mazeIndex == 0)
                {
                    string verticies = setupLines[line];
                    string[] data = verticies.Split(',');
                    for (int i = 0; i < data.Length; i++)
                    {
                        Vertex v = new Vertex(i, Char.Parse(data[i]));
                        graph.AddVertex(v);
                    }
                }

                else if (mazeIndex == 1)
                {
                    //A,E Start and End
                    string startandEnd = setupLines[line];
                    string[] sEList = startandEnd.Split(',');
                    graph.Start = graph.GetVertex(Char.Parse(sEList[0]));
                    graph.End = graph.GetVertex(Char.Parse(sEList[1]));
                }

                else if (setupLines[line].Equals(""))
                {
                    //New Graph
                    Graphs.Add(graph);
                    graph = new Graph();
                    mazeIndex = -1; //-1 because we increment it at the end and we want it to be 0
                }
                else if(setupLines[line].StartsWith("//"))
                {
                    //Ignore Comment
                }
                else
                {
                    //Edges
                    //B,A,C,D,F
                    string[] adjacencyList = setupLines[line].Split(',');
                    Vertex start = graph.GetVertex(char.Parse(adjacencyList[0])); //First is vertex and rest are edges
                    for (int i = 1; i < adjacencyList.Length; i++)
                    {
                        Vertex end = graph.GetVertex(char.Parse(adjacencyList[i]));
                        Edge e = new Edge(start, end);
                        start.AddConnection(e);
                    }
                }
                mazeIndex++;
            }
            Graphs.Add(graph);


        }
    }
}
