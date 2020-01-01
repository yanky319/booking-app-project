//dotNet_5780_02_Host.cs
//yaakov taber 319187324
//moshe helfgot 206262404
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targil2.ClassLibrary
{
    /// <summary>
    /// class Host
    /// Class Represents a owner of Hosting Units
    /// </summary>
    ///< parm name = HostKey > Represents the host's id </parm>
    ///< parm name = HostingUnitCollection > Represents a list of his hosting units </parm>
    public class Host : IEnumerable<HostingUnit>
    {
        public int HostKey { get; set; }
        public List<HostingUnit> HostingUnitCollection { get;private set; }
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="id">the host's id</param>
        /// <param name="numOfUnits">the number Of Hosting Units hi has</param>
        public Host(int id,int numOfUnits)
        {
            HostKey = id;
            HostingUnitCollection = new List<HostingUnit>(numOfUnits);

            for (int i = 0; i < numOfUnits; i++)
            {
                HostingUnitCollection.Add(new HostingUnit());
            }
        }
        /// <summary>
        /// Allows printing object of type Host
        /// </summary>
        /// <returns>String with all the units and their occupation dates</returns>
        public override string ToString()
        {
            string str = "";
            foreach (HostingUnit unit in HostingUnitCollection)
            {
                str += unit.ToString() + "\n";
            }
            return str;
        }
        /// <summary>
        /// A function that tries to add a hosting request to one of the host's units
        /// </summary>
        /// <param name="guestReq"></param>
        /// <returns>Hosting Unit Key Of the unit that received the order 
        /// or -1 If the request is not approved </returns>
        private long SubmitRequest(GuestRequest guestReq)
        {
            foreach (HostingUnit unit in HostingUnitCollection)
            {
                if (unit.ApproveRequest(guestReq))
                {
                    return unit.HostingUnitKey;
                }
            }
            return -1;
        }
        /// <summary>
        /// Calculates the number of occupied days in all of the Host's units together
        /// </summary>
        /// <returns></returns>
        public int GetHostAnnualBusyDays()
        {
            int sum = 0;
            foreach (HostingUnit unit in HostingUnitCollection)
            {
                sum += unit.GetAnnualBusyDays();
            }
            return sum;
        }
        /// <summary>
        /// Sorts the list of units by occupancy
        /// </summary>
        public void SortUnits()
        {
            HostingUnitCollection.Sort();
        }
        /// <summary>
        /// Accepts unknown number of hosting requests
        /// and tries to get all into the different hosting units        
        /// </summary>
        /// <param name="list">a list of requests</param>
        /// <returns>True, if all requests are approved, otherwise false</returns>
        public bool AssignRequests(params GuestRequest[] list)
        {
            bool flag = true;
            foreach (GuestRequest request in list)
            {
                if (SubmitRequest(request) == -1)
                {
                    flag = false;
                }
            }
            return flag;
        }
        /// <summary>
        /// Makes the class Enumerable
        /// </summary>
        /// <returns>Enumerator of the list of units</returns>
        public IEnumerator<HostingUnit> GetEnumerator()
        {
            return HostingUnitCollection.GetEnumerator();
        }
        /// <summary>
        /// Makes the class Enumerable
        /// </summary>
        /// <returns>Enumerator of the list of units</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return HostingUnitCollection.GetEnumerator();
        }
        /// <summary>
        /// An indexer that allows you to go over the list of units
        /// </summary>
        /// <param name="index"></param>
        /// <returns>The unit in the given index
        /// or null if a unit does not exist</returns>
        public HostingUnit this[int index]
        {
            get
            {
                return (index < HostingUnitCollection.Count && index >= 0) ?
                    this.HostingUnitCollection[index] : null;
            }
            set { }
        }


    }
}
