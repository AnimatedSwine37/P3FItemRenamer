using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FItemRenamer
{
    class NameList
    {
        public NameFile[] NameFiles { get; set; }
    }

    class NameFile
    {
        public string File { get; set; }
        public long StartAddress { get; set; } 
    }
}
