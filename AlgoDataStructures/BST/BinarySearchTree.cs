using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures.BST
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> Root { get; set; }

        public int Count { get; set; } = 0;

        public void Add(T val)
        {
            if(Root == null)
            {
                Root = new BinaryTreeNode<T>(val);
            }
            else
            {
                Root.Add(val);
            }
            Count++;
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public int Height()
        {
            return Root != null? 0 : Root.Height();
        }

        public void Remove(T val)
        {
            if(Root!= null && Contains(val))
            {
                Root = Root.Remove(val);
                Count--;
            }
        }

        public bool Contains(T val)
        {
            return false;
        }

        public string InOrder()
        {
            return "";
        }
    }

    
}
