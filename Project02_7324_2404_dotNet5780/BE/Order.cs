using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order
    {
        public int HostingUnitKey { get; set; }
        public int HostID { get; set; }
        public int GuestRequestKey { get; set; }
        public int OrderKey { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime OrderDate { get; set; }

        public override string ToString()
        {
            return string.Format("HostingUnitKey: {0}\nHostKey: {1}\nGuestRequestKey: {2}\nOrderKey: {3}\nStatus: {4}\nCreateDate: {5}\nOrderDate: {6}"
                , HostingUnitKey, HostID, GuestRequestKey, OrderKey, Status, CreateDate.ToShortDateString(), OrderDate.ToShortDateString());
        }
    }
}
