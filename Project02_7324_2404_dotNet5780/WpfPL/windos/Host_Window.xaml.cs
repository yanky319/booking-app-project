using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfPL.windos
{
    /// <summary>
    /// Interaction logic for Host_Window.xaml
    /// </summary>
    public partial class Host_Window : Window
    {
        BE.Host myhost;
        public Host_Window(BE.Host host)
        {
            InitializeComponent();
            //throw new Exception("AAAAAAAA");
            myhost = host;
            TypeComboBox.ItemsSource = Enum.GetValues(typeof(Types));
            AreaComboBox.ItemsSource = Enum.GetValues(typeof(Areas));
            SubAreaComboBox.ItemsSource = Enum.GetValues(typeof(SubAreas));
            AreaComboBox.SelectionChanged += AreaComboBox_SelectionChanged;


            UnitsResetFilters(this, new RoutedEventArgs());
            searchUnitsLabel.MouseDown += refreshUnitsdata;
            ResetUnitFiltersLabel.MouseDown += UnitsResetFilters;

            searchUnitsLabel.MouseEnter += mouseEnter;
            ResetUnitFiltersLabel.MouseEnter += mouseEnter;
            

            searchUnitsLabel.MouseLeave += mouseLeave;
            ResetUnitFiltersLabel.MouseLeave += mouseLeave;
            
        }

        private void AreaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SubAreaComboBox.ItemsSource = null;
            if(AreaComboBox.SelectedIndex == 0)
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

        private void mouseEnter(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            label.FontSize = int.Parse(FindResource("over_size").ToString());
            label.Foreground = (Brush)new BrushConverter().ConvertFromString(FindResource("over_color").ToString());
        }

        private void mouseLeave(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            label.FontSize = int.Parse(FindResource("not_over_size").ToString());
            label.Foreground = (Brush)new BrushConverter().ConvertFromString(FindResource("not_over_color").ToString());
        }
        void refreshUnitsdata(object sender, RoutedEventArgs e)
        {
            BL.IBL bl = BL.FactorySingleton.Instance;

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

        void UnitsResetFilters(object sender, RoutedEventArgs e)
        {
            AreaComboBox.SelectedIndex = 0;
            SubAreaComboBox.SelectedIndex = 0;
            TypeComboBox.SelectedIndex = 0;
            searchTextBox.Text = "";
            refreshUnitsdata(sender, e);
        }

        void refreshdata2()
        {
            BL.IBL bl = BL.FactorySingleton.Instance;
            //OrderDataGrid.ItemsSource = bl.getHostsOrders(myhost);
                                    

        }

        void UpdateUnit(object sender, RoutedEventArgs e)
        {
            
            if (UnitsDataGrid.SelectedItems.Count > 1)
            {
                    MessageBox.Show("error cannot updated more than one unit at a time", "EROOR", MessageBoxButton.OK,
                                    MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
            }
            else
            {
                dynamic a = UnitsDataGrid.SelectedItem;
                new Unit_window(a.HostingUnitKey).ShowDialog();
            }
        }
        void DeleteUnit(object sender, RoutedEventArgs e)
        {
            if (UnitsDataGrid.SelectedItems.Count > 1)
            {
                MessageBox.Show("error cannot updated more than one unit at a time", "EROOR", MessageBoxButton.OK,
                                MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
            }
            else
            {
                dynamic a = UnitsDataGrid.SelectedItem;
                string b = a.ToString().Trim(new Char[] { ' ', '{', '}' });
               b= b.Replace(" ", "");
                b = b.Replace(",", ", ");
               
                MessageBoxResult result = MessageBox.Show(b, "אישור מחיקה", MessageBoxButton.YesNo,
                                                     MessageBoxImage.Question, MessageBoxResult.No);
                if(result.ToString() == "Yes")
                {
                    try
                    {
                        BL.IBL bl = BL.FactorySingleton.Instance;
                        bl.deleteHostingUnit(a.HostingUnitKey);
                        refreshUnitsdata(sender, e);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "EROOR", MessageBoxButton.OK,
                                        MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                    }
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            new Unit_window().ShowDialog();
        }
    }
}
