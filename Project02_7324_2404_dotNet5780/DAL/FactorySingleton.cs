using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class FactorySingleton
    {
        private static Idal instance = null;

        static FactorySingleton() { }

        public static Idal Instance
        {
            get
            {
                if (instance == null)
                {
                   // instance = new Dal_imp();
                    instance = new Dal_XML_imp();
                }
                return instance;
            }
        }
    }
}
