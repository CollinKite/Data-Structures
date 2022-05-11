using System;
using System.Collections.Generic;

namespace CSC252
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            LinkedList<int> test = new();
            test.AddLast(5);
            Console.WriteLine("Here: " + test); 
        }
    }
}
