//dotNet_5780_02_HostingUnit.cs
//yaakov taber 319187324
//moshe helfgot 206262404
//עשינו את הבונוס של האינדקסר (של המחלקה שמייצגת יחידת אירוח) שמקבלת משתנה תאריך 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targil2.ClassLibrary
{
    /// <summary>
    /// class HostingUnit
    /// Class Represent a Hosting Unit
    /// </summary>
    ///< parm name = stSerialKey > Static variable to initialize the hosting unit key </parm>
    ///< parm name = HostingUnitKey > Represents the hosting unit key </parm>
    ///< parm name = Diary > Represents the hosting units Diary  </parm>
    public class HostingUnit:IComparable<HostingUnit>
    {
        private static long stSerialKey = 10000000;
        public long HostingUnitKey { get; private set; }
        private bool[,] Diary ;
        /// <summary>
        /// ctor 
        /// sets the Hosting Unit Key and the Diary
        /// </summary>
        public HostingUnit()
        {
            HostingUnitKey = stSerialKey++;
            Diary = new bool[12, 31];
        }
        /// <summary>
        /// Allows printing object of type HostingUnit
        /// </summary>
        /// <returns>String with all the units occupation dates</returns>
        public override string ToString()
        {
            string str = "hosting unit: " + HostingUnitKey + "\nocupied between dates:\n";
            bool validFirstDate = false;
            bool validLastDate = false;
            DateTime entryDate = new DateTime();
            DateTime exitDate = new DateTime();
            DateTime i;
            for ( i = new DateTime(2019, 1, 1); i <= new DateTime(2019, 12, 31); i = i.AddDays(1))
            {
                if (this[i] && !validFirstDate)  //Finding the first busy day
                {
                    entryDate = i;
                    validFirstDate = true;
                    validLastDate = false;
                }
                if (!this[i] && validFirstDate)  //Finding the last busy day
                {
                    exitDate = i.AddDays(-1);
                    str += string.Format("{0} - {1}\n", entryDate.ToShortDateString(), exitDate.ToShortDateString());
                    validFirstDate = false;
                    validLastDate = true;
                }
            }
            if (validFirstDate && !validLastDate) //An examination for the situation that the last day of the year is occupied 
            {
                str += string.Format("{0} - {1}\n", entryDate.ToShortDateString(),i.AddDays(-1).ToShortDateString());
            }
            return str;
        }
        /// <summary>
        /// A function that receives a hosting request 
        /// and checks whether the period is available for hosting     
        /// </summary>
        /// 
        /// <param name="guestReq">Represents a Request for Hosting</param>
        /// <returns>true/false Whether the Request was approved or not</returns>
        public bool ApproveRequest(GuestRequest guestReq)
        {
            //Check that the dates are free
            for (DateTime i = guestReq.EntryDate; i < guestReq.ReleaseDate; i=i.AddDays(1))
            {
                //If one is not, return false
                if (this[i])
                    return false;
            }
            //Marking the days as busy
            for (DateTime i = guestReq.EntryDate; i < guestReq.ReleaseDate; i = i.AddDays(1))
            {
                this[i] = true;
            }
            //Mark the application as approved
            guestReq.IsApproved = true;
            return true;
        }
        /// <summary>
        /// Counts the amount of busy days of the unit
        /// </summary>
        /// <returns>number Of Busy Days in the Diary</returns>
        public int GetAnnualBusyDays()
        {
            int numOfBusyDays = 0;      //Counting the busy days
            for (DateTime i = new DateTime(2019,1,1); i <= new DateTime(2019,12,31); i=i.AddDays(1))
            {
                if (this[i])
                {
                    numOfBusyDays++;
                }
            }
            return numOfBusyDays;
        }
        /// <summary>
        /// Calculates the unit annual occupancy percentage
        /// </summary>
        /// <returns>annual occupancy percentage</returns>
        public float GetAnnualBusyPercentage()
        {
            //Calculate the percentage of occupation
            return GetAnnualBusyDays() / 365f * 100;
        }
        /// <summary>
        /// Override of function CompareTo 
        /// To compare two Hosting units
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>Comparison of annual occupancy</returns>
        public int CompareTo(HostingUnit unit)
        {
            return this.GetAnnualBusyDays().CompareTo(unit.GetAnnualBusyDays());
        }
        /// <summary>
        /// An indexer that allows you to go over the Diary
        /// </summary>
        /// <param name="index"></param>
        /// <returns> get/set of a date in the Diary </returns>
        public bool this[DateTime index]
        {
            get { return Diary[index.Month-1, index.Day - 1]; }
            set { Diary[index.Month - 1, index.Day - 1] = value; }
        }

    }
}
