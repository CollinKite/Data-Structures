using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures.AVL
{
    public class AVLTree<T> where T : IComparable<T>
    {
        public AVLTreeNode<T> Root { get; set; }

        public int Count { get; set; } = 0;

        public void Add(T val)
        {
            if (Root == null)
            {
                Root = new AVLTreeNode<T>(val);
                Root.Count++;
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
            return Root != null ? Root.Height() : 0;
        }

        public void Remove(T val)
        {
            if (Root != null && Contains(val))
            {
                Root = Root.Remove(val);
                Count--;
            }
        }

        public bool Contains(T val)
        {
            if(Root != null)
            {
                return Root.Contains(val);
            }
            return false;
        }

        public string InOrder()
        {
            if (Root != null)
            {
                return Root.InOrder();
            }
            else
            {
                return "";
            }
        }

        public T[] ToArray()
        {
            if(Root != null)
            {
                T[] Arr = new T[Count];
                int index = 0;
                for (int i = 0; i <= Root.Height(); i++)
                {
                    (Arr, index) = Root.ToArray(i, Arr, index); 
                }
                return Arr;
            }
            else
            {
                return new T[0];
            }
        }

        public string PostOrder()
        {
            if (Root != null)
            {
                return Root.PostOrder();
            }
            else
            {
                return "";
            }

        }

        public string PreOrder()
        {
            if (Root != null)
            {
                return Root.PreOrder();
            }
            else
            {
                return "";
            }

        }
    }
}

   
