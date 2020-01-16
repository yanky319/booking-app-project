using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using BE;

namespace BL
{
    public delegate bool GuestRequestCondition(GuestRequest unit);
    public class BL_imp : IBL
    {

        #region fonction's

        public void IsValidEmail(string email)
        {
            new System.Net.Mail.MailAddress(email);
        }
        public void IsValidName(string name, string type)
        {
            try
            {
                if (!Regex.Match(name, "^[a-zA-Z][a-zA-Z]*$").Success)
                    throw new FormatException("invalid " + type + " name format");
            }
            catch
            {
                throw new FormatException("invalid " + type + " name format");
            }

        }
        public void IsValidDates(DateTime Entry, DateTime Release)
        {
            if ((Release - Entry).TotalDays < 1)
                throw new EntryAndReleaseDatesMismatchException("BL_");
            if (Entry < DateTime.Now || Entry > DateTime.Now.AddMonths(11) || Release > DateTime.Now.AddMonths(11))
                throw new datsOutOfRange("BL_");
        }
        public void IsValidUnitName(string name)
        {
            try
            {
                if (!Regex.Match(name, "^[a-zA-Z][a-zA-Z]*$").Success)
                    throw new FormatException("invalid Hosting Unit Name");
            }
            catch
            {
                throw new FormatException("invalid Hosting Unit Name");
            }
        }
        public void IsValidHostKey(int key)
        {
            int index = getHosts().ToList().FindIndex(e => e.HostKey == key);
            if (index == -1)
                throw new KeyNotFoundException("A Host with this key does not exist");
        }
        public void IsValidRequestKey(int Key)
        {
            int index = getGuestRequests().ToList().FindIndex(e => e.GuestRequestKey == Key);
            if (index == -1)
                throw new KeyNotFoundException("A Host with this key does not exist");
        }
        public void IsValidNumBeds(int NumBeds)
        {
            if (NumBeds <= 0)
                throw new FormatException("Hosting Unit must have at least one bed");
        }
        public void IsValidArea(Areas area)
        {
            if (area <= Areas.All)
                throw new ArgumentOutOfRangeException("invalid Area");

        }
        public void IsValidSubArea(Areas area, SubAreas subArea)
        {
            if (subArea <= (SubAreas)(100 * (int)area) || subArea >= (SubAreas)(100 * ((int)area + 1)))
                throw new AreaAndSubAreaMismatchException();
        }
        public void IsValidUnitKey(int key)
        {
            int index = getHostingUnits().ToList().FindIndex(e => e.HostingUnitKey == key);
            if (index == -1)
                throw new KeyNotFoundException("A Host Unit with this key does not exist");
        }
        public void IsValidFhoneNamber(string number)
        {
            try
            {
                if (!Regex.Match(number, "^[0-9][0-9]*$").Success)
                    throw new FormatException("invalid Fhone Namber format");
            }
            catch
            {
                throw new FormatException("invalid Fhone Namber format");
            }
        }
        public void IsValidBankBranch(BankBranch branch)
        {
            var a = from item in getBankBranchs()
                    where branch == item
                    select new { };
            if (a.Count() == 0)
                throw new branchNotFoundException();
        }
        public void IsValidOrder(GuestRequest request, HostingUnit unit)
        {
            if (request.Status != RequestStatus.open)
                throw new OrderCannotBePlacedException("request Status is not open");
            if ((request.Area != Areas.All && request.Area != unit.Area) || (request.SubArea != SubAreas.All && request.SubArea != unit.SubArea))
                throw new OrderCannotBePlacedException("Area or Sub Area does not match the request");
            if (request.Type != Types.All && request.Type != unit.Type)
                throw new OrderCannotBePlacedException("type does not match the request");
            if (request.Adults + request.Children > unit.num_beds)
                throw new OrderCannotBePlacedException("There are not enough beds in the unit");
            if (!ThreeChoiceboolMatch(request.Pool, unit.Pool))
                throw new OrderCannotBePlacedException("Client requirements for pool not matched");
            if (!ThreeChoiceboolMatch(request.Jacuzzi, unit.Jacuzzi))
                throw new OrderCannotBePlacedException("Client requirements for Jacuzzi not matched");
            if (!ThreeChoiceboolMatch(request.Garden, unit.Garden))
                throw new OrderCannotBePlacedException("Client requirements for Garden not matched");
            if (!ThreeChoiceboolMatch(request.ChildrensAttractions, unit.ChildrensAttractions))
                throw new OrderCannotBePlacedException("Client requirements for Childrens Attractions not matched");
            if (!ThreeChoiceboolMatch(request.wifi, unit.wifi))
                throw new OrderCannotBePlacedException("Client requirements for wifi not matched");
            if (!ThreeChoiceboolMatch(request.accessibility, unit.accessibility))
                throw new OrderCannotBePlacedException("Client requirements for accessibility not matched");
            if (!CheckDatsAvailable(unit.Diary, request.EntryDate, request.ReleaseDate))
                throw new OrderCannotBePlacedException("The unit is not available on the requested dates");
        }
        public bool ThreeChoiceboolMatch(ThreeChoice requested, bool exists)
        {

            if (requested == ThreeChoice.optional ||
                (requested == ThreeChoice.necessary && exists) ||
                (requested == ThreeChoice.not_interested && !exists))
                return true;
            return false;
        }
        public void sendEmail(Order order) { }
        public void calculatOrderCommition(Order order)
        {
            var a = getGuestRequests().ToList().Find(e => e.GuestRequestKey == order.GuestRequestKey);
            int commission = (int)dateRange(a.EntryDate, a.ReleaseDate) * Configuration.commission;
        }
        public bool CheckDatsAvailable(bool[,] diary, DateTime Entry, DateTime Release)
        {
            int j = 0;
            for (DateTime i = Entry; i < Release; i = i.AddDays(1))
            {
                j = (i - DateTime.Now.AddMonths(-1)).Days;
                if (diary[j / 31, j % 31])
                    return false;
            }

            return true;
        }
        public void BlockDates(bool[,] diary, DateTime Entry, DateTime Release)
        {
            int j = 0;
            for (DateTime i = Entry; i < Release; i = i.AddDays(1))
            {
                j = (i - DateTime.Now.AddMonths(-1)).Days;
                diary[j / 31, j % 31] = true;
            }
        }
        public IEnumerable<GuestRequest> findGuestRequestWithCondition(GuestRequestCondition condition)
        {
            try
            {
                List<GuestRequest> requests = getGuestRequests().ToList();
                foreach (GuestRequest item in requests)
                    if (!condition(item))
                        requests.Remove(item);
                return requests;
            }
            catch
            {
                throw new SourceNotFoundException("BL_");
            }
        }
        public List<HostingUnit> FindAvailableUnits(DateTime Entry, int days)
        {
            var a = from item in getHostingUnits()
                    where CheckDatsAvailable(item.Diary, Entry, Entry.AddDays(days - 1))
                    select item;
            return a.ToList();
        }
        public int? dateRange(params DateTime[] dates)
        {
            if (dates.Count() == 1)
            {
                return (DateTime.Now - dates[0]).Days;
            }
            if (dates.Count() == 2)
            {
                return (dates[1] - dates[0]).Days;
            }
            return null;
        }
        public List<Order> FindExpiredOrders(int days)
        {
            var a = from item in getOrders()
                    where dateRange(item.CreateDate) < days
                    select item;
            return a.ToList();
        }
        public int NumOfOrdersPerRequest(GuestRequest request)
        {
            return getOrders().ToList().FindAll(e => e.GuestRequestKey == request.GuestRequestKey).Count();
        }
        public int NomOfOrdersPerHostingUnit(HostingUnit unit)
        {
            return getOrders().ToList().FindAll(e => e.HostingUnitKey == unit.HostingUnitKey && e.Status == OrderStatus.closed_with_deal).Count();
        }




