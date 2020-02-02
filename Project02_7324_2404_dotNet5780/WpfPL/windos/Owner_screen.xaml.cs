using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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

namespace WpfPL.windos
{
    /// <summary>
    /// Interaction logic for Owner_screen.xaml
    /// </summary>
    public partial class Owner_screen : Window
    {
        public Owner_screen()
        {
            InitializeComponent();
           
            
            logout1.MouseEnter += mouseEnter;


            
       
            logout1.MouseLeave += mouseLeave;




           
            ResetorderFiltersLabel.MouseDown += ResetorderFilters;
            ResetRequestFiltersLabel.MouseDown += ResetRequestFilters;
            ResetUnitFiltersLabel.MouseDown += ResetUnitstFilters;
            searchhostssLabel.MouseDown += refreshostssdata;
            searchordersLabel.MouseDown += refresordersdata;
            searchRequestsLabel.MouseDown += refresRequesdata;
            searchUnitsLabel.MouseDown += refresUnitsdata;
            logout1.MouseDown += logout;


            AreaComboBox.ItemsSource = Enum.GetValues(typeof(Areas));
            SubAreaComboBox.ItemsSource = Enum.GetValues(typeof(SubAreas));
            TypeComboBox.ItemsSource = Enum.GetValues(typeof(Types));
            statusComboBox.ItemsSource = Enum.GetValues(typeof(OrderStatus));
            AreaComboBox2.ItemsSource = Enum.GetValues(typeof(Areas));
            SubAreaComboBox2.ItemsSource = Enum.GetValues(typeof(SubAreas));
            TypeComboBox2.ItemsSource = Enum.GetValues(typeof(Types));

            ResetUnitstFilters(this, new RoutedEventArgs());
            ResetorderFilters(this, new RoutedEventArgs());
            ResetRequestFilters(this, new RoutedEventArgs());
            ResethostFilters(this, new RoutedEventArgs());
            LBOrders.MouseDown += changeTab;
            LBunits.MouseDown += changeTab;
            LBrequsts.MouseDown += changeTab;
            LBHost.MouseDown += changeTab;
        }
        private void changeTab(object sender, MouseButtonEventArgs e)
        {
            Label l = sender as Label;
            if (l.Name == "LBHost")
            {
                Dispatcher.BeginInvoke((Action)(() => tabControl.SelectedIndex = 0));
                LBHost.Foreground = Brushes.White;
                LBrequsts.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
                LBunits.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
                LBOrders.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
            }
       
            if (l.Name == "LBOrders")
            {
                Dispatcher.BeginInvoke((Action)(() => tabControl.SelectedIndex = 2));
                LBOrders.Foreground = Brushes.White;
                LBHost.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
                LBrequsts.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
                LBunits.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
            }
            if (l.Name == "LBunits")
            {
                Dispatcher.BeginInvoke((Action)(() => tabControl.SelectedIndex = 1));
                LBunits.Foreground = Brushes.White;
                LBHost.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
                LBrequsts.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
                LBOrders.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
            }
            if (l.Name == "LBrequsts")
            {

                Dispatcher.BeginInvoke((Action)(() => tabControl.SelectedIndex = 3));
                LBHost.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
                LBrequsts.Foreground = Brushes.White;
                LBunits.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
                LBOrders.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
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
        private void refresUnitsdata(object sender, RoutedEventArgs e)
        {
            BL.IBL bL = BL.FactorySingleton.Instance;
            try
            {
                UnitsDataGrid.ItemsSource = from item in bL.getHostingUnits()
                                            where (item.HostingUnitName.Contains(searchTextBox3.Text))
                                            && (AreaComboBox.SelectedIndex == 0 || item.Area.ToString() == AreaComboBox.SelectedItem.ToString())
                                            && (SubAreaComboBox.SelectedIndex == 0 || item.SubArea.ToString() == SubAreaComboBox.SelectedItem.ToString())
                                            && (TypeComboBox.SelectedIndex == 0 || item.Type.ToString() == TypeComboBox.SelectedItem.ToString())
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
            catch (Exception)
            {

                MessageBox.Show("Error cannot load data ", "EROOR", MessageBoxButton.OK,
                                   MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
            }
           

        }
        private void ResetUnitstFilters(object sender, RoutedEventArgs e)
        {
            searchTextBox3.Text = "";
            AreaComboBox.SelectedIndex = 0;
            SubAreaComboBox.SelectedIndex = 0;
            TypeComboBox.SelectedIndex = 0;
            refresUnitsdata(sender, e);
        }


        private void refresordersdata(object sender, RoutedEventArgs e)
        {
            BL.IBL bL = BL.FactorySingleton.Instance;
            try
            {
                ordersDataGrid.ItemsSource = from item in bL.getOrders()
                                             where (statusComboBox.SelectedIndex == 0 || item.Status.ToString() == statusComboBox.SelectedItem.ToString())
                                             && (fromdatePicker.SelectedDate == null || item.CreateDate >= fromdatePicker.SelectedDate)
                                             && (todatePicker.SelectedDate == null || item.CreateDate <= todatePicker.SelectedDate)
                                             select item;
            }
            catch (Exception)
            {
                MessageBox.Show("Error cannot load data ", "EROOR", MessageBoxButton.OK,
                                                   MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
            }
           
        }
        private void ResetorderFilters(object sender, RoutedEventArgs e)
        {
            statusComboBox.SelectedIndex = 0;
            fromdatePicker.SelectedDate = null;
            todatePicker.SelectedDate = null;
            refresordersdata(sender, e);
        }

        private void refresRequesdata(object sender, RoutedEventArgs e)
        {
            BL.IBL bL = BL.FactorySingleton.Instance;
            try
            {
                RequestsDataGrid.ItemsSource = from item in bL.getGuestRequests()
                                               where (AreaComboBox2.SelectedIndex == 0 || item.Area.ToString() == AreaComboBox2.SelectedItem.ToString())
                                               && (SubAreaComboBox2.SelectedIndex == 0 || item.SubArea.ToString() == SubAreaComboBox2.SelectedItem.ToString())
                                               && (TypeComboBox2.SelectedIndex == 0 || item.Type.ToString() == TypeComboBox2.SelectedItem.ToString())
                                               && (fromdatePicker2.SelectedDate == null || item.EntryDate >= fromdatePicker2.SelectedDate)
                                               && (todatePicker2.SelectedDate == null || item.EntryDate <= todatePicker2.SelectedDate)
                                               select item;
            }
            catch (Exception)
            {
                MessageBox.Show("Error cannot load data ", "EROOR", MessageBoxButton.OK,
                                                   MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
            }
            
        }
        private void ResetRequestFilters(object sender, RoutedEventArgs e)
        {
            AreaComboBox2.SelectedIndex = 0;
            SubAreaComboBox2.SelectedIndex = 0;
            TypeComboBox2.SelectedIndex = 0;
            fromdatePicker2.SelectedDate = null;
            todatePicker2.SelectedDate = null;
            refresRequesdata(sender, e);
        }


        private void refreshostssdata(object sender, RoutedEventArgs e)
        {
            BL.IBL bL = BL.FactorySingleton.Instance;
            try
            {
                hostsDataGrid.ItemsSource = from item in bL.getHosts()
                                            where (item.PrivateName + " " + item.FamilyName).Contains(searchTextBox.Text)
                                            select new
                                            {
                                                item.PrivateName,
                                                item.FamilyName,
                                                item.HostID,
                                                item.numOrders,
                                                item.numUnits,
                                                CollectionClearance = item.CollectionClearance ? "     \u2713" : "     \u2717",
                                            };
            }
            catch (Exception)
            {
                MessageBox.Show("Error cannot load data ", "EROOR", MessageBoxButton.OK,
                                                  MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
            }
          
        }
        private void ResethostFilters(object sender, RoutedEventArgs e)
        {
            searchTextBox.Text = "";
            refreshostssdata(sender, e);

        }



       
        void logout(object sender, MouseButtonEventArgs e)
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

        void details(object sender, RoutedEventArgs e)
        {
            if (hostsDataGrid.SelectedItems.Count > 1)
            {
                MessageBox.Show("error can not display more than one Host at a time", "EROOR", MessageBoxButton.OK,
                                MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
            }
            else
            {
                dynamic a = hostsDataGrid.SelectedItem;
                int b = int.Parse(a.HostID.ToString());
                BL.IBL bl = BL.FactorySingleton.Instance;
                try
                {
                    new Host_Window(bl.getHost(b), false).ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error cannot load data ", "EROOR", MessageBoxButton.OK,
                                                  MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                }
               
            }
        }
    }
}
