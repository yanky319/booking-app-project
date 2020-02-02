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
        //public static int GuestRequestKey = 10000000;

        //public static int HostingUnitKey = 10000000;

        //public static int orderKey = 10000000;

        //public static int commission = 10000000;

        private static string path = @"..\..\..\DataSource\Configurations.xml";
        private static void initialization()
        {
            XElement root = new XElement("Configurations",
                    new XElement("GuestRequestKey", 10000000),
                    new XElement("HostingUnitKey", 10000000),
                    new XElement("orderKey", 10000000),
                    new XElement("commission", 10));
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
