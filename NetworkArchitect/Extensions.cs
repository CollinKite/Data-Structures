using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkArchitect.Data;
namespace NetworkArchitect
{
    public static class Extensions
    {
        public static void PrintResults(this Results results) //this represents object it's doing it off of
        {
            Console.WriteLine("Socket Set: " + String.Join(", ",results));
            Console.WriteLine("Cable Needed " + results.CableLenth + "ft");
        }
    }
}
