using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankBranch : IComparable<BankBranch>
    {
        public int BankNumber { get; set; }
        public string BankName { get; set; }
        public int BranchNumber { get; set; }
        public string BranchAddress { get; set; }
        public string BranchCity { get; set; }

        public int CompareTo(BankBranch branch)
        {
            if (BankNumber == branch.BankNumber && BankName == branch.BankName && BranchNumber == branch.BranchNumber &&
                 BranchAddress == branch.BranchAddress && BranchCity == branch.BranchCity)
                return 0;
            return -1;

        }
        public override string ToString()
        {
            return string.Format("BankNumber: {0}\nBankName: {1}\nBranchNumber: {2}\nBranchAddress: {3}\nBranchCity: {4}"
                , BankNumber, BankName, BranchNumber, BranchAddress, BranchCity);
        }
    }
}