        public IEnumerable<IGrouping<Areas, GuestRequest>> GuestRequestGroupdeByArae()
        {
            var a = from item in getGuestRequests()
                    group item by item.Area;


            return a;
        }
        public IEnumerable<IGrouping<int, GuestRequest>> GuestRequestGroupdeByNuOfPeople()
        {
            var a = from item in getGuestRequests()
                    group item by (item.Adults + item.Children);


            return a;
        }

        public IEnumerable<IGrouping<Areas, HostingUnit>> HostingUnitGroupdeByArae()
        {
            var a = from item in getHostingUnits()
                    group item by item.Area;


            return a;
        }
        public IEnumerable<IGrouping<int, Host>> HostsGroupdeByNumOfUnits()
        {
            var a = from item in getHosts()
                    group item by item.numUnits;


            return a;
        }


        #endregion

        #region GuestRequest functions

        public void addGuestRequest(GuestRequest request)
        {
            IsValidDates(request.EntryDate, request.ReleaseDate);
            IsValidName(request.PrivateName, "Privat");
            IsValidName(request.FamilyName, "Family");
            IsValidEmail(request.MailAddress);

            try
            {
                DAL.Idal dal = DAL.FactorySingleton.Instance;
                dal.addGuestRequest(request);
            }
            catch (TargetNotFoundException e)
            {
                throw new TargetNotFoundException("BL" + e.Message.Substring(3));
            }
        }

