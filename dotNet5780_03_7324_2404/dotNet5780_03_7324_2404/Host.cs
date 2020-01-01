using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  public class Host 
///  Represents a host
/// </summary>
/// < parm name = HostName > the name of the host </parm>
/// < parm name = Units > list of the host's hosting units </parm>

namespace dotNet5780_03_7324_2404
{
    public class Host
    {
        public string HostName { get; set; }
        public List<HostingUnit> Units { get; set; }
    }
}
