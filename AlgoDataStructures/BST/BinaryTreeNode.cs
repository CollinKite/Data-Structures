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
                if (Right != null) //If we have further child nodes keep traversing till we hit null or same value
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
            else //value is the same as the current node and we need to increase the count
            {
                Count++;
            }
        }

        public int Count { get; set; } = 0; //for duplicate values we just increase/decrease the count of how many values exist in the node

        public int Height()
        {
            int LeftSize = 0;
            int RightSize = 0;
            if(Left != null)
            {
                LeftSize += Left.Height();
            }
            else if(Right != null)
            {
                RightSize += Right.Height();
            }
            if(LeftSize >= RightSize) //made sure to add check if they're the same
            {
                return LeftSize + 1; // add 1 to include root
            }
            else
            {
                return RightSize + 1;
            }
        }

        public BinaryTreeNode<T> Remove(T val)
        {
            if(val.CompareTo(Data) < 0) //val is less than the data
            {
                return Left = Left.Remove(val);
            }
            else if(val.CompareTo(Data) > 0) //Val is greater than the data
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

        public string InOrder(string Order)
        {
            if(Left != null)
            {
                Order += Left.InOrder(Order);
            }
            Order += Data.ToString();
            if(Right != null)
            {
                Order += Right.InOrder(Order);
            }
            return Order;

        }

        public string PostOrder()
        {
            return "";
        }

        public string PreOrder()
        {
            return "";

        }

        public T[] ToArray(T[] Arr, int index)
        {
            if(Left != null)
            {
                Arr = Left.ToArray(Arr, index);
            } //Traverse until we hit our 0th Value
            for (int i = 0; i < Count; i++)
            {
                Arr[index] = Data;
                index++;
            } // Add the value * the count

        }
        public bool Contains(T value)
        {
            if (Data.Equals(value))
            {
                return true;
            }
            else if (value.CompareTo(Data) > 0 && Right != null)  //Greater than current node and we can keep traversing
            {
                return Right.Contains(value);
            }
            else if (value.CompareTo(Data) < 0 && Left != null) //Less than current node and we can keep traversing
            {
                return Left.Contains(value);
            }
            return false;
        }
    }
}