        public void updateGuestRequest(int key, RequestStatus status)
        {
            DAL.Idal dal = DAL.FactorySingleton.Instance;

            try
            {
                List<GuestRequest> Requests = dal.getGuestRequests().ToList();
                int index = Requests.FindIndex(e => e.GuestRequestKey == key);
                if (index == -1)
                    throw new KeyNotFoundException("BL_ERROR, Guest Request with this key does not exist");
                GuestRequest request = Requests[index];
                if (request.Status != RequestStatus.open)
                    throw new StatusException("BL_");
                dal.updateGuestRequest(key, status);
            }
            catch (KeyNotFoundException e)
            {
                throw new KeyNotFoundException("BL" + e.Message.Substring(3));
            }
            catch (TargetNotFoundException)
            {
                throw new TargetNotFoundException("BL_");
            }
            catch (SourceNotFoundException)
            {
                throw new SourceNotFoundException("BL_");
            }
        }

        public IEnumerable<GuestRequest> getGuestRequests()
        {
            try
            {
                DAL.Idal dal = DAL.FactorySingleton.Instance;
                List<GuestRequest> Requests = dal.getGuestRequests().ToList();
                if (Requests == null)
                    throw new SourceNotFoundException("BL_");
                return Requests;
            }
            catch (SourceNotFoundException)
            {
                throw new SourceNotFoundException("BL_");
            }
        }

        #endregion

        #region HostingUnit functions

        public void deleteHostingUnit(int unitKey)
        {
            try
            {
                var a = from order in getOrders()
                        where order.HostingUnitKey == unitKey
                        select new { order.Status, order.GuestRequestKey };

                var b = from item in a
                        where item.Status != OrderStatus.closed_without_deal
                        from request in getGuestRequests()
                        let flag = request.GuestRequestKey == item.GuestRequestKey && request.ReleaseDate > DateTime.Now
                        where flag
                        select flag;

                if (b.Count() != 0)
                    throw new CanNotDeleteException("BL_EROR, HostingUnit with open Orders can not be deleted ");

                DAL.Idal dal = DAL.FactorySingleton.Instance;
                dal.deleteHostingUnit(unitKey);
            }
            catch (SourceNotFoundException)
            {
                throw new SourceNotFoundException("BL_");
            }
        }

        public void addHostingUnit(HostingUnit unit)
        {
            IsValidHostKey(unit.HostKey);
            IsValidUnitName(unit.HostingUnitName);
            IsValidNumBeds(unit.num_beds);
            IsValidArea(unit.Area);
            IsValidSubArea(unit.Area, unit.SubArea);
            unit.Diary = new bool[12, 31];
            try
            {
                DAL.Idal dal = DAL.FactorySingleton.Instance;
                dal.addHostingUnit(unit);
            }
            catch (TargetNotFoundException)
            {
                throw new TargetNotFoundException("BL_");
            }

        }

