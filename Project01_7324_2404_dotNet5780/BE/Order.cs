using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order
    {
        public int HostingUnitKey { get; private set; }
        public int GuestRequestKey { get; private set; }
        public int OrderKey { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime OrderDate { get; private set; }
        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}
