using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures.LinkedList
{

    //Advantages
    public class SingleLinkedList<T> where T : IComparable<T> //Implement Icomparable to compare items. "where T" means that the object you compare it to also has to implement Icomparable
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
            while(getString.next != null)
            {
                if (getString.Data != null)
                {
                    Stuff += (string)(object)getString.Data + ", ";
                }
                getString = getString.next;
            }
            Stuff.TrimEnd(',');
            return Stuff;

        }

        public void Add(T item)
        {
            if(this.HeadOfList.next != null)
            {
                Node<T> EndNode = HeadOfList;
                while(EndNode.next != null )
                {
                    EndNode = EndNode.next;
                }
                //Reached end of nodes
                EndNode.next = new Node<T>(); //Fill Null with a new node
                EndNode = EndNode.next; //set the new node as our modifyable
                EndNode.Data = item; //put data in new node.
            }
            else
            {
                HeadOfList.Data = item;
            }
            Count++; //Increase Count of Total Nodes
        }

        public void Insert(T val, int index)
        {
            if(index >= Count || index < 0)
            {
                throw new ArgumentException("Index is out of range");
            }

            Node<T> insert = HeadOfList;
            int CurrentIndex = 0;
            while(CurrentIndex != index)
            {
                insert = insert.next;
            }
            Node<T> AfterInsert = insert;
            insert.Data = val;
            insert.next = AfterInsert;
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
            return HeadOfList.Data;
            //if(index >= 0)
            //{
            //    for (int i = 0; i < index; i++)
            //    {
                    
            //    }
            //}
        }

        public T Remove()
        {
            return HeadOfList.Data;
            //Remove First Value in list and return it
        }

        public T RemoveAt(int index)
        {
            return HeadOfList.Data;
            /*removes and returns the value at a given index. Any index less 
            than zero or equal to or greater than Count should throw an index out of bounds 
            exception.*/
        }

        public T RemoveLast()
        {
            return HeadOfList.Data;
            /* removes and returns the last value in the list*/
        }

        public void Clear()
        {
            // remove all values in the list
            HeadOfList = new Node<T>();
            Count = 0;
        }

        public int Search(T val)
        {
            return -1;
            /*searches for a value in the list and returns the first index of that value 
            when found. If the key is not found in the list, the method returns -1.*/
        }
    }

}