        public void updateHostingUnit(HostingUnit unit)
        {
            IsValidUnitKey(unit.HostKey);
            IsValidUnitName(unit.HostingUnitName);
            try
            {
                DAL.Idal dal = DAL.FactorySingleton.Instance;
                dal.updateHostingUnit(unit);
            }
            catch (TargetNotFoundException)
            {
                throw new TargetNotFoundException("BL_");
            }
        }

        public IEnumerable<HostingUnit> getHostingUnits()
        {
            try
            {
                DAL.Idal dal = DAL.FactorySingleton.Instance;
                List<HostingUnit> units = dal.getHostingUnits().ToList();
                if (units == null)
                    throw new SourceNotFoundException("BL_");
                return units;
            }
            catch (SourceNotFoundException)
            {
                throw new SourceNotFoundException("BL_");
            }
        }

        public HostingUnit getHostingUnit(int key)
        {
            try
            {
                var a = from item in getHostingUnits()
                        where item.HostingUnitKey == key
                        select item;
                if (a.Count() == 0)
                    throw new KeyNotFoundException("HostingUnit with this key does not exist");
                return a.ToList()[0];
            }
            catch (SourceNotFoundException)
            {
                throw new SourceNotFoundException("BL_");
            }
        }
        #endregion

        #region Host functions

        public void addHost(Host host)
        {
            IsValidName(host.PrivateName, "Privat");
            IsValidName(host.FamilyName, "Family");
            IsValidFhoneNamber(host.FhoneNumber);
            IsValidEmail(host.MailAddress);
            IsValidBankBranch(host.BankBranch);

            try
            {
                DAL.Idal dal = DAL.FactorySingleton.Instance;
                dal.addHost(host);
            }
            catch (TargetNotFoundException e)
            {
                throw new TargetNotFoundException("BL" + e.Message.Substring(3));
            }
        }

        public void deleteHost(int Key)
        {
            try
            {
                IsValidHostKey(Key);
                var a = from order in getOrders()
                        where order.HostKey == Key && order.Status != OrderStatus.closed_without_deal
                        from request in getGuestRequests()
                        where request.GuestRequestKey == order.GuestRequestKey && request.ReleaseDate > DateTime.Now
                        select new { };
                if (a.Count() != 0)
                    throw new CanNotDeleteException("host with open Orders can not be deleted ");

                DAL.Idal dal = DAL.FactorySingleton.Instance;
                dal.deleteHost(Key);
            }
            catch (SourceNotFoundException)
            {
                throw new SourceNotFoundException("BL_");
            }
        }

        public Host getHost(int key)
        {
            try
            {
                var a = from item in getHosts()
                        where item.HostKey == key
                        select item;
                if (a.Count() == 0)
                    throw new KeyNotFoundException("Host with this key does not exist");
                return a.ToList()[0];
            }
            catch (SourceNotFoundException)
            {
                throw new SourceNotFoundException("BL_");
            }
        }

        public void updateHost(Host host)
        {
            IsValidFhoneNamber(host.FhoneNumber);
            IsValidEmail(host.MailAddress);
            IsValidBankBranch(host.BankBranch);
            if (host.CollectionClearance == false)
            {
                var a = from order in getOrders()
                        where order.HostKey == host.HostKey && order.Status != OrderStatus.closed_without_deal
                        from request in getGuestRequests()
                        where request.GuestRequestKey == order.GuestRequestKey && request.ReleaseDate > DateTime.Now
                        select new { };
                if (a.Count() != 0)
                    throw new CanNotDeleteException("host with open Orders Can Not cancel Collection Clearance");
            }
            try
            {
                DAL.Idal dal = DAL.FactorySingleton.Instance;
                dal.updateHost(host);
            }
            catch (TargetNotFoundException)
            {
                throw new TargetNotFoundException("BL_");
            }
        }


