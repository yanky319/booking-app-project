//dotNet_5780_02_Program.cs
//yaakov taber 319187324
//moshe helfgot 206262404
//עשינו את הבונוס של האינדקסר (של המחלקה שמייצגת יחידת אירוח) שמקבלת משתנה תאריך 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Targil2.ClassLibrary;

namespace Targil2.ConsoleApp
{
    class Program
    {
        // A function that induces random hosting requests
        static Random rand = new Random(DateTime.Now.Millisecond);
        private static GuestRequest CreateRandomRequest()
        {
            GuestRequest gs = new GuestRequest();
            gs.EntryDate = new DateTime(2019, rand.Next(1, 12), rand.Next(1, 29));
            int duriation = rand.Next(2, 11);
            gs.ReleaseDate = gs.EntryDate.AddDays(duriation);
            return gs;
        }

        static void Main(string[] args)
        {
            //Create a list of hosts, with a random number of hosting units
            List<Host> lsHosts;
            lsHosts = new List<Host>()
            {
            new Host(1, rand.Next(1,5)),
            new Host(2, rand.Next(1,5)),
            new Host(3, rand.Next(1,5)),
            new Host(4, rand.Next(1,5)),
            new Host(5, rand.Next(1,5))
            };
            //Add a random number of hosting requests to each host
            for (int i = 0; i < 100; i++)
            {
                foreach (var host in lsHosts)
                {
                    GuestRequest gs1 = CreateRandomRequest();
                    GuestRequest gs2 = CreateRandomRequest();
                    GuestRequest gs3 = CreateRandomRequest();
                    switch (rand.Next(1, 4))
                    {
                        case 1:
                            host.AssignRequests(gs1);
                            break;
                        case 2:
                            host.AssignRequests(gs1, gs2);
                            break;
                        case 3:
                            host.AssignRequests(gs1, gs2, gs3);
                            break;
                        default:
                            break;
                    }
                }
            }
            //Create dictionary for all units <unitkey, occupancy_percentage>
            Dictionary<long, float> dict = new Dictionary<long, float>();
            foreach (var host in lsHosts)
            {
                //test Host IEnuramble is ok
                foreach (HostingUnit unit in host)
                {
                    dict[unit.HostingUnitKey] = unit.GetAnnualBusyPercentage();
                }
            }
            //get max value in dictionary
            float maxVal = dict.Values.Max();
            //get max value key name in dictionary
            long maxKey = dict.FirstOrDefault(x => x.Value == dict.Values.Max()).Key;
            //find the Host that its unit has the maximum occupancy percentage
            foreach (var host in lsHosts)
            {
                //test indexer of Host
                for (int i = 0; i < host.HostingUnitCollection.Count; i++)
                {
                    if (host[i].HostingUnitKey == maxKey)
                    {
                        //sort this host by occupancy of its units
                        host.SortUnits();
                        //print this host detailes
                        Console.WriteLine("**** Details of the Host with themost occupied unit:\n");
                        Console.WriteLine(host);
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }
    }
}
