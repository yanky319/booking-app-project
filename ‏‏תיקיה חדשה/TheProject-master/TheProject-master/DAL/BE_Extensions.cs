using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;

namespace DAL
{
    public static class BE_Extensions
    {
        public static Order Clone(this Order order)
        {
            return new Order
            {
                OrderKey = order.OrderKey,
                Status = order.Status,
                CreateDate = order.CreateDate,
                GuestRequestKey = order.GuestRequestKey,
                HostingUnitKey = order.HostingUnitKey,
                OrderDate = order.OrderDate
            };
        }
        public static XElement ToXML(this Order d)
        {
            return new XElement("Order",
                                 new XElement("OrderKey", d.OrderKey.ToString()),
                                 new XElement("HostingUnitKey", d.HostingUnitKey.ToString()),
                                 new XElement("GuestRequestKey", d.GuestRequestKey.ToString()),
                                 new XElement("CreateDate", d.CreateDate.ToString()),
                                 new XElement("OrderDate", d.OrderDate.ToString()),
                                 new XElement("Status", d.Status.ToString())
                                  );
        }

        public static XElement ToXML(this BattlePlayer b)
        {
            return new XElement("BattlePlayer",
                                 new XElement("Name", b.Name.ToString()),
                                 new XElement("Board",
                                        (from v in b.Board.ToString()
                                             select v).ToArray(),
                                        (from v in b.OpponentBoard.ToString()
                                             select v).ToArray()
                                     )
                                 );
        }

    }
}