﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum Status
    {
        NotYetApproved, MailSent, CloseByClient, CloseByApp
    }

    public enum Area
    {
        Jerusalem,North,South,Center
    }

    public enum HostingType
    {
        Zimmer,Hotel,Camping,RentingRoom
    }

    public enum Requirements
    {
        Necessary, Possible, NotNecessary
    }
}
