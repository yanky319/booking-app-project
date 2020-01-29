using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BE
{
    public class Configuration
    {
        /*
         static string path = @"..\..\..\DataSource\";
        static string Orders = @"Orders.xml";
        static string GuestRequestFileName = @"Request.xml";
        static string HostingUnits = @"HostingUnits.xml";
        static string HostsFileName = @"Hosts.xml";
        static string Configurations = @"Configurations.xml";
             */
        private static string path = @"..\..\..\DataSource\Configurations.xml";
        private static void initialization()
        {
            FileStream file;
            XmlSerializer xmlSerializer;
            #region GuestRequestKey
            try
            {
                if (File.Exists(@"..\..\..\DataSource\Request.xml"))
                {
                    file = new FileStream(@"..\..\..\DataSource\Request.xml", FileMode.OpenOrCreate);
                    xmlSerializer = new XmlSerializer(typeof(List<GuestRequest>));
                    GuestRequestKey = ((List<GuestRequest>)xmlSerializer.Deserialize(file)).Max(i => i.GuestRequestKey);
                    file.Close();

                }
                else
                {
                    GuestRequestKey = 10000000;
                }
            }
            catch
            {
                GuestRequestKey = 10000000;
            }
            #endregion

            #region HostingUnitKey
            try
            {
                if (File.Exists(@"..\..\..\DataSource\HostingUnits.xml"))
                {
                    file = new FileStream(@"..\..\..\DataSource\HostingUnits.xml", FileMode.OpenOrCreate);
                    xmlSerializer = new XmlSerializer(typeof(List<HostingUnit>));
                    HostingUnitKey = ((List<HostingUnit>)xmlSerializer.Deserialize(file)).Max(i => i.HostingUnitKey);
                    file.Close();

                }
                else
                {
                    HostingUnitKey = 10000000;
                }
            }
            catch
            {
                HostingUnitKey = 10000000;
            }
            #endregion


            #region orderKey
            try
            {
                if (File.Exists(@"..\..\..\DataSource\Orders.xml"))
                {
                    XElement element = XElement.Load(@"..\..\..\DataSource\Orders.xml");
                    orderKey = element.Elements().Max(i => int.Parse(i.Element("OrderKey").Value));
                }
                else
                {
                    orderKey = 10000000;
                }
            }
            catch
            {

                orderKey = 10000000;
            }
            #endregion

            #region commission
            commission = 10;
            //try
            //{
            //    if (File.Exists(@"..\..\..\DataSource\Owner.xml"))
            //    {
            //        XElement element = XElement.Load(@"..\..\..\DataSource\Owner.xml");
            //        commission = element.Elements().Max(i => int.Parse(i.Element("commission").Value));
            //    }
            //    else
            //    {
            //        commission = 10;
            //    }
            //}
            //catch
            //{

            //    commission = 10;
            //}
            #endregion
            XElement root = new XElement("Configurations",
                    new XElement("GuestRequestKey", GuestRequestKey),
                    new XElement("HostingUnitKey", HostingUnitKey),
                    new XElement("orderKey", orderKey),
                    new XElement("commission", commission));
            root.Save(path);

        }
        
        public static int GuestRequestKey
        {
            private set { }
            get
            {

                if (!File.Exists(path))
                    initialization();
                XElement configurations = XElement.Load(path);
                configurations.Element("GuestRequestKey").Value = (int.Parse(configurations.Element("GuestRequestKey").Value) + 1).ToString();
                configurations.Save(path);
                return int.Parse(configurations.Element("GuestRequestKey").Value);
            }
        }
        public static int HostingUnitKey
        {
            private set { }
            get
            {
                if (!File.Exists(path))
                    initialization();
                XElement configurations = XElement.Load(path);
                configurations.Element("HostingUnitKey").Value = (int.Parse(configurations.Element("HostingUnitKey").Value) + 1).ToString();
                configurations.Save(path);
                return int.Parse(configurations.Element("HostingUnitKey").Value);
            }
        }
        public static int orderKey
        {
            private set { }
            get
            {
                if (!File.Exists(path))
                    initialization();
                XElement configurations = XElement.Load(path);
                configurations.Element("orderKey").Value = (int.Parse(configurations.Element("orderKey").Value) + 1).ToString();
                configurations.Save(path);
                return int.Parse(configurations.Element("orderKey").Value);
            }
        }
        public static int commission
        {
            set
            {
                if (!File.Exists(path))
                    initialization();
                XElement configurations = XElement.Load(path);
                configurations.Element("commission").Value = value.ToString();
                configurations.Save(path);

            }
            get
            {
                if (!File.Exists(path))
                    initialization();
                XElement configurations = XElement.Load(path);
                configurations.Element("commission").Value = (int.Parse(configurations.Element("commission").Value) + 1).ToString();
                configurations.Save(path);
                return int.Parse(configurations.Element("commission").Value);
            }
        }

    }
}
