using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect.Data
{
    public class Edge
    {
        public Edge(int weight, string startId, string endId)
        {
            Weight = weight;
            StartId = startId;
            EndId = endId;
        }

        public int Weight { get; set; }
        public string StartId { get; set; }
        public string EndId { get; set; }

    }
}
