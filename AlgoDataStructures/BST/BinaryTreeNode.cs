using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures.BST
{
    public class BinaryTreeNode<T> where T : IComparable<T>
    {

        public BinaryTreeNode(){}
        public BinaryTreeNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public void Add(T val)
        {

        }

        public int Count { get; set; } = 0; //for duplicate values we just increase/decrease the count of how many values exist in the node

        public int Height()
        {
            //Left Child: how tall?
            //Right Child How tall?
            //which is greater?
            //Add 1
            // return
            return 0;
        }
    }
}
