using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FItemRenamer
{
    public class Item
    {
        public string Name { get; set; }
        public long StartAddress { get; }
        public long EndAddress { get; }

        public Item(string name, long startIndex, long endAddress)
        {
            Name = name;
            StartAddress = startIndex;
            EndAddress = endAddress;
        }
    }
}
