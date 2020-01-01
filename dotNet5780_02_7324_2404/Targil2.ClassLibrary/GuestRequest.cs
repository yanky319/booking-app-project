//dotNet_5780_02_GuestRequest.cs
//yaakov taber 319187324
//moshe helfgot 206262404
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Targil2.ClassLibrary
{
    /// <summary>
    /// class GuestRequest
    /// Class Represent Request For hosting
    /// </summary>
    /// 
    ///<parm name =EntryDate>Represents the start date of the request </parm>
    ///<parm name =ReleaseDate>Represents the end date of the request </parm>
    ///<parm name =IsApproved>Whether the Request was approved or not </parm>
    public class GuestRequest
    {
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsApproved { get; set; }
        /// <summary>
        /// Allows printing object of type GuestRequest
        /// </summary>
        /// <returns>String with request details</returns>
        public override string ToString()
        {
            string str = String.Format("Entry date: {0}\nRelease date: {1}\n", EntryDate.ToShortDateString(), ReleaseDate.ToShortDateString());
            str += (IsApproved) ? "Order is approved\n" : "Order is no approved\n";
            return str;
        }
        
    }
}
