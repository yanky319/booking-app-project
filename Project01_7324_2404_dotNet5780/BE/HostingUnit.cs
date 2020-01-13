using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HostingUnit
    {
        public int HostingUnitKey { get; set; }
        public int HostKey { get; set; }
        public string HostingUnitName { get; set; }
        public bool[,] Diary { get; set; }
        public Areas Area { get; set; }
        public SubAreas SubArea { get; set; }
        public Types Type { get; set; }
        public int num_beds { get; set; }
        public bool Pool { get; set; }
        public bool Jacuzzi { get; set; }
        public bool Garden { get; set; }
        public bool ChildrensAttractions { get; set; }
        public bool wifi { get; set; }
        public bool accessibility { get; set; }

        public override string ToString()
        {
            return string.Format("HostingUnitKey: {0}\nHostKey: {1}\nHostingUnitName: {2}" +
                "nArea: {3}\nSubArea: {4}\nType: {5}\n ---more information---\n pool:{6}  lacuzzi:{7}  Garden:{8}\n" +
                "ChildrensAttractions:{9}  wifi:{10}  accessibility:{11}"
                , HostingUnitKey, HostKey, HostingUnitName, Area, SubArea, Type, Pool, Jacuzzi,
                Garden, ChildrensAttractions, wifi, accessibility);
        }
    }
}
