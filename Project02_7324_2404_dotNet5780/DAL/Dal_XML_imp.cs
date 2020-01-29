using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;
using DS;

namespace DAL
{
    class Dal_XML_imp : Idal
    {
        static string path = @"..\..\..\DataSource\";
        static string Orders = @"Orders.xml";
        static string GuestRequestFileName = @"Request.xml";
        static string HostingUnitsFileName = @"HostingUnits.xml";
        static string HostsFileName = @"Hosts.xml";
        static string Configurations = @"Configurations.xml";
        static string BanksFileName = @"Banks.xml";

        public static void SaveToXML<T>(T source, string fileName)
        {
            FileStream file = new FileStream(path + fileName, FileMode.OpenOrCreate);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source);
            file.Close();
        }

        public static T LoadFromXML<T>(string fileName) where T : new()
        {
            if (File.Exists(path + fileName))
            {
                FileStream file = new FileStream(path + fileName, FileMode.OpenOrCreate);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                T result = (T)xmlSerializer.Deserialize(file);
                file.Close();
                return result;
            }
            else
            {
                FileStream file = new FileStream(path + fileName, FileMode.OpenOrCreate);
                file.Close();
                return new T();
            }
        }

        #region GuestRequest functions

        public void addGuestRequest(GuestRequest request)
        {
            try
            {
                List<GuestRequest> Requests = LoadFromXML<List<GuestRequest>>(GuestRequestFileName);
                if (!File.Exists(path + GuestRequestFileName))
                    throw new TargetNotFoundException("DAL_");
                request.GuestRequestKey = Configuration.GuestRequestKey;
                Requests.Add(request);
                SaveToXML(Requests, GuestRequestFileName);
            }
            catch
            {
                throw new TargetNotFoundException("DAL_");
            }
        }
        public void deleteGuestRequest(int key)
        {
            try
            {
                if (!File.Exists(path + GuestRequestFileName))
                    throw new SourceNotFoundException("DAL_");

                List<GuestRequest> Requests = LoadFromXML<List<GuestRequest>>(GuestRequestFileName);
                int index = Requests.FindIndex(e => e.GuestRequestKey == key);
                if (index == -1)
                    throw new KeyNotFoundException("DAL_ERROR, Guest Request with this key does not exist");
                Requests.RemoveAt(index);
                SaveToXML(Requests, GuestRequestFileName);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("DAL_ERROR, Guest Request with this key does not exist");
            }
            catch
            {
                throw new SourceNotFoundException("DAL_");
            }
        }
        public void updateGuestRequest(int key, RequestStatus status)
        {
            try
            {
                if (!File.Exists(path + GuestRequestFileName))
                    throw new SourceNotFoundException("DAL_");

                List<GuestRequest> Requests = LoadFromXML<List<GuestRequest>>(GuestRequestFileName);
                int index = Requests.FindIndex(e => e.GuestRequestKey == key);
                if (index == -1)
                    throw new KeyNotFoundException("DAL_ERROR, Guest Request with this key does not exist");
                Requests.ElementAt(index).Status = status;
                SaveToXML(Requests, GuestRequestFileName);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("DAL_ERROR, Guest Request with this key does not exist");
            }
            catch
            {
                throw new SourceNotFoundException("DAL_");
            }
        }
        public IEnumerable<GuestRequest> getGuestRequests()
        {
            if (!File.Exists(path + GuestRequestFileName))
                throw new SourceNotFoundException("DAL_");
            try
            {
                return LoadFromXML<List<GuestRequest>>(GuestRequestFileName);
            }
            catch (Exception)
            {

                throw new SourceNotFoundException("DAL_");
            }
        }

        #endregion


        #region HostingUnit functions

        public void addHostingUnit(HostingUnit unit)
        {
            try
            {
                List<HostingUnit> Units = LoadFromXML<List<HostingUnit>>(HostingUnitsFileName);
                if (!File.Exists(path + HostingUnitsFileName))
                    throw new TargetNotFoundException("DAL_");
                List<Host> hosts = LoadFromXML<List<Host>>(HostsFileName);
                hosts.Find(i => i.HostID == unit.HostID).numUnits++;
                SaveToXML(hosts, HostsFileName);
                Units.Add(unit);
                SaveToXML(Units, HostingUnitsFileName);
            }
            catch
            {

                throw new TargetNotFoundException("DAL_");
            }
        }
        public void deleteHostingUnit(int unitKey)
        {
            try
            {
                if (!File.Exists(path + HostingUnitsFileName))
                    throw new SourceNotFoundException("DAL_");

                List<HostingUnit> Units = LoadFromXML<List<HostingUnit>>(HostingUnitsFileName);
                int index = Units.FindIndex(i=>i.HostingUnitKey == unitKey);
                if (index == -1)
                    throw new KeyNotFoundException("DAL_ERROR, Hosting unit with this key does not exist");
                List<Host> hosts = LoadFromXML<List<Host>>(HostsFileName);
               var a = hosts.Find(e => e.HostID == Units.Find(i => i.HostingUnitKey == unitKey).HostID).numUnits--;
                SaveToXML(hosts, HostsFileName);
                Units.RemoveAt(index);
                SaveToXML(Units, HostingUnitsFileName);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("DAL_ERROR, Hosting unit with this key does not exist");
            }
            catch
            {
                throw new SourceNotFoundException("DAL_");
            }
        }
        public void updateHostingUnit(HostingUnit unit)
        {
            try
            {
                deleteHostingUnit(unit.HostingUnitKey);
                addHostingUnit(unit);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("DAL_ERROR, Hosting unit with this key does not exist");
            }
            catch
            {
                throw new TargetNotFoundException("DAL_");
            }
        }
        public IEnumerable<HostingUnit> getHostingUnits()
        {
            if (!File.Exists(path + HostingUnitsFileName))
                throw new SourceNotFoundException("DAL_");
            try
            {
                return LoadFromXML<List<HostingUnit>>(HostingUnitsFileName);
            }
            catch
            {

                throw new SourceNotFoundException("DAL_");
            }
        }

