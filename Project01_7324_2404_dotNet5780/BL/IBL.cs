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
        void IsValidNumBeds(int NumBeds);
        void IsValidArea(Areas area);
        void IsValidSubArea(Areas area, SubAreas subArea);
        void IsValidUnitKey(int key);
        void IsValidFhoneNamber(string number);
        void IsValidBankBranch(BankBranch branch);
        void sendEmail(Order order);
        void calculatOrderCommition(Order order);

        #endregion

        #region GuestRequest functions

        void addGuestRequest(GuestRequest request);
        void updateGuestRequest(int key, RequestStatus status);
        IEnumerable<GuestRequest> getGuestRequests();

        #endregion

        #region HostingUnit functions

        void addHostingUnit(HostingUnit unit);
        void deleteHostingUnit(int unitKey);
        void updateHostingUnit(HostingUnit unit);
        IEnumerable<HostingUnit> getHostingUnits();
        HostingUnit getHostingUnit(int key);

        #endregion

        #region Order functions

        void addOrder(Order order);
        void updateOrder(int key, OrderStatus status);
        IEnumerable<Order> getOrders();

        #endregion

        #region Host functions

        void addHost(Host host);
        void deleteHost(int Key);
        void updateHost(Host host);
        IEnumerable<Host> getHosts();
        Host getHost(int key);

        #endregion

        #region BankBranch functions

        IEnumerable<BankBranch> getBankBranchs();

        #endregion
    }
}
