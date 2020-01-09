using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

    public class TargetNotFoundException : Exception
    {
        public TargetNotFoundException(string a) : base(a + "ERROR, Target Not Found")
        {

        }
    }

    public class SourceNotFoundException : Exception
    {
        public SourceNotFoundException(string a) : base(a + "ERROR, Source Not Found")
        {

        }
    }

    public class EntryAndReleaseDatesMismatchException : Exception
    {
        public EntryAndReleaseDatesMismatchException(string a) : base(a + "ERROR, Entry and Release Dates do not match")
        {

        }
    }

    public class datsOutOfRange : Exception
    {
        public datsOutOfRange(string a) : base(a + "ERROR,One or more dats Out Of Range")
        {

        }
    }

    public class StatusException : Exception
    {
        public StatusException(string a) : base(a + "ERROR,Status unchangeable")
        {

        }
    }

    public class CanNotDeleteException : Exception
    {
        public CanNotDeleteException(string a) : base(a)
        {

        }
    }
    
    public class AreaAndSubAreaMismatchException : Exception
    {
        public AreaAndSubAreaMismatchException() : base("ERROR, Area and Sub Area do not match")
        {
            

        }
    }
    
    public class branchNotFoundException : Exception
    {
        public branchNotFoundException() : base( "invalid bank branch")
        {

        }
    }

    public class NoBillingAuthorizationException : Exception
    {
        public NoBillingAuthorizationException() : base("host with no Billing Authorization can not add hosting units")
        {

        }
    }
}



