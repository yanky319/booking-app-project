using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for update_unit_window.xaml
    /// </summary>
    public partial class Unit_window : Window
    {
        bool isUpdate;
        int Key;
        BE.HostingUnit unit;
        public Unit_window(int key, bool isupdate = false)
        {
            InitializeComponent();
            isUpdate = isupdate;
            Key = key;
           
            Button.Click += ButtonClick;
            cancelBT.Click += cancel;
            if (isUpdate)
            {
                BL.IBL bl = BL.FactorySingleton.Instance;
                Button.Content = "Update";
                unit = bl.getHostingUnit(Key);
                pool.IsChecked = unit.Pool;
                Jacuzzi.IsChecked = unit.Jacuzzi;
                Garden.IsChecked = unit.Garden;
                attractions.IsChecked = unit.ChildrensAttractions;
                wifi.IsChecked = unit.wifi;
                accessibility.IsChecked = unit.accessibility;
                nameTB.Text = unit.HostingUnitName;
                AreaCB.Items.Add(unit.Area);
                AreaCB.SelectedIndex = 0;
                AreaCB.IsEnabled = false;
                SaraeCB.Items.Add(unit.SubArea);
                SaraeCB.SelectedIndex = 0;
                SaraeCB.IsEnabled = false;
                typeCB.Items.Add(unit.Type);
                typeCB.SelectedIndex = 0;
                typeCB.IsEnabled = false;
                NOB.Text = unit.num_beds.ToString();
            }
            else
            {
                Button.Content = "Add";
                AreaCB.ItemsSource = from item in Enum.GetValues(typeof(Areas)).Cast<Enum>()
                                     where item.ToString() != "All"
                                     select item;
                SaraeCB.IsEnabled = false;
                typeCB.ItemsSource = from item in Enum.GetValues(typeof(Types)).Cast<Enum>()
                                     where item.ToString() != "All"
                                     select item;
                NOB.Text = "0";
            }

            AreaCB.SelectionChanged += AreaChanged;
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            error.Content = "";
            try
            {
                BL.IBL bl = BL.FactorySingleton.Instance;
                bl.IsValidName(nameTB.Text, "hosting unit");
            }
            catch (FormatException ex)
            {
                error.Content = ex.Message;
            }
            if (error.Content == "" && AreaCB.SelectedIndex == -1)
                error.Content = "error must choose an Area";
            if (error.Content == "" && SaraeCB.SelectedIndex == -1)
                error.Content = "error must choose a Sub Area";
            if (error.Content == "" && typeCB.SelectedIndex == -1)
                error.Content = "error must choose a type";

            if (error.Content == "")
                try
                {
                    if (int.Parse(NOB.Text) <= 0)
                        error.Content = "Number of beds must be more than zero";
                }
                catch
                {
                    error.Content = "Number of beds must be \n a real number";
                }

            if (error.Content == "")
            {
                if (isUpdate)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to update the unit details", "update Confirmation", MessageBoxButton.YesNo,
                                                            MessageBoxImage.Question, MessageBoxResult.No);
                    if (result.ToString() == "Yes")
                    {
                        try
                        {
                            BL.IBL bl = BL.FactorySingleton.Instance;
                            unit.HostingUnitName = nameTB.Text;
                            unit.num_beds = int.Parse(NOB.Text);
                            unit.Pool = pool == null ? false : (bool)pool.IsChecked;
                            unit.Jacuzzi = Jacuzzi == null ? false : (bool)Jacuzzi.IsChecked;
                            unit.Garden = Garden == null ? false : (bool)Garden.IsChecked;
                            unit.ChildrensAttractions = attractions == null ? false : (bool)attractions.IsChecked;
                            unit.wifi = wifi == null ? false : (bool)wifi.IsChecked;
                            unit.accessibility = accessibility == null ? false : (bool)accessibility.IsChecked;
                            bl.updateHostingUnit(unit);
                            MessageBox.Show("Hosting unit details successfully updated", "", MessageBoxButton.OK,
                                           MessageBoxImage.None, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                        }
                        catch
                        {
                            MessageBox.Show("There was an error in the process please try again later", "EROOR", MessageBoxButton.OK,
                                           MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                        }
                        finally
                        {
                            this.Close();
                        }
                    }
                }
                else
                {
                    unit = new BE.HostingUnit()
                    {

                        HostID = Key,
                        HostingUnitName = nameTB.Text,

                        Area = (Areas)AreaCB.SelectedItem,
                        SubArea = (SubAreas)AreaCB.SelectedItem,
                        Type = (Types)AreaCB.SelectedItem,
                        num_beds = int.Parse(NOB.Text),
                        Pool = pool == null ? false : (bool)pool.IsChecked,
                        Jacuzzi = Jacuzzi == null ? false : (bool)Jacuzzi.IsChecked,
                        Garden = Garden == null ? false : (bool)Garden.IsChecked,
                        ChildrensAttractions = attractions == null ? false : (bool)attractions.IsChecked,
                        wifi = wifi == null ? false : (bool)wifi.IsChecked,
                        accessibility = accessibility == null ? false : (bool)accessibility.IsChecked
                    };
                    try
                    {
                        BL.IBL bl = BL.FactorySingleton.Instance;
                        bl.addHostingUnit(unit);
                        MessageBox.Show("Hosting unit successfully added", "", MessageBoxButton.OK,
                                               MessageBoxImage.None, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                    }
                    catch(Exception t)
                    {
                        MessageBox.Show(t.Message);
                        //MessageBox.Show("There was an error in the process please try again later", "EROOR", MessageBoxButton.OK,
                        //               MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                    }
                    finally
                    {
                        this.Close();
                    }
                }
            }
        }

        private void AreaChanged(object sender, SelectionChangedEventArgs e)
        {
            SaraeCB.ItemsSource = null;
            int valArea = (int)Enum.Parse(typeof(Areas), AreaCB.SelectedItem.ToString());
            SaraeCB.ItemsSource = from i in Enum.GetValues(typeof(SubAreas)).Cast<SubAreas>()
                                  where ((int)i >= valArea * 100 && (int)i < 100 * (valArea + 1))
                                  select i;
            SaraeCB.IsEnabled = true;
        }
    }
}
