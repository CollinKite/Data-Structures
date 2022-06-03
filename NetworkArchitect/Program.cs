using System;
using System.Collections.Generic;
using System.IO;
using NetworkArchitect.Data;
namespace NetworkArchitect
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to file: ");
            var path = Console.ReadLine();
            List<string> lines = new List<string>(File.ReadAllLines(path));
            Graph graph = new Graph(lines);

            Results primsResult = SolveWithPrims.Solve(graph);

            primsResult.PrintResults();
        }
    }
}
