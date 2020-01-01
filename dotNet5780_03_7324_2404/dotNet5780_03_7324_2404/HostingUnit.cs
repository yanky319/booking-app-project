using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
///  public class HostingUnit 
///  Represents a Hosting Unit
/// </summary>
/// < parm name = UnitName > the name of the Unit Name </parm>
/// < parm name = Rooms > number of rooms in the unit </parm>
/// < parm name = IsSwimmimgPool > Boolean variable representing whether there is a pool or not  </parm>
/// < parm name = AllOrders > List of busy dates </parm>
/// < parm name = Uris > List of links to picturs of the unit </parm>
namespace dotNet5780_03_7324_2404
{
    public class HostingUnit
    {
        public string UnitName { get; set; }
        public int Rooms { get; set; }
        public bool IsSwimmimgPool { get; set; }
        public List<DateTime> AllOrders { get; set; }
        public List<string> Uris { get; set; }
    }
}
