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

        public BinaryTreeNode<T> Remove(T val, int count = 1)
        {
            if (val.CompareTo(Data) < 0) //val is less than the data
            {
                Left = Left.Remove(val, count);
                return this;
            }
            else if (val.CompareTo(Data) > 0) //Val is greater than the data
            {
                Right = Right.Remove(val, count);
                return this;
            }
            //Reached our value 
                if (Count > count)
                {
                    Count =  Count - count;
                    return this;
                }
                else
                {
                    //if the node we're deleting has only one child or no children
                    if (Left == null)
                    {
                        return Right;
                    }
                    else if (Right == null)
                    {
                        return Left;
                    }
                    //If the node we're deleting has 2 children - find the  highest on the left side and copy it to our value we're deleting (don't forget count) and then delete the original copy
                    else
                    {
                        (T, int) DataToCopy = FindLargestOnLeft(Left);
                        Data = DataToCopy.Item1;
                        Count = DataToCopy.Item2;
                        Left = Left.Remove(Data, Count);
                        return this;
                    }
                }
            
        }

        public (T, int) FindLargestOnLeft(BinaryTreeNode<T> node) //Return touple because we have to copy up our count too
        {
            if(node.Right != null)
            {
                return FindLargestOnLeft(node.Right);
            }
            return (node.Data, node.Count);
        }

        public string InOrder()
        {
            string order = "";
            order = InOrder(order);
            order = order.TrimEnd();
            order = order.TrimEnd(',');
            return order;
        }
        public string InOrder(string Order)
        {
            if(Left != null)
            {
                Order = Left.InOrder(Order);
            }
            for (int i = 0; i < Count; i++)
            {
                Order += Data.ToString() + ", ";
            }
            if(Right != null)
            {
                Order = Right.InOrder(Order);
            }
            return Order;

        }

        public string PreOrder()
        {
            string order = "";
            order = PreOrder(order);
            order = order.TrimEnd();
            order = order.TrimEnd(',');
            return order;
        }

        public string PreOrder(string order)
        {
            for (int i = 0; i < Count; i++)
            {
                order += Data.ToString() + ", ";
            }
            if(Left != null)
            {
                order = Left.PreOrder(order);
            }
            if(Right != null)
            {
                order = Right.PreOrder(order);
            }
            return order;

        }

        public string PostOrder()
        {
            string order = "";
            order = PostOrder(order);
            order = order.TrimEnd();
            order = order.TrimEnd(',');
            return order;
        }
        public string PostOrder(string order)
        {
            if (Left != null)
            {
                order = Left.PostOrder(order);
            }
            if (Right != null)
            {
                order = Right.PostOrder(order);
            }
            for (int i = 0; i < Count; i++)
            {
                order += Data.ToString() + ", ";
            }
            return order;

        }

        public T[] ToArray(T[] arr)
        {
            T[] stuff = arr;
            return ToArray(stuff, 0).Item1;
        }

        public (T[], int) ToArray(T[] Arr, int index)
        {
            if (Left != null) //Traverse to left most node
            {
                (T[], int) DataStuff = Left.ToArray(Arr, index);
                Arr = DataStuff.Item1;
                index = DataStuff.Item2;
            }
            for (int i = 0; i < Count; i++)
            {
                Arr[index] = Data;
                index++;
            }
            if(Right != null)
            {
                (T[], int) DataStuff = Right.ToArray(Arr, index);
                Arr = DataStuff.Item1;
                index = DataStuff.Item2;
            }
            return (Arr, index);
   

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
