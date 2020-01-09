using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DataSource;

namespace DAL
{
    class DalList : IDal
    {
        public bool addOrder(Order order)
        {
            if (DataSourceList.Orders.Any(mishehu => mishehu.OrderKey == order.OrderKey))
            {
                return false;
            }
            DataSourceList.Orders.Add(order.Clone());
            return true;
        }

        public Order getOrder(int id)
        {
            Order result = (from o in DataSourceList.Orders
                          where o.OrderKey == id
                          select o).FirstOrDefault();

            return result.Clone();
        }
    }
}