        public IEnumerable<Host> getHosts()
        {

            try
            {
                DAL.Idal dal = DAL.FactorySingleton.Instance;
                List<Host> Hosts = dal.getHosts().ToList();
                if (Hosts == null)
                    throw new SourceNotFoundException("BL_");
                return Hosts;
            }
            catch (SourceNotFoundException)
            {
                throw new SourceNotFoundException("BL_");
            }
        }

        #endregion

        #region Order functions

        public void addOrder(Order order)
        {
            IsValidHostKey(order.HostKey);
            IsValidUnitKey(order.HostingUnitKey);
            IsValidRequestKey(order.GuestRequestKey);

            var a = from item in getGuestRequests()
                    where item.GuestRequestKey == order.GuestRequestKey
                    select item;
            var b = getHostingUnit(order.HostingUnitKey);

            IsValidOrder(a.ElementAt(0), b);
            BlockDates(b.Diary, a.ElementAt(0).EntryDate, a.ElementAt(0).ReleaseDate);
            try
            {
                DAL.Idal dal = DAL.FactorySingleton.Instance;
                dal.addOrder(order);
            }
            catch (TargetNotFoundException e)
            {
                throw new TargetNotFoundException("BL" + e.Message.Substring(3));
            }
        }

        public void updateOrder(int key, OrderStatus status)
        {
            Order order = getOrder(key);
            if (status != order.Status + 1 && status != OrderStatus.closed_without_deal)
                throw new ArgumentException();
            if (status == OrderStatus.mail_sent && !getHost(order.HostKey).CollectionClearance)
                throw new NoBillingAuthorizationException();
            try
            {
                DAL.Idal dal = DAL.FactorySingleton.Instance;
                dal.updateOrder(key, status);
                if (status == OrderStatus.mail_sent)
                    sendEmail(order);
                if (status == OrderStatus.closed_with_deal)
                {

                    calculatOrderCommition(order);
                    dal.updateGuestRequest(order.GuestRequestKey, RequestStatus.deal_closed);
                    var unit = getHostingUnit(order.HostingUnitKey);
                    var Request = getGuestRequests().ToList().Find(e => e.GuestRequestKey == order.GuestRequestKey);
                    BlockDates(unit.Diary, Request.EntryDate, Request.ReleaseDate);
                    updateHostingUnit(unit);
                    var a = from item in getOrders()
                            where item.GuestRequestKey == order.GuestRequestKey && item.OrderKey != order.OrderKey && item.Status != OrderStatus.closed_without_deal
                            select item.OrderKey;
                    if (a.Count() != 0)
                        foreach (int item in a)
                        {
                            try
                            {
                                updateOrder(item, OrderStatus.closed_without_deal);
                            }
                            catch
                            {

                            }
                        }
                }


            }
            catch (TargetNotFoundException e)
            {
                throw new TargetNotFoundException("BL" + e.Message.Substring(3));
            }
        }
        public Order getOrder(int key)
        {
            try
            {
                var a = from item in getOrders()
                        where item.OrderKey == key
                        select item;
                if (a.Count() == 0)
                    throw new KeyNotFoundException("HostingUnit with this key does not exist");
                return a.ElementAt(0);
            }
            catch (SourceNotFoundException)
            {
                throw new SourceNotFoundException("BL_");
            }
        }
        public IEnumerable<Order> getOrders()
        {
            try
            {
                DAL.Idal dal = DAL.FactorySingleton.Instance;
                List<Order> Orders = dal.getOrders().ToList();
                if (Orders == null)
                    throw new SourceNotFoundException("BL_");
                return Orders;
            }
            catch (SourceNotFoundException)
            {
                throw new SourceNotFoundException("BL_");
            }
        }

        #endregion

        #region BankBranch functions

        public IEnumerable<BankBranch> getBankBranchs()
        {
            try
            {
                DAL.Idal dal = DAL.FactorySingleton.Instance;
                List<BankBranch> BankBranchs = dal.getBankBranchs().ToList();
                if (BankBranchs == null)
                    throw new SourceNotFoundException("BL_");
                return BankBranchs;
            }
            catch (SourceNotFoundException)
            {
                throw new SourceNotFoundException("BL_");
            }

        }

        #endregion

    }
}
