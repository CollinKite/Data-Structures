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
            if(Data.CompareTo(val) > 0) //if the value we're adding is less than the current nodes value
            {
                if(Left != null)
                {
                    Left.Add(val);
                }
                else
                {
                    Left = new BinaryTreeNode<T>();
                    Left.Data = val;
                    Left.Count++;
                }
            }
            else if(Data.CompareTo(val) < 0) //if the value we're adding is greater than the current nodes value
            {
                if (Right != null) //If we have further child nodes keep traversing
                {
                    Right.Add(val);
                }
                else //Otherwise we're at the end and we need to add out value
                {
                    Right = new BinaryTreeNode<T>();
                    Right.Data = val;
                    Right.Count++;
                }
            }
            else
            {

            }
        }

        public int Count { get; set; } = 0; //for duplicate values we just increase/decrease the count of how many values exist in the node

        public int Height()
        {
            int size = 0;
            if(Left != null)
            {
                Height
            }
            return size;
        }

        public BinaryTreeNode<T> Remove(T val)
        {
            if(val.CompareTo(Data) < 0)
            {
                return Left = Left.Remove(val);
            }
            else if(val.CompareTo(Data) > 0) //comprareTo
            {
                return Right = Right.Remove(val);
            }
            else
            {
                if (Left == null)
                {
                    return Right;
                }
                else if (Right == null)
                {
                    return Left;
                }
                else
                {
                    T Data = FindLargestOnLeft(Left);
                    Left = Left.Remove(Data);
                    return this;
                }

            }   
        }

        public T FindLargestOnLeft(BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> Left = node.Left;
            while(Right != null)
            {
                Left = Left.Right;
            }
            return Left.Data;
        }
    }
}
