using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Host
    {
        public int HostKey { get; private set; }
        public string PrivateName { get; private set; }
        public string FamilyName { get; private set; }
        public int FhoneNumber { get; private set; }
        public string MailAddress { get; private set; }
        public BankAccount BankAccuont { get; private set; }
        public bool CollectionClearance { get; set; }
        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}
