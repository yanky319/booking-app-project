using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HostingUnit
    {
        public int HostingUnitKey { get; private set; }
        public Host Owner { get; private set; }
        public string HostingUnitName { get; private set; }
        public bool[,] Diary { get; private set; }
        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}
