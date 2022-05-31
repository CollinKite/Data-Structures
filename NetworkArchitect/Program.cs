using System;
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

            Graph graph = new Graph(File.ReadAllLines(path));

            Results primsResult = SolveWithPrims.Solve(graph);

            primsResult.PrintResults();
        }
    }
}
