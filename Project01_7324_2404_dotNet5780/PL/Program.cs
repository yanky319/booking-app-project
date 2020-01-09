using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime a = DateTime.Now.AddMonths(11);
            Console.WriteLine(a.ToShortDateString());
            Console.ReadKey();
        }
    }
}
/*
 EMAIL_PATTERN = r"([\w\.-]+)@([\w\.-]+)(\.[\w\.]+)"
*/
