using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Host
    {
        public int HostID { get;  set; }
        public string PrivateName { get;  set; }
        public int passwordeHash { get; set; }
        public string FamilyName { get;  set; }
        public string FhoneNumber { get;  set; }
        public string MailAddress { get;  set; }
        public BankBranch BankBranch { get;  set; }
        public int BankAccountNumber { get; set; }
        public bool CollectionClearance { get; set; }
        public int numOrders { get; set; }
        public int numUnits { get; set; }
        
        public override string ToString()
        {
            return string.Format("HostKey: {0}\nPrivateName: {1}\nFamilyName: {2}\nFhoneNumber: {3}\nMailAddress: {4}\nBankBranch: {5}\n" +
                "BankAccountNumber: {6}\nCollectionClearance: {7}\nnumOrders {8}\nnumUnits: {9}\n"
                , HostID, PrivateName, FamilyName, FhoneNumber, MailAddress, BankBranch, BankAccountNumber, CollectionClearance, numOrders, numUnits);
        }
    }
}
