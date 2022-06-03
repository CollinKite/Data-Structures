using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect.Data
{
    public class Node
    {
        public string Id { get; set; }
        public List<Edge> EdgeList { get; set; }

        public bool IsPartOfTree { get; set; }

        public Node(string id)
        {
            Id = id;
            EdgeList = new();
        }

        //public Edge FindEdgeByStartId(string startId)
        //{
        //    return EdgeList.First(e => e.StartId.Equals(startId));
        //}

        //public Edge FindEdgeByEndId(string startId)
        //{
        //    return EdgeList.First(e => e.StartId.Equals(startId));
        //}

        public bool AllNodesInEdgeListArePartOfTree()
        {
            bool AllInTree = true;
            for (int i = 0; i < EdgeList.Count; i++)
            {
                if(EdgeList[i].EndNode.IsPartOfTree == false)
                {
                    AllInTree = false;
                }
            }
            return AllInTree;
        }
    }
}
