﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;

namespace WpfPL.windos
{

    public partial class Host_Window : Window
    {
        BackgroundWorker worker;
        BE.Host myhost;
        bool isHost;
        public Host_Window(BE.Host host, bool ishost)
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            worker.DoWork += sendMail;
            worker.RunWorkerCompleted += updateOrder;
            Icon = new BitmapImage(new Uri(@"../../Resources/images/icon.png", UriKind.Relative));
            myhost = host;
            isHost = ishost;
            if (!ishost)
            {
                logout1.Content = "Back";
            }
            TypeComboBox.ItemsSource = Enum.GetValues(typeof(Types));
            TypeComboBox2.ItemsSource = Enum.GetValues(typeof(Types));
            AreaComboBox.ItemsSource = Enum.GetValues(typeof(Areas));
            AreaComboBox2.ItemsSource = Enum.GetValues(typeof(Areas));
            SubAreaComboBox.ItemsSource = Enum.GetValues(typeof(SubAreas));
            SubAreaComboBox2.ItemsSource = Enum.GetValues(typeof(SubAreas));
            statusComboBox.ItemsSource = Enum.GetValues(typeof(OrderStatus));

            AreaComboBox.SelectionChanged += AreaComboBox_SelectionChanged;
            AreaComboBox2.SelectionChanged += AreaComboBox2_SelectionChanged;


            UnitsResetFilters(this, new RoutedEventArgs());
            ordersResetFilters(this, new RoutedEventArgs());
            RequesResetFilters(this, new RoutedEventArgs());

            searchUnitsLabel.Click += refreshUnitsdata;
            ResetUnitFiltersLabel.Click += UnitsResetFilters;
            searchordersLabel.Click += refreshordersdata;
            ResetorderFiltersLabel.Click += ordersResetFilters;
            searchRequestsLabel.Click += refreshRequesdata;
            ResetRequestFiltersLabel.Click += RequesResetFilters;
            logout1.MouseDown += logout;




            searchUnitsLabel.MouseEnter += mouseEnter;
            ResetUnitFiltersLabel.MouseEnter += mouseEnter;
            ResetorderFiltersLabel.MouseEnter += mouseEnter;
            searchordersLabel.MouseEnter += mouseEnter;
            ResetRequestFiltersLabel.MouseEnter += mouseEnter;
            searchRequestsLabel.MouseEnter += mouseEnter;
            logout1.MouseEnter += mouseEnter;

            searchUnitsLabel.MouseLeave += mouseLeave;
            ResetUnitFiltersLabel.MouseLeave += mouseLeave;
            ResetorderFiltersLabel.MouseLeave += mouseLeave;
            searchordersLabel.MouseLeave += mouseLeave;
            ResetRequestFiltersLabel.MouseLeave += mouseLeave;
            searchRequestsLabel.MouseLeave += mouseLeave;
            logout1.MouseLeave += mouseLeave;

            LBOrders.MouseDown += changeTab;
            LBunits.MouseDown += changeTab;
            LBrequsts.MouseDown += changeTab;
        }

        private void updateOrder(object sender, RunWorkerCompletedEventArgs e)
        {
            int key = int.Parse(e.Result.ToString());
            if (key != -1)
                BL.FactorySingleton.Instance.updateOrder(key, OrderStatus.mail_sent);
            refreshordersdata(this, new RoutedEventArgs());
        }

        private void sendMail(object sender, DoWorkEventArgs e)
        {
            BE.Order order = e.Argument as BE.Order;
            e.Result = -1;
            int count = 0;
            while (count < 5 && e.Result.ToString() == "-1")
            {
                count++;
                try
                {
                    BL.FactorySingleton.Instance.sendEmail(order);
                    e.Result = order.OrderKey;
                }
                catch (Exception)
                {
                    Thread.Sleep(2000);
                }
            }
        }

        private void changeTab(object sender, MouseButtonEventArgs e)
        {
            Label l = sender as Label;
            if (l.Name == "LBOrders")
            {
                Dispatcher.BeginInvoke((Action)(() => tabControl.SelectedIndex = 1));
                LBOrders.Foreground = Brushes.White;
                LBrequsts.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
                LBunits.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
            }
            if (l.Name == "LBunits")
            {
                Dispatcher.BeginInvoke((Action)(() => tabControl.SelectedIndex = 0));
                LBunits.Foreground = Brushes.White;
                LBrequsts.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
                LBOrders.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
            }
            if (l.Name == "LBrequsts")
            {
                Dispatcher.BeginInvoke((Action)(() => tabControl.SelectedIndex = 2));
                LBrequsts.Foreground = Brushes.White;
                LBunits.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
                LBOrders.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
            }

        }

