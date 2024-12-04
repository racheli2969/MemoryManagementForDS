using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagementInDS
{
    internal class PointClass
    {

        public int x;
        public int y;

        public override string ToString() => $"({x}, {y})\n";
    }
}