        #endregion

        #region Order functions
        public void addOrder(Order order)
        {
            XElement Order_root;
            if (File.Exists(path + Orders))
            {
                Order_root = XElement.Load(path + Orders);
            }
            else
            {
                Order_root = new XElement("Orders");
                Order_root.Save(path + Orders);
            }
            order.OrderKey = Configuration.orderKey;
            order.Status = OrderStatus.not_addressed;
            order.CreateDate = DateTime.Today;
            order.OrderDate = DateTime.MinValue;
            Order_root.Add(new XElement("Order",
                new XElement("HostingUnitKey", order.HostingUnitKey),
                new XElement("HostID", order.HostID),
                new XElement("GuestRequestKey", order.GuestRequestKey),
                new XElement("OrderKey", order.OrderKey),
                new XElement("Status", order.Status),
                new XElement("CreateDate", order.CreateDate),
                new XElement("OrderDate", order.OrderDate)));
            Order_root.Save(path + Orders);
        }
        public void updateOrder(int key, OrderStatus status)
        {
            if (!File.Exists(path + Orders))
                throw new TargetNotFoundException("DAL_");

            try
            {
                XElement Order_root = XElement.Load(path + Orders);
                XElement element = (from ord in Order_root.Elements()
                                    where int.Parse(ord.Element("OrderKey").Value) == key
                                    select ord).FirstOrDefault();
                element.Element("Status").Value = status.ToString();
                Order_root.Save(path + Orders);
            }
            catch
            {
                throw new TargetNotFoundException("DAL_");
            }
        }
        public void delteOrder(int key)
        {
            if (!File.Exists(path + Orders))
                throw new TargetNotFoundException("DAL_");

            try
            {
                XElement Order_root = XElement.Load(path + Orders);
                XElement element = (from ord in Order_root.Elements()
                                    where int.Parse(ord.Element("OrderKey").Value) == key
                                    select ord).FirstOrDefault();
                element.Remove();
                Order_root.Save(path + Orders);
            }
            catch
            {

                throw new TargetNotFoundException("DAL_");
            }
        }
        public IEnumerable<Order> getOrders()
        {
            try
            {
                XElement Order_root = XElement.Load(path + Orders);
                IEnumerable<Order> orders = (from ord in Order_root.Elements()
                                             select new Order()
                                             {
                                                 HostingUnitKey = int.Parse(ord.Element("HostingUnitKey").Value),
                                                 HostID = int.Parse(ord.Element("HostID").Value),
                                                 GuestRequestKey = int.Parse(ord.Element("GuestRequestKey").Value),
                                                 OrderKey = int.Parse(ord.Element("OrderKey").Value),
                                                 Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), ord.Element("Status").Value),
                                                 CreateDate = DateTime.Parse(ord.Element("CreateDate").Value),
                                                 OrderDate = DateTime.Parse(ord.Element("OrderDate").Value),
                                             });
                return orders;
            }
            catch
            {
                throw new SourceNotFoundException("DAL_");
            }
        }

        #endregion

        #region Host functions

        public void addHost(Host host)
        {
            try
            {
                List<Host> hosts = LoadFromXML<List<Host>>(HostsFileName);
                if (!File.Exists(path + HostsFileName))
                    throw new TargetNotFoundException("DAL_");
                host.numOrders = 0;
                host.numUnits = 0;
                hosts.Add(host);
                SaveToXML(hosts, HostsFileName);
            }
            catch
            {

                throw new TargetNotFoundException("DAL_");
            }
        }
        public void deleteHost(int ID)
        {
            try
            {
                if (!File.Exists(path + HostsFileName))
                    throw new SourceNotFoundException("DAL_");

                List<Host> hosts = LoadFromXML<List<Host>>(HostsFileName);
                int index = hosts.FindIndex(e => e.HostID == ID);
                if (index == -1)
                    throw new KeyNotFoundException("DAL_ERROR, Host with this ID does not exist");
                hosts.RemoveAt(index);
                SaveToXML(hosts, HostsFileName);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("DAL_ERROR, Host with this ID does not exist");
            }
            catch
            {
                throw new SourceNotFoundException("DAL_");
            }
        }
        public void updateHost(Host host)
        {
            try
            {
                deleteHost(host.HostID);
                addHost(host);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("DAL_ERROR,Host with this key does not exist");
            }
            catch
            {
                throw new TargetNotFoundException("DAL_");
            }
        }
        public IEnumerable<Host> getHosts()
        {
            if (!File.Exists(path + HostsFileName))
                throw new SourceNotFoundException("DAL_");
            try
            {
                return LoadFromXML<List<Host>>(HostsFileName);
            }
            catch
            {

                throw new SourceNotFoundException("DAL_");
            }
        }

        #endregion

        #region BankBranch functions

        public IEnumerable<BankBranch> getBankBranchs()
        {
            return null;
            //WebClient client = new WebClient();
            //try
            //{
            //    //client.DownloadFile(@"https://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/snifim_dnld_he.xml", path + BanksFileName);

            //    client.DownloadFile(@"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml", path + BanksFileName);
            //}
            //catch
            //{
            //    client.DownloadFile(@"http://www.jct.ac.il/~coshri/atm.xml", path + BanksFileName);
            //}
            //finally
            //{
            //    client.Dispose();
            //}            
        }

        #endregion
    }
}
