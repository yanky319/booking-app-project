using Microsoft.VisualStudio.TestTools.UnitTesting;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Tests
{
    [TestClass()]
    public class HostTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            Host host = new Host
            {
                HostKey = "0123456",
                PrivateName = "kuku",
                FamilyName = "Forever",
                MailAddress = "nowhere@gmail.com",
                BankAccount = "9089012839",
                PhoneNumber = "+972 54 55555555",
                CollectionClearance = "NO"
            };
            Console.WriteLine(host);
            Assert.IsTrue(true);
        }
    }
}