using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Videos That Help
//https://www.youtube.com/watch?v=1QSYxIKXXP4&ab_channel=WilliamFiset
//https://www.youtube.com/watch?v=7m94k2Qhg68
namespace AlgoDataStructures.AVL
{
    public class AVLTreeNode<T> where T : IComparable<T>
    {

        public AVLTreeNode(){}
        public AVLTreeNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public AVLTreeNode<T> Left { get; set; }
        public AVLTreeNode<T> Right { get; set; }

        public int CheckBalance()
        {
            int LeftHeight = 0;
            int RightHeight = 0;
            if(Left != null)
            {
                LeftHeight = Left.Height();
            }
            if(Right != null)
            {
                RightHeight = Right.Height();
            }
            int bal = LeftHeight - RightHeight;
            return bal;
        }

        //Right Rotation
        private AVLTreeNode<T> RightRotation(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> NewRoot = node.Left;
            node.Left = NewRoot.Right;
            NewRoot.Right = node;
            return NewRoot;
        }

        //Left Rotation
        private AVLTreeNode<T> LeftRotation(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> newRoot = node.Right;
            node.Right = newRoot.Left;
            newRoot.Left = node;
            return newRoot;
        }

        public AVLTreeNode<T> Balance(AVLTreeNode<T> node)
        {
            int bal = node.CheckBalance();
            if (bal == 1 || bal == 0 || bal == -1)
            {
                return node;
            }
            else if (bal > 1) //Left Heavy
            {
                node.Left = LeftRightHeavyCheck(node.Left);
                node = RightRotation(node);
                return node;
            }
            else //right heavy
            {
                node.Right = RightLeftHeavyCheck(node.Right);
                node = LeftRotation(node);
                return node;
            }
        }

        //Check if Left Needs to be done before Right
        private AVLTreeNode<T> LeftRightHeavyCheck(AVLTreeNode<T> node)
        {
            if(node.CheckBalance() == -1)
            {
                node = LeftRotation(node);
            }
            return node;

        }

        //Check if Right Needs to be done before Left
        private AVLTreeNode<T> RightLeftHeavyCheck(AVLTreeNode<T> node)
        {
            if (node.CheckBalance() == 1)
            {
                node = RightRotation(node);
            }
            return node;
        }


        public AVLTreeNode<T> Add(T val)
        {
            if(Data.CompareTo(val) > 0) //if the value we're adding is less than the current nodes value
            {
                if(Left != null)
                {
                    Left = Left.Add(val);
                    return Balance(this);
                }
                else
                {
                    Left = new AVLTreeNode<T>();
                    Left.Data = val;
                    Left.Count++;
                    return Balance(this);
                }
            }
            else if(Data.CompareTo(val) < 0) //if the value we're adding is greater than the current nodes value
            {
                if (Right != null) //If we have further child nodes keep traversing till we hit null or same value
                {
                    Right = Right.Add(val);
                    return Balance(this);
                }
                else //Otherwise we're at the end and we need to add out value
                {
                    Right = new AVLTreeNode<T>();
                    Right.Data = val;
                    Right.Count++;
                    return Balance(this);
                }
            }
            else //value is the same as the current node and we need to increase the count
            {
                Count++;
                return this;
            }
            
            //check balance (left height - right height, if = 1,0,-1
            //if balanced and return this
            //other wise calculate if right heavy or left heavy and preform rotation(s)
            //Left - Right Heavy,
            //Right - Left Heavy,
            //Left Right - Left Heavy, but child node has right child so you preform a left rotate on the right child and return and then preform a Right Rotate,
            //Ex.
            //      [5]         [5]         [4]
            //      / \         / \         / \
            //     [3]         [4]        [3] [5]
            //       \         /  
            //       [4]     [3]
            
            //Right Left - same as above but opposite. Right Heavy and child node has a LEFT child

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
            if(Right != null)
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

        public AVLTreeNode<T> Remove(T val, int count = 1)
        {
            if (val.CompareTo(Data) < 0) //val is less than the data
            {
                Left = Left.Remove(val, count);
                return Balance(this);
            }
            else if (val.CompareTo(Data) > 0) //Val is greater than the data
            {
                Right = Right.Remove(val, count);
                return Balance(this);
            }
            //Reached our value 
                if (Count > count)
                {
                    Count =  Count - count;
                    return Balance(this);
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
                        return Balance(this);
                    }
                }
            
        }

        public (T, int) FindLargestOnLeft(AVLTreeNode<T> node) //Return touple because we have to copy up our count too
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

        public (T[], int) ToArray(int level, T[] Arr, int index)
        {
            //breadth First - print by levels - Left, Root, Right
            // ex.
            /*
             
            [11]
            /  \
          [10][24]
              /  \
            [13][56]

            would return: 11, 10, 24, 13, 56
                
             */

            if(level == 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    Arr[index] = Data;
                    index++;
                }
            }
            else
            {
                if(Left!= null)
                {
                    (Arr, index) = Left.ToArray((level - 1), Arr, index);
                }
                if(Right != null)
                {
                    (Arr, index) = Right.ToArray((level - 1), Arr, index);
                }
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
