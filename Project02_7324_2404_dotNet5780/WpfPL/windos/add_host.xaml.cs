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
    /// Interaction logic for add_host.xaml
    /// </summary>
    public partial class add_host : Window
    {
        BL.IBL bL;
        List<BE.BankBranch> branches;
        BE.Host Host;
        public add_host(BE.Host host = null)
        {
            bL = BL.FactorySingleton.Instance;
            branches = new List<BE.BankBranch>();
            Host = host;
            InitializeComponent();
            try
            {
                branches = bL.getBankBranchs().ToList();
            }
            catch
            {
                MessageBox.Show("Unable to load data Check Internet connection", "EROOR", MessageBoxButton.OK,
                                           MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
                this.Close();
            }
            if (host == null)
            {
                bankCB.ItemsSource = branches.Select(b => b.BankName).Distinct();
                BranchCB.IsEnabled = false;
                Button.Content = "Add";

            }
            else
            {
                nameTB.Text = Host.PrivateName;
                nameTB.IsReadOnly = true;
                fNameTB.Text = host.FamilyName;
                fNameTB.IsReadOnly = true;
                IDTB.Text = Host.HostID.ToString();
                IDTB.IsReadOnly = true;
                phoneTB.Text = Host.FhoneNumber.ToString();
                EmailTB.Text = Host.MailAddress;
                bankCB.Items.Add(Host.BankBranch.BankName);
                bankCB.SelectedIndex = 0;
                BranchCB.Items.Add(new { Host.BankBranch.BranchNumber, Host.BankBranch.BranchAddress, Host.BankBranch.BranchCity });
                BranchCB.SelectedIndex = 0;
                AccountTB.Text = Host.BankAccountNumber.ToString();
                ClearanceTB.IsChecked = Host.CollectionClearance;
                Button.Content = "Update";
            }

            bankCB.SelectionChanged += bankSelectionChanged;
            bankCB.DropDownOpened += bankCBOpened;
            bankCB.DropDownClosed += bankCBClosed;

            //BranchCB.SelectionChanged += BranchSelectionChanged;
            BranchCB.DropDownOpened += BranchCBOpened;
            BranchCB.DropDownClosed += BranchCBClosed;

            cancelBT.Click += cancel;
            Button.Click += ButtonClick;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            error.Content = "";
            try
            {
                BL.IBL bl = BL.FactorySingleton.Instance;
                bl.IsValidName(nameTB.Text, "first");
                bl.IsValidName(fNameTB.Text, "last");
                bl.IsValidEmail(EmailTB.Text);
            }
            catch (FormatException ex)
            {
                if (ex.Message.Contains("mail") || ex.Message.Contains("דואר"))
                    error.Content = "Mail address is not valid";
                else
                    error.Content = ex.Message;
            }



            if (error.Content == "" && bankCB.SelectedIndex == -1)
                error.Content = "error must choose a Bank";
            if (error.Content == "" && BranchCB.SelectedIndex == -1)
                error.Content = "error must choose a Branch";
            if (error.Content == "" && bankCB.SelectedIndex == -1)
                try
                {
                    if (int.Parse(AccountTB.Text) <= 0)
                        error.Content = "Account number must be \n a real number";
                }
                catch (Exception)
                {
                    error.Content = "Account number must be \n a real number";
                }
            if (error.Content == "" && bankCB.SelectedIndex == -1)
                try
                {
                    if (int.Parse(phoneTB.Text) <= 0)
                        error.Content = "phone number must be \n a real number";
                }
                catch (Exception)
                {
                    error.Content = "phone number must be \n a real number";
                }
            if (error.Content == "")
            {
                if (Host != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to update the unit details", "update Confirmation", MessageBoxButton.YesNo,
                                                            MessageBoxImage.Question, MessageBoxResult.No);
                    if (result.ToString() == "Yes")
                    {
                        try
                        {
                            BL.IBL bl = BL.FactorySingleton.Instance;
                            Host.PrivateName = nameTB.Text;
                            Host.FamilyName = fNameTB.Text;
                            Host.MailAddress = EmailTB.Text;
                            Host.BankAccountNumber = int.Parse(AccountTB.Text);
                            dynamic a = BranchCB.SelectedItem;
                            Host.BankBranch = branches.Find(i => i.BranchNumber == a.BranchNumber && i.BranchAddress == a.BranchAddress);
                            Host.CollectionClearance = ClearanceTB.IsChecked == null ? false : (bool)ClearanceTB.IsChecked;

                            bl.updateHost(Host);
                            MessageBox.Show("Hosting host details successfully updated", "", MessageBoxButton.OK,
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
                    dynamic a = BranchCB.SelectedItem;
                    Host = new BE.Host()
                    {
                        HostID = int.Parse(IDTB.Text),
                        PrivateName = nameTB.Text,
                        FamilyName = fNameTB.Text,
                        MailAddress = EmailTB.Text,
                        BankAccountNumber = int.Parse(AccountTB.Text),
                        BankBranch = branches.Find(i => i.BranchNumber == a.BranchNumber && i.BranchAddress == a.BranchAddress),
                        CollectionClearance = ClearanceTB.IsChecked == null ? false : (bool)ClearanceTB.IsChecked,
                        numOrders = 0,
                        numUnits = 0,
                        passwordeHash = 11
                    };
                    try
                    {
                        BL.IBL bl = BL.FactorySingleton.Instance;
                        bl.addHost(Host);
                        MessageBox.Show("Host successfully added", "", MessageBoxButton.OK,
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

        }
        private void cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BranchCBClosed(object sender, EventArgs e)
        {
            if (BranchCB.SelectedIndex == -1 && Host != null)
            {
                try
                {
                    BranchCB.ItemsSource = null;
                }
                catch (Exception)
                {
                    BranchCB.Items.Clear();
                }
                BranchCB.Items.Add(new { Host.BankBranch.BranchNumber, Host.BankBranch.BranchAddress, Host.BankBranch.BranchCity });
            }
        }

        private void BranchCBOpened(object sender, EventArgs e)
        {
            if (Host == null||BranchCB.SelectedItem == (new { Host.BankBranch.BranchNumber, Host.BankBranch.BranchAddress, Host.BankBranch.BranchCity }).ToString())
            {
                try
                {
                    BranchCB.ItemsSource = null;
                }
                catch (Exception)
                {
                    BranchCB.Items.Clear();
                }
                BranchCB.ItemsSource = from item in branches
                                       where item.BankName == bankCB.SelectedItem.ToString()
                                       select new { item.BranchNumber, item.BranchAddress, item.BranchCity };
            }
        }

        private void bankCBClosed(object sender, EventArgs e)
        {
            if (bankCB.SelectedIndex == -1 && Host != null)
            {
                try
                {
                    bankCB.ItemsSource = null;
                }
                catch (Exception)
                {
                    bankCB.Items.Clear();
                }
                bankCB.Items.Add(Host.BankBranch.BankName);
            }
        }
        private void bankCBOpened(object sender, EventArgs e)
        {
            if (Host== null || bankCB.SelectedItem == Host.BankBranch.BankName)
            {
                try
                {
                    bankCB.ItemsSource = null;
                }
                catch (Exception)
                {
                    bankCB.Items.Clear();
                }
                bankCB.ItemsSource = branches.Select(b => b.BankName).Distinct();
            }
        }
        private void bankSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bankCB.SelectedIndex != -1)
            {
                try
                {
                    BranchCB.ItemsSource = null;
                }
                catch (Exception)
                {
                    BranchCB.Items.Clear();
                }
                BranchCB.ItemsSource = from item in branches
                                       where item.BankName == bankCB.SelectedItem.ToString()
                                       select new { item.BranchNumber, item.BranchAddress, item.BranchCity };
                BranchCB.IsEnabled = true;
            }

        }
    }
}
