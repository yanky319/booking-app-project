using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GuestRequest
    {
        public int GuestRequestKey { get; set; }
        public string PrivateName { get;  set; }
        public string FamilyName { get;  set; }
        public string MailAddress { get;  set; }
        public RequestStatus Status { get;  set; }
        public DateTime RegistrationDate { get;  set; }
        public DateTime EntryDate { get;  set; }
        public DateTime ReleaseDate { get;  set; }
        public Areas Area { get;  set; }
        public SubAreas SubArea { get;  set; }
        public Types Type { get;  set; }
        public int Adults { get;  set; }
        public int Children { get;  set; }
        public ThreeChoice Pool { get;  set; }
        public ThreeChoice Jacuzzi { get;  set; }
        public ThreeChoice Garden { get;  set; }
        public ThreeChoice ChildrensAttractions { get;  set; }
        public ThreeChoice wifi { get; set; }
        public ThreeChoice accessibility { get; set; }
        public meals Meals { get; set; }
        public special_meal specialMmeal { get; set; }

        //public override string ToString()
        //{
        //    return string.Format("GuestRequestKey: {0}\nPrivateName: {1}\nFamilyName: {2}\nMailAddress: {3}\nStatus: {4}\nRegistrationDate: {5}\n" +
        //        "EntryDate: {6}\nReleaseDate: {7}\nArea: {8}\nSubArea: {9}\nType: {10}"
        //        , GuestRequestKey, PrivateName, FamilyName, MailAddress, Status, RegistrationDate, EntryDate, ReleaseDate, Area, SubArea, Type);
        //}


    }
}
