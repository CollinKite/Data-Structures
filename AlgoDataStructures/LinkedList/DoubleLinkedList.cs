using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures.LinkedList
{
    public class DoubleLinkedList<T> where T : IComparable<T> //T is just generic, you can use any char
    {
        public Node<T> HeadOfList { get; set; } = new();

        public int Count { get; set; } = 0;

        public override string ToString()
        {
            /*an override method that creates and returns a string representation of all the 
            values in the list. The string must be in the format of “v0, v1, v2, .., vn-1” where n-1 is the 
            last index in the list. An empty list should return an empty string (but not null). While 
            every value in the string is separated by a comma and space, the string must NOT have 
            any unnecessary commas or spaces at the beginning or end.*/
            Node<T> getString = HeadOfList;
            string Stuff = "";
            for (int i = 0; i < Count - 1; i++) //Iterate everything before the last node and contcatnate with seperator
            {
                Stuff += getString.Data.ToString() + ", ";
                getString = getString.next;
            }
            if (getString != null) //if not empty list
            {
                Stuff += getString.Data.ToString(); //Concatnate our final item without a seperator.
            }
            if (Count == 0) //Stops us from returning "0" for empty int linked lists
            {
                return "";
            }
            return Stuff;

        }

        public void Add(T item)
        {
            if (Count != 0) //Check and see if the head has been filled yet
            {
                Node<T> EndNode = HeadOfList;
                while (EndNode.next != null)
                {
                    EndNode = EndNode.next;
                }
                //Reached end of nodes
                EndNode.next = new Node<T>(); //Fill Null with a new node
                EndNode.next.Data = item; //put data in new node.
                EndNode.next.previous = EndNode;
            }
            else
            {
                HeadOfList.Data = item;
            }
            Count++; //Increase Count of Total Nodes
        }

        public void Insert(T val, int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("Out-of-bounds index was allowed");
            }

            Node<T> insert = HeadOfList;
            int CurrentIndex = 0;
            while (CurrentIndex != index)
            {
                insert = insert.next;
                CurrentIndex++;
            }
            Node<T> AfterInsert = new();
            AfterInsert.Data = insert.Data;
            AfterInsert.next = insert.next;
            insert.Data = val;
            insert.next = AfterInsert;
            insert.next.previous = insert;
            Count++;

            /* inserts a new value at a given index, pushing the existing value 
            at that index to the next index spot, and so on. Insert may ONLY target indices that are 
            currently in use. In other words, if you have 5 elements in your list, you may insert at 
            any index between 0 and 4 inclusive. Index 5 would be considered out of bounds as it is 
            not currently in use during the insertion process. Any index less than zero or equal to or 
            greater than Count should throw an index out of bounds exception.*/

        }

        public T Get(int index)
        {
            /*returns the value at the given index. Any index less than zero or equal to 
            or greater than Count should throw an index out of bounds exception.*/
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("Out-of-bounds index was allowed");
            }

            Node<T> current = HeadOfList;
            int CurrentIndex = 0;
            while (CurrentIndex != index)
            {
                current = current.next;
                CurrentIndex++;
            }
            return current.Data;
        }

        public T Remove()
        {
            T value = HeadOfList.Data;
            if (HeadOfList.next != null)
            {
                HeadOfList = HeadOfList.next;
                HeadOfList.previous = null;
            }
            else
            {
                HeadOfList = null;
            }
            Count--;
            return value;
            //Remove First Value in list and return it
        }

        public T RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("Out-of-bounds index was allowed");
            }
            if (index == 0) //Remove the head
            {
                T value = HeadOfList.Data;
                HeadOfList = HeadOfList.next;
                HeadOfList.previous = null;
                Count--;
                return value;
            }
            else
            {
                Node<T> Remove = HeadOfList;
                int CurrentIndex = 1; //set to -1 so we can update the .Next for the previous node.
                while (CurrentIndex != index)
                {
                    Remove = Remove.next;
                    CurrentIndex++;
                }
                //if the removed item has node(s), we need to keep it! otherwise it's already null
                T value = Remove.next.Data;
                if (Remove.next.next != null)
                {
                    Remove.next = Remove.next.next;
                    Remove.next.previous = Remove;
                }
                Count--;
                return value;
            }

            /*removes and returns the value at a given index. Any index less 
            than zero or equal to or greater than Count should throw an index out of bounds 
            exception.*/
        }

        public T RemoveLast()
        {
            if (HeadOfList.next == null)
            {
                T value = default(T);
                value = HeadOfList.Data;
                HeadOfList = null;
                Count--;
                return value;
            }
            else
            {
                Node<T> Traverse = HeadOfList;
                while (Traverse.next.next != null) //we want to reach the node before the one we delete and null the next
                {
                    Traverse = Traverse.next;
                }
                T value = default(T);
                value = Traverse.next.Data;
                Traverse.next = null;
                Count--;
                return value;
            }

            /* removes and returns the last value in the list*/
        }

        public void Clear()
        {
            // remove all values in the list
            HeadOfList = null;
            Count = 0;
        }

        public int Search(T val)
        {
            bool NotFound = true;
            int index = 0;
            Node<T> Traverse = HeadOfList;
            while (NotFound && Traverse != null)
            {
                if (Traverse.Data.Equals(val))
                {
                    NotFound = false;
                    break;
                }
                Traverse = Traverse.next;
                index++;
            }
            if (NotFound)
            {
                return -1;
            }
            else
            {
                return index;
            }
            /*searches for a value in the list and returns the first index of that value 
            when found. If the key is not found in the list, the method returns -1.*/
        }
    }
}
