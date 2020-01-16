using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class FactorySingleton
    {
        private static IBL instance = null;

        static FactorySingleton() { }

        public static IBL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BL_imp();
                }
                return instance;
            }
        }
    }
}
