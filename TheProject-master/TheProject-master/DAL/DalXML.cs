using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    internal class DalXML : IDal
    {
        public bool addOrder(Order order)
        {
            return true;
        }
        public Order getOrder(int id)
        {
            return new Order
            {

            };
        }
    }
}
