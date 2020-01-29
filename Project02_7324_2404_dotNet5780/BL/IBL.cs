using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
    public interface IBL
    {
        #region fonction's

        void IsValidEmail(string email);
        void IsValidName(string name, string type);
        void IsValidDates(DateTime Entry, DateTime Release);
        void IsValidUnitName(string name);
        void IsValidHostKey(int key);
        void IsValidRequestKey(int Key);
        void IsValidNumBeds(int NumBeds);
        void IsValidArea(Areas area);
        void IsValidSubArea(Areas area, SubAreas subArea);
        void IsValidUnitKey(int key);
        void IsValidFhoneNamber(string number);
        void IsValidBankBranch(BankBranch branch);
        void IsValidOrder(GuestRequest request, HostingUnit unit);
        bool ThreeChoiceboolMatch(ThreeChoice requested, bool exists);
        void sendEmail(Order order);
        int calculatOrderCommition(Order order);
        bool CheckDatsAvailable(bool[,] diary, DateTime Entry, DateTime Release);
        void BlockDates(bool[,] diary, DateTime Entry, DateTime Release);
        IEnumerable<GuestRequest> findGuestRequestWithCondition(GuestRequestCondition condition);
        List<HostingUnit> FindAvailableUnits(DateTime Entry, int days,Host host);
        int? dateRange(params DateTime[] dates);
        List<Order> FindExpiredOrders(int days);
        int NumOfOrdersPerRequest(GuestRequest request);
        int NomOfOrdersPerHostingUnit(HostingUnit unit);
        IEnumerable<IGrouping<Areas, GuestRequest>> GuestRequestGroupdeByArae();
        IEnumerable<IGrouping<int, GuestRequest>> GuestRequestGroupdeByNuOfPeople();
        IEnumerable<IGrouping<Areas, HostingUnit>> HostingUnitGroupdeByArae();
        IEnumerable<IGrouping<int, Host>> HostsGroupdeByNumOfUnits();
        

        #endregion

        #region GuestRequest functions

        void addGuestRequest(GuestRequest request);
        void updateGuestRequest(int key, RequestStatus status);
        IEnumerable<GuestRequest> getGuestRequests();

        #endregion

        #region HostingUnit functions

        void deleteHostingUnit(int unitKey);
        void addHostingUnit(HostingUnit unit);
        void updateHostingUnit(HostingUnit unit);
        IEnumerable<HostingUnit> getHostingUnits();
        HostingUnit getHostingUnit(int key);
        #endregion

        #region Host functions

        void addHost(Host host);
        void deleteHost(int Key);
        Host getHost(int key);
        void updateHost(Host host);
        IEnumerable<Host> getHosts();
        IEnumerable<HostingUnit> GetHostsHostingUnits(Host host, Func<HostingUnit, bool> predicate = null);
        IEnumerable<Order> getHostsOrders(Host host, Func<Order, bool> predicate = null);
        
        #endregion

        #region Order functions

        void addOrder(Order order);
        void updateOrder(int key, OrderStatus status);
        Order getOrder(int key);
        IEnumerable<Order> getOrders();

        #endregion

        #region BankBranch functions

        IEnumerable<BankBranch> getBankBranchs();

        #endregion

    }
}
