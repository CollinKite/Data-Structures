using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver.Data
{
    //sortcuts - "prop" make quick property, "ctor" constructor
    public class Vertex
    {
        public char Data { get; set; }
        public List<Edge> Connections { get; set; }
        public int Index { get; set; }
        public void AddConnection(Edge edge)
        {
            Connections.Add(edge);
        }
    }
}
