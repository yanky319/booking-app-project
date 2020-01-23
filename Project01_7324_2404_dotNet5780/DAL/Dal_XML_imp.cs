//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;
//using BE;
//using DS;

//namespace DAL
//{
//    class Dal_XML_imp : Idal
//    {
//        static string path = @"..\..\..\DataSource\";
//        static string Orders = @"Orders.xml";
//        static string Request = @"Request.xml";
//        static string HostingUnits = @"HostingUnits.xml";
//        static string Hosts = @"Hosts.xml";
//        static string Configurations = @"Configurations.xml";
//        #region GuestRequest functions

//        void addGuestRequest(GuestRequest request);
//        void updateGuestRequest(int key, RequestStatus status);
//        IEnumerable<GuestRequest> getGuestRequests();

//        #endregion

//        #region HostingUnit functions

//        void addHostingUnit(HostingUnit unit);
//        void deleteHostingUnit(int unitKey);
//        void updateHostingUnit(HostingUnit unit);
//        IEnumerable<HostingUnit> getHostingUnits();

//        #endregion

//        #region Order functions
//        public void addOrder(Order order)
//        {
//            XElement Order_root;
//            if (File.Exists(path + Orders))
//            {
//                Order_root = XElement.Load(path + Orders);
//            }
//            else
//            {
//                Order_root = new XElement("Orders");
//                Order_root.Save(path + Orders);
//            }
//            order.OrderKey = ++Configuration.orderKey;
//            order.Status = OrderStatus.not_addressed;
//            order.CreateDate = DateTime.Now;
//            order.OrderDate = DateTime.MinValue;
//            Order_root.Add(new XElement("Order",
//                new XElement("HostingUnitKey", order.HostingUnitKey),
//                new XElement("HostID", order.HostID),
//                new XElement("GuestRequestKey", order.GuestRequestKey),
//                new XElement("OrderKey", order.OrderKey),
//                new XElement("Status", order.Status),
//                new XElement("CreateDate", order.CreateDate),
//                new XElement("OrderDate", order.OrderDate)));
//            Order_root.Save(path + Orders);
//        }
//        public void updateOrder(int key, OrderStatus status)
//        {
//            if (!File.Exists(path + Orders))
//            {
//                throw new TargetNotFoundException("DAL_");
//            }
//            XElement Order_root = XElement.Load(path + Orders);
//            XElement element = (from ord in Order_root.Elements()
//                                where int.Parse(ord.Element("OrderKey").Value) == key
//                                select ord).FirstOrDefault();
//            element.Element("Status").Value = status.ToString();
//            Order_root.Save(path + Orders);
//        }
//        public IEnumerable<Order> getOrders()
//        {
//            try
//            {
//                XElement Order_root = XElement.Load(path + Orders);
//                IEnumerable<Order> orders = (from ord in Order_root.Elements()
//                                             select new Order()
//                                             {
//                                                 HostingUnitKey = int.Parse(ord.Element("HostingUnitKey").Value),
//                                                 HostID = int.Parse(ord.Element("HostID").Value),
//                                                 GuestRequestKey = int.Parse(ord.Element("GuestRequestKey").Value),
//                                                 OrderKey = int.Parse(ord.Element("OrderKey").Value),
//                                                 Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), ord.Element("Status").Value),
//                                                 CreateDate = DateTime.Parse(ord.Element("CreateDate").Value),
//                                                 OrderDate = DateTime.Parse(ord.Element("OrderDate").Value),
//                                             });
//                return orders;
//            }
//            catch
//            {
//                throw new SourceNotFoundException("DAL_");
//            }
//        }

//        #endregion

//        #region Host functions

//        void addHost(Host host);
//        void deleteHost(int Key);
//        void updateHost(Host host);
//        IEnumerable<Host> getHosts();

//        #endregion

//        #region BankBranch functions

//        IEnumerable<BankBranch> getBankBranchs();

//        #endregion
//    }
//}