        void logout(object sender, MouseButtonEventArgs e)
        {
            if (isHost)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to logout?", "logout", MessageBoxButton.YesNo,
                                                        MessageBoxImage.Question, MessageBoxResult.No);
                if (result.ToString() == "Yes")
                {
                    try
                    {
                        for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                            if (App.Current.Windows[intCounter] != this)
                                App.Current.Windows[intCounter].Close();
                        new MainWindow().Show();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "EROOR", MessageBoxButton.OK,
                                        MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                    }
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to go back to owners window?", "go back", MessageBoxButton.YesNo,
                                                        MessageBoxImage.Question, MessageBoxResult.No);
                if (result.ToString() == "Yes")
                {
                    try
                    {
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "EROOR", MessageBoxButton.OK,
                                        MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                    }
                }
            }

        }
        void mouseEnter(object sender, MouseEventArgs e)
        {
            Label l = sender as Label;
            if (l != null)
                l.Foreground = Brushes.White;
        }
        void mouseLeave(object sender, MouseEventArgs e)
        {
            Label l = sender as Label;
            if (l != null)
                l.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
        }

        void SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in new List<DatePicker> { fromdatePicker, fromdatePicker2, todatePicker, todatePicker2 })
            {
                if (item.SelectedDate == null)
                {
                    FieldInfo fiTextBox = typeof(DatePicker)
                    .GetField("_textBox", BindingFlags.Instance | BindingFlags.NonPublic);

                    if (fiTextBox != null)
                    {
                        DatePickerTextBox dateTextBox = (DatePickerTextBox)fiTextBox.GetValue(item);

                        if (dateTextBox != null)
                        {
                            PropertyInfo piWatermark = dateTextBox.GetType()
                             .GetProperty("Watermark", BindingFlags.Instance | BindingFlags.NonPublic);

                            if (piWatermark != null)
                            {
                                piWatermark.SetValue(dateTextBox, "Select date", null);
                            }
                        }
                    }
                }
            }
        }


        #region Units
        private void AreaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SubAreaComboBox.ItemsSource = null;
            if (AreaComboBox.SelectedIndex == 0)
            {
                SubAreaComboBox.ItemsSource = Enum.GetValues(typeof(SubAreas));
            }
            else
            {
                int valArea = (int)Enum.Parse(typeof(Areas), AreaComboBox.SelectedItem.ToString());
                List<object> a = new List<object>();
                SubAreaComboBox.ItemsSource = from i in Enum.GetValues(typeof(SubAreas)).Cast<SubAreas>()
                                              where (int)i == 0 || ((int)i >= valArea * 100 && (int)i < 100 * (valArea + 1))
                                              select i;
            }
            SubAreaComboBox.SelectedIndex = 0;
        }

        void refreshUnitsdata(object sender, RoutedEventArgs e)
        {
            BL.IBL bl = BL.FactorySingleton.Instance;
            try
            {
                UnitsDataGrid.ItemsSource = from item in bl.GetHostsHostingUnits(myhost,
                (i => i.HostingUnitName.Contains(searchTextBox.Text)
                && (AreaComboBox.SelectedIndex == 0 || i.Area.ToString() == AreaComboBox.SelectedItem.ToString())
                && (SubAreaComboBox.SelectedIndex == 0 || i.SubArea.ToString() == SubAreaComboBox.SelectedItem.ToString())
                && (TypeComboBox.SelectedIndex == 0 || i.Type.ToString() == TypeComboBox.SelectedItem.ToString())))
                                            select new
                                            {
                                                item.HostingUnitKey,
                                                item.HostingUnitName,
                                                item.Area,
                                                item.SubArea,
                                                item.Type,
                                                //item.
                                                item.num_beds,
                                                accessibility = item.accessibility ? "     \u2713" : "     \u2717",
                                                Garden = item.Garden ? "     \u2713" : "     \u2717",
                                                Pool = item.Pool ? "  \u2713" : "  \u2717",
                                                Jacuzzi = item.Jacuzzi ? "   \u2713" : "   \u2717",
                                                wifi = item.wifi ? "  \u2713" : "  \u2717",
                                                ChildrensAttractions = item.ChildrensAttractions ? "     \u2713" : "     \u2717",

                                            };
            }
            catch
            {

                //MessageBox.Show("Error cannot load data ", "EROOR", MessageBoxButton.OK,
                //                    MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);

            }


        }
        void UnitsResetFilters(object sender, RoutedEventArgs e)
        {
            AreaComboBox.SelectedIndex = 0;
            SubAreaComboBox.SelectedIndex = 0;
            TypeComboBox.SelectedIndex = 0;
            searchTextBox.Text = "";
            refreshUnitsdata(sender, e);
        }
        void UpdateUnit(object sender, RoutedEventArgs e)
        {

            if (isHost)
            {
                if (UnitsDataGrid.SelectedItems.Count > 1)
                {
                    MessageBox.Show("error cannot updated more than one unit at a time", "EROOR", MessageBoxButton.OK,
                                    MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                }
                else
                {
                    dynamic a = UnitsDataGrid.SelectedItem;
                    new Unit_window(a.HostingUnitKey, true).ShowDialog();
                }
                refreshUnitsdata(sender, e);
            }
        }
        void DeleteUnit(object sender, RoutedEventArgs e)
        {
            if (isHost)
            {
                if (UnitsDataGrid.SelectedItems.Count > 1)
                {
                    MessageBox.Show("Error cannot delete more than one unit at a time", "EROOR", MessageBoxButton.OK,
                                    MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                }
                else
                {
                    dynamic a = UnitsDataGrid.SelectedItem;
                    string b = a.ToString().Trim(new Char[] { ' ', '{', '}' });
                    b = b.Replace(" ", "");
                    b = b.Replace(",", ", ");

                    MessageBoxResult result = MessageBox.Show(b, "Delete permission", MessageBoxButton.YesNo,
                                                         MessageBoxImage.Question, MessageBoxResult.No);
                    if (result.ToString() == "Yes")
                    {
                        try
                        {
                            BL.IBL bl = BL.FactorySingleton.Instance;
                            bl.deleteHostingUnit(a.HostingUnitKey);
                            refreshUnitsdata(sender, e);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "EROOR", MessageBoxButton.OK,
                                            MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                        }
                    }
                }
                refreshUnitsdata(sender, e);
            }
        }
        void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (isHost)
            {
                new Unit_window(myhost.HostID, false).ShowDialog();
                refreshUnitsdata(sender, e);
            }
        }
        #endregion

        #region orders
        void ordersResetFilters(object sender, RoutedEventArgs e)
        {
            statusComboBox.SelectedIndex = 0;
            fromdatePicker.SelectedDate = null;
            todatePicker.SelectedDate = null;
            refreshordersdata(sender, e);
        }

        void refreshordersdata(object sender, RoutedEventArgs e)
        {
            BL.IBL bl = BL.FactorySingleton.Instance;
            try
            {
                ordersDataGrid.ItemsSource = from item in bl.getHostsOrders(myhost,
                    (i => (statusComboBox.SelectedIndex == 0 || i.Status.ToString() == statusComboBox.SelectedItem.ToString())
                    && (fromdatePicker.SelectedDate == null || i.CreateDate >= fromdatePicker.SelectedDate)
                    && (todatePicker.SelectedDate == null || i.CreateDate <= todatePicker.SelectedDate)))
                                             select item;
            }
            catch (BE.SourceNotFoundException)
            {
                //MessageBox.Show("Error cannot load data ", "EROOR", MessageBoxButton.OK,
                //                    MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);

            }

        }
        void Updateorder(object sender, RoutedEventArgs e)
        {
            if (isHost)
            {
                if (ordersDataGrid.SelectedItems.Count > 1)
                {
                    MessageBox.Show("error cannot updated more than one order at a time", "EROOR", MessageBoxButton.OK,
                                    MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                    return;
                }

                if (!myhost.CollectionClearance)
                {
                    MessageBox.Show("error Host without Collection Clearance cannot updated order ", "EROOR", MessageBoxButton.OK,
                                    MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                    return;
                }

                dynamic a = ordersDataGrid.SelectedItem;
                if (a.Status == OrderStatus.not_addressed)
                {
                    try
                    {
                        BL.IBL bl = BL.FactorySingleton.Instance;
                        worker.RunWorkerAsync(bl.getOrder(a.OrderKey)); ;
                    }
                    catch (Exception)
                    {

                    }

                    ordersResetFilters(sender, e);
                    return;
                }

                if (a.Status == OrderStatus.closed_without_deal || a.Status == OrderStatus.closed_with_deal)
                {

                    MessageBox.Show("Error cannot updated order that is already closed", "EROOR", MessageBoxButton.OK,
                                    MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                    ordersResetFilters(sender, e);
                    return;
                }

                if (a.Status == OrderStatus.mail_sent)
                {
                    BL.IBL bl = BL.FactorySingleton.Instance;
                    MessageBoxResult result = MessageBoxResult.Cancel;
                    try
                    {
                        float i = bl.calculatOrderCommition(bl.getOrder(a.OrderKey));
                        result = MessageBox.Show("Closing the deal will result a charge of" + i + "NIS", "Order Confirmation", MessageBoxButton.YesNo,
                                                    MessageBoxImage.Question, MessageBoxResult.No);
                        if (result.ToString() == "Yes")
                            bl.updateOrder(a.OrderKey, OrderStatus.closed_with_deal);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error cannot update order", "EROOR", MessageBoxButton.OK,
                                                               MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                    }

                    ordersResetFilters(sender, e);
                    return;
                }


            }
        }

        #endregion

        #region requests
        void AreaComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SubAreaComboBox2.ItemsSource = null;
            if (AreaComboBox2.SelectedIndex == 0)
            {
                SubAreaComboBox2.ItemsSource = Enum.GetValues(typeof(SubAreas));
            }
            else
            {
                int valArea = (int)Enum.Parse(typeof(Areas), AreaComboBox2.SelectedItem.ToString());
                List<object> a = new List<object>();
                SubAreaComboBox2.ItemsSource = from i in Enum.GetValues(typeof(SubAreas)).Cast<SubAreas>()
                                               where (int)i == 0 || ((int)i >= valArea * 100 && (int)i < 100 * (valArea + 1))
                                               select i;
            }
            SubAreaComboBox2.SelectedIndex = 0;
        }

        void RequesResetFilters(object sender, RoutedEventArgs e)
        {
            AreaComboBox2.SelectedIndex = 0;
            SubAreaComboBox2.SelectedIndex = 0;
            TypeComboBox2.SelectedIndex = 0;
            fromdatePicker2.SelectedDate = null;
            todatePicker2.SelectedDate = null;
            refreshRequesdata(sender, e);
        }

        void refreshRequesdata(object sender, RoutedEventArgs e)
        {
            BL.IBL bl = BL.FactorySingleton.Instance;
            try
            {
                RequestsDataGrid.ItemsSource = from item in bl.findGuestRequestWithCondition(
               i => (AreaComboBox2.SelectedIndex == 0 || i.Area.ToString() == AreaComboBox2.SelectedItem.ToString())
               && (SubAreaComboBox2.SelectedIndex == 0 || i.SubArea.ToString() == SubAreaComboBox2.SelectedItem.ToString())
               && (TypeComboBox2.SelectedIndex == 0 || i.Type.ToString() == TypeComboBox2.SelectedItem.ToString())
               && (fromdatePicker2.SelectedDate == null || i.EntryDate >= fromdatePicker2.SelectedDate)
               && (todatePicker2.SelectedDate == null || i.EntryDate <= todatePicker2.SelectedDate))
                                               select item;
            }
            catch (Exception)
            {
                //MessageBox.Show("Error cannot load data", "EROOR", MessageBoxButton.OK,
                //                    MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);

            }
        }

        void Placeorder(object sender, RoutedEventArgs e)
        {
            if (isHost)
            {
                if (ordersDataGrid.SelectedItems.Count > 1)
                {
                    MessageBox.Show("error cannot Place more than one order at a time", "EROOR", MessageBoxButton.OK,
                                    MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                    return;
                }

                dynamic a = RequestsDataGrid.SelectedItem;
                BL.IBL bl = BL.FactorySingleton.Instance;
                try
                {
                    var req = bl.getGuestRequests().ToList().Find(i => i.GuestRequestKey == a.GuestRequestKey);
                    var units = bl.FindAvailableUnits(req.EntryDate, (int)bl.dateRange(req.EntryDate, req.ReleaseDate), myhost);
                    if (units.Count() == 0)
                    {
                        MessageBox.Show("error No units were found on those dates", "EROOR", MessageBoxButton.OK,
                                   MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                        return;
                    }

                    bool success = false;
                    foreach (var item in units)
                    {
                        try
                        {
                            bl.addOrder(new BE.Order
                            {
                                HostingUnitKey = item.HostingUnitKey,
                                HostID = myhost.HostID,
                                GuestRequestKey = a.GuestRequestKey

                            });
                            success = true;
                        }
                        catch (Exception)
                        {
                        }
                    }
                    if (success)
                        MessageBox.Show("order placed successfully", "", MessageBoxButton.OK,
                                   MessageBoxImage.Information, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                    else
                        MessageBox.Show("cunnot place order", "EROOR", MessageBoxButton.OK,
                                                       MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("cunnot place order \n" + ex.Message, "EROOR", MessageBoxButton.OK,
                                                        MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                }
            }
            refreshordersdata(sender, e);

        }

        #endregion
    }
}
