using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface Idal
    {
        #region GuestRequest functions

        void addGuestRequest(GuestRequest request);
        void updateGuestRequest(int key , RequestStatus status);
        IEnumerable<GuestRequest> getGuestRequests();

        #endregion

        #region HostingUnit functions

        void addHostingUnit(HostingUnit unit);
        void deleteHostingUnit(int unitKey);
        void updateHostingUnit(HostingUnit unit);
        IEnumerable<HostingUnit> getHostingUnits();

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

        #endregion

        #region BankBranch functions

        IEnumerable<BankBranch> getBankBranchs();

        #endregion
    }
}
