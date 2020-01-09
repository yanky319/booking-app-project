﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class FactorySingletonDal
    {
        private static IDal instance = null;

        static FactorySingletonDal(){}

        public static IDal Instance
        {
            get
            {
                if(instance==null)
                {
                    instance = new DalXML();
                }
                return instance;
            }
        }

    }
}
