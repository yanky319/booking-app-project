using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GuestRequest
    {
        public int GuestRequestKey { get;private set; }
        public string PrivateName { get; private set; }
        public string FamilyName { get; private set; }
        public string MailAddress { get; private set; }
        public RequestStatus Status { get;  set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime EntryDate { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public Areas Area { get; private set; }
        //public string SubArea { get; private set; }
        public Types Type { get; private set; }
        public int Adults { get; private set; }
        public int Children { get; private set; }
        public ThreeChoice Pool { get; private set; }
        public ThreeChoice Jacuzzi { get; private set; }
        public ThreeChoice Garden { get; private set; }
        public ThreeChoice ChildrensAttractions { get; private set; }
        //public override string ToString()
        //{
        //    return base.ToString(); 
        //}


    }
}
