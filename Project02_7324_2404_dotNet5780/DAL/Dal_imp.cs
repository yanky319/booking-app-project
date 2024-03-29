﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using DS;

namespace DAL
{
    public class Dal_imp : Idal
    {
        public List<T> copy_List<T>(List<T> DSlist)
        {
            return new List<T>(DSlist);
        }
      
        #region GuestRequest functions

        public void addGuestRequest(GuestRequest request)
        {
            if (DataSource.guestRequests == null)
                throw new TargetNotFoundException("DAL_");
            request.GuestRequestKey = Configuration.GuestRequestKey;
            request.RegistrationDate = DateTime.Today;
            DataSource.guestRequests.Add(copy_List<GuestRequest>(new List<GuestRequest>(){request})[0]);
        }
        public void updateGuestRequest(int key, RequestStatus status)
        {
            if (DataSource.guestRequests == null)
                throw new SourceNotFoundException("DAL_");
            var a = from item in DataSource.guestRequests
                    where item.GuestRequestKey == key
                    select item;
            if (a.Count() == 0)
                throw new KeyNotFoundException("DAL_ERROR, guest Request with this key does not exist");
            a.ElementAt(0).Status = status;
        }
        public void deleteGuestRequest(int key)
        {
            if (DataSource.guestRequests == null)
                throw new SourceNotFoundException("DAL_");
            int index = DataSource.guestRequests.FindIndex(e => e.GuestRequestKey == key);
            if (index == -1)
                throw new KeyNotFoundException("DAL_ERROR, Guest Request with this key does not exist");
            DataSource.guestRequests.RemoveAt(index);
        }
        public IEnumerable<GuestRequest> getGuestRequests()
        {
            if (DataSource.guestRequests == null)
                throw new SourceNotFoundException("DAL_");
            return copy_List<GuestRequest>(DataSource.guestRequests);
        }
        
        #endregion

        #region HostingUnit functions

        public void deleteHostingUnit(int unitKey)
        {
            if (DataSource.hostingUnits == null)
                throw new SourceNotFoundException("DAL_");
            int index = DataSource.hostingUnits.FindIndex(e => e.HostingUnitKey == unitKey);
            if (index == -1)
                throw new KeyNotFoundException("DAL_ERROR, hosting unit with this key does not exist");
            int index2 = DataSource.hosts.FindIndex(e => e.HostID == DataSource.hostingUnits[index].HostID);
            DataSource.hosts[index2].numUnits--;
            DataSource.hostingUnits.RemoveAt(index);
        }
        public void addHostingUnit(HostingUnit unit)
        {
            if (DataSource.hostingUnits == null || DataSource.hosts == null)
                throw new TargetNotFoundException("DAL_");
            int index = DataSource.hosts.FindIndex(e => e.HostID == unit.HostID);
            DataSource.hosts[index].numUnits++;
            unit.HostingUnitKey = Configuration.HostingUnitKey;
            DataSource.hostingUnits.Add(copy_List<HostingUnit>(new List<HostingUnit>() { unit})[0]);
        }
        public void updateHostingUnit(HostingUnit unit)
        {
            if (DataSource.hostingUnits == null)
                throw new SourceNotFoundException("DAL_");
            int index = DataSource.hostingUnits.FindIndex(e => e.HostingUnitKey == unit.HostingUnitKey);
            if (index == -1)
                throw new KeyNotFoundException("DAL_ERROR, Hosting Unit with this key does not exist");

            DataSource.hostingUnits[index] = copy_List<HostingUnit>(new List<HostingUnit>() { unit })[0];
        }

        public IEnumerable<HostingUnit> getHostingUnits()
        {
            if (DataSource.hostingUnits == null)
                throw new SourceNotFoundException("DAL_");
            return copy_List<HostingUnit>(DataSource.hostingUnits);
        }

        #endregion

        #region Order functions

        public void addOrder(Order order)
        {
            if (DataSource.orders == null)
                throw new TargetNotFoundException("DAL_");

            order.OrderKey = Configuration.orderKey;
            order.Status = OrderStatus.not_addressed;
            order.CreateDate = DateTime.Today;
            order.OrderDate = DateTime.MinValue;

            DataSource.orders.Add(copy_List<Order>(new List<Order>() { order })[0]);
        }

        public void updateOrder(int key, OrderStatus status)
        {
            if (DataSource.orders == null)
                throw new SourceNotFoundException("DAL_");
            var a = from item in DataSource.orders
                    where item.OrderKey == key
                    select item;
            if (a.Count() == 0)
                throw new KeyNotFoundException("DAL_ERROR, guest Request with this key does not exist");
            a.ElementAt(0).Status = status;
        }

        public IEnumerable<Order> getOrders()
        {
            if (DataSource.orders == null)
                throw new SourceNotFoundException("DAL_");
            return copy_List<Order>(DataSource.orders);
        }

        #endregion

        #region Host functions

        public void addHost(Host host)
        {
            if (DataSource.hosts == null)
                throw new TargetNotFoundException("DAL_");
            host.numOrders = 0;
            host.numUnits = 0;
            DataSource.hosts.Add(copy_List<Host>(new List<Host>() { host })[0]);
        }

        public void deleteHost(int Key)
        {
            if (DataSource.hosts == null)
                throw new SourceNotFoundException("DAL_");

            int index = DataSource.hosts.FindIndex(e => e.HostID == Key);
            if (index == -1)
                throw new KeyNotFoundException("DAL_ERROR, hosting unit with this key does not exist");
            DataSource.hostingUnits.RemoveAt(index);
        }

        public void updateHost(Host host)
        {
            if (DataSource.hosts == null)
                throw new SourceNotFoundException("DAL_");
            int index = DataSource.hosts.FindIndex(e => e.HostID == host.HostID);
            if (index == -1)
                throw new KeyNotFoundException("DAL_ERROR, Hosting Unit with this key does not exist");

            DataSource.hosts[index] = copy_List<Host>(new List<Host>() { host })[0];
        }

        public IEnumerable<Host> getHosts()
        {
            if (DataSource.hosts == null)
                throw new SourceNotFoundException("DAL_");
            return copy_List<Host>(DataSource.hosts);
        }

        #endregion

        #region BankBranch functions

        public IEnumerable<BankBranch> getBankBranchs()
        {
            if (DataSource.bankBranches == null)
                throw new SourceNotFoundException("DAL_");
            return copy_List<BankBranch>(DataSource.bankBranches);
        }

        #endregion

    }
}
