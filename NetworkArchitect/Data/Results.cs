using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect.Data
{
   public class Results
    {
        public List<string> SocketSet { get; set; } = new();//Node Ids
        public int CableLenth { get; set; }
    }
}
