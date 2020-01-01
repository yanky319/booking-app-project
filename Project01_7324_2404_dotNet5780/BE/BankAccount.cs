using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankAccount
    {
        public int BankNumber { get;private set; }
        //public string BankName { get; private set; }
        public int BranchNumber { get; private set; }
        public string BranchAddress { get; private set; }
        public string BranchCity { get; private set; }
        public int BankAccountNumber { get; private set; }
        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}
