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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfPL.windos;

namespace WpfPL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Uri dictUri = new Uri(@"/Resources/Languages/HE_STRINGS.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(dictUri) as ResourceDictionary;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Owner_screen().Show();
            //new Login_Window().ShowDialog();
            //new Host_Window(new BE.Host()
            //{
            //    HostID = 10000002,
            //    PrivateName = "Chna",
            //    FamilyName = "Esterzon",
            //    FhoneNumber = "05276140977",
            //    MailAddress = "bb@b.b",
            //    BankBranch = new BE.BankBranch()
            //    {
            //        BankNumber = 123,
            //        BankName = BankNames.Hapoalim,
            //        BranchNumber = 765,
            //        BranchAddress = "ggg",
            //        BranchCity = "jerusalem"
            //    },
            //    BankAccountNumber = 2468,
            //    CollectionClearance = false,
            //}, true).ShowDialog();

        }

       
       }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Controls.Primitives;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace WpfPL
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        string strArea = "Select area";
//        string strSubArea = "Select sub area";
//        string strType = "Select type";
//        public MainWindow()
//        {
//            InitializeComponent();
//            Uri dictUri = new Uri(@"/Resources/Languages/EN_STRINGS.xaml", UriKind.Relative);
//            ResourceDictionary resourceDict = Application.LoadComponent(dictUri) as ResourceDictionary;
//            Uri uri = new Uri(@"/Resources/images/nof.jpg", UriKind.Relative);


//            CBarea.Items.Add(strArea);
//            CBarea.SelectedIndex = 0;
//            CBsubArea.Items.Add(strSubArea);
//            CBsubArea.SelectedIndex = 0;
//            CBtype.Items.Add(strType);
//            CBtype.SelectedIndex = 0;
//            CBarea.DropDownOpened += CBopened;
//            CBarea.DropDownClosed += CBclosed;
//            CBarea.SelectionChanged += cbAreaChanged;
//            CBsubArea.DropDownOpened += CBopened;
//            CBsubArea.DropDownClosed += CBclosed;
//            CBtype.DropDownOpened += CBopened;
//            CBtype.DropDownClosed += CBclosed;
//            CBPool.ItemsSource = Enum.GetValues(typeof(ThreeChoice));
//            CBPool.SelectedIndex = 0;
//            CBJacuzzi.ItemsSource = Enum.GetValues(typeof(ThreeChoice));
//            CBJacuzzi.SelectedIndex = 0;
//            CBGarden.ItemsSource = Enum.GetValues(typeof(ThreeChoice));
//            CBGarden.SelectedIndex = 0;
//            CBChildrensAttractions.ItemsSource = Enum.GetValues(typeof(ThreeChoice));
//            CBChildrensAttractions.SelectedIndex = 0;
//            CBwifi.ItemsSource = Enum.GetValues(typeof(ThreeChoice));
//            CBwifi.SelectedIndex = 0;
//            CBaccessibility.ItemsSource = Enum.GetValues(typeof(ThreeChoice));
//            CBaccessibility.SelectedIndex = 0;
//            CBMeals.ItemsSource = Enum.GetValues(typeof(meals));
//            CBMeals.SelectedIndex = 0;
//            CBspecialMmeal.ItemsSource = Enum.GetValues(typeof(special_meal));
//            CBspecialMmeal.SelectedIndex = 0;
//            CBMeals.SelectionChanged += CBmealsCanged;
//            Next.MouseDown += changePage;
//            Back2.MouseDown += changePage;
//            Next2.MouseDown += changePage;
//            Back3.MouseDown += changePage;
//            send.MouseDown += changePage;
//            //_datePicker1.BlackoutDates.Add(new CalendarDateRange(new DateTime(2010, 1, 1), DateTime.Today));
//            _datePicker1.DisplayDateStart = DateTime.Today;
//            _datePicker1.DisplayDateEnd = DateTime.Today.AddMonths(11);
//            _datePicker2.DisplayDateStart = DateTime.Today;
//            _datePicker2.DisplayDateEnd = DateTime.Today.AddMonths(11);
//            _datePicker2.SelectedDateChanged += datePicker2_SelectedDateChanged;
//            cmdUp.Click += cmdUp_Click;
//            cmdDown.Click += cmdDown_Click;
//            cmdUp2.Click += cmdUp_Click;
//            cmdDown2.Click += cmdDown_Click;
//            TBfname.MouseDoubleClick += tbmouseClick;
//            TBlname.MouseDoubleClick += tbmouseClick;
//            TBmail.MouseDoubleClick += tbmouseClick;
//            TBfname.LostFocus += TBchanged;
//            TBlname.LostFocus += TBchanged;
//            TBmail.LostFocus += TBchanged;
//            txtNum.TextChanged += txtNumCanged;
//            Next.MouseEnter += Next_MouseEnter;
//            Next.MouseLeave += Next_MouseLeave;
//            Next2.MouseEnter += Next_MouseEnter;
//            Next2.MouseLeave += Next_MouseLeave;
//            backIcon2.MouseEnter += Next_MouseEnter;
//            backIcon2.MouseLeave += Next_MouseLeave;
//            backIcon3.MouseEnter += Next_MouseEnter;
//            backIcon2.MouseLeave += Next_MouseLeave;
//            send.MouseEnter += Next_MouseEnter;
//            send.MouseLeave += Next_MouseLeave;
//            LBlogin.MouseEnter += loginEnter;
//            LBlogin.MouseLeave += loginLeave;
//            LBlogin.MouseDown += loginClick;
//            //  BE.GuestRequest guestRequest = new BE.GuestRequest();
//        }

//        private void loginClick(object sender, MouseButtonEventArgs e)
//        {
//            new windos.Login_Window().ShowDialog();
//        }

//        private void loginLeave(object sender, MouseEventArgs e)
//        {
//            LBlogin.Foreground = new BrushConverter().ConvertFromString("#FFC6C2C2") as Brush;
//        }

//        private void loginEnter(object sender, MouseEventArgs e)
//        {
//            LBlogin.Foreground = Brushes.White;
//        }

//        private void txtNumCanged(object sender, TextChangedEventArgs e)
//        {
//            LBerror2.Content = "";
//        }

//        private void TBchanged(object sender, RoutedEventArgs e)
//        {
//            TextBox t = sender as TextBox;
//            if (t.Text == "")
//            {
//                if (t.Name == "TBfname")
//                    t.Text = "Enter your first name";
//                if (t.Name == "TBlname")
//                    t.Text = "Enter your last name";
//                if (t.Name == "TBmail")
//                {
//                    t.Text = "Enter your mail address";
//                }
//            }
//        }


//        private void tbmouseClick(object sender, MouseButtonEventArgs e)
//        {
//            TextBox t = sender as TextBox;
//            t.SelectAll();
//        }

//        private void cmdUp_Click(object sender, RoutedEventArgs e)
//        {
//            Button b = sender as Button;
//            if (b.Name == "cmdUp")
//                txtNum.Text = (int.Parse(txtNum.Text.ToString()) + 1).ToString();
//            else
//                txtNum2.Text = (int.Parse(txtNum2.Text.ToString()) + 1).ToString();

//        }

//        private void cmdDown_Click(object sender, RoutedEventArgs e)
//        {
//            Button b = sender as Button;
//            if (b.Name == "cmdDown" && int.Parse(txtNum.Text.ToString()) > 0)
//                txtNum.Text = (int.Parse(txtNum.Text.ToString()) - 1).ToString();
//            if (b.Name == "cmdDown2" && int.Parse(txtNum2.Text.ToString()) > 0)
//                txtNum2.Text = (int.Parse(txtNum2.Text.ToString()) - 1).ToString();
//        }
//        private void CBmealsCanged(object sender, SelectionChangedEventArgs e)
//        {
//            if (CBMeals.SelectedIndex != 0 && CBMeals.SelectedIndex != -1)
//                CBspecialMmeal.IsEnabled = true;
//            else
//            {
//                CBspecialMmeal.IsEnabled = false;
//                CBspecialMmeal.SelectedIndex = 0;
//            }
//        }

//        private void datePicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
//        {
//            if (_datePicker1.SelectedDate != null)
//            {

//                _datePicker2.SelectedDate = null;
//                _datePicker2.IsEnabled = true;

//                DateTime a = (DateTime)_datePicker1.SelectedDate;
//                _datePicker2.BlackoutDates.Add(new CalendarDateRange(new DateTime(2010, 1, 1), a));
//            }
//        }



//        private void changePage(object sender, MouseButtonEventArgs e)
//        {


//            Viewbox v = sender as Viewbox;
//            if (v.Name.ToString() == "Next")
//            {
//                LBerror.Content = "";
//                if (checkpage(1))
//                    Dispatcher.BeginInvoke((Action)(() => TabControl.SelectedIndex += 1));
//            }
//            if (v.Name.ToString() == "Next2")
//            {
//                LBerror2.Content = "";
//                if (checkpage(2))
//                    Dispatcher.BeginInvoke((Action)(() => TabControl.SelectedIndex += 1));
//            }
//            if (v.Name.ToString() == "send")
//            {
//                LBerror3.Content = "";
//                if (checkpage(3))
//                {

//                    BL.IBL bl = BL.FactorySingleton.Instance;
//                    bl.addGuestRequest(new BE.GuestRequest()
//                    {
//                        PrivateName = TBfname.Text,
//                        FamilyName = TBlname.Text,
//                        MailAddress = TBmail.Text,

//                        EntryDate = (DateTime)_datePicker1.SelectedDate,
//                        ReleaseDate = (DateTime)_datePicker2.SelectedDate,
//                        Area = (CBarea.SelectedItem.ToString().Contains("Select") ? Areas.All : (Areas)CBarea.SelectedItem),
//                        SubArea = (CBsubArea.SelectedItem.ToString().Contains("Select") ? SubAreas.All : (SubAreas)CBsubArea.SelectedItem),
//                        Type = (CBtype.SelectedItem.ToString().Contains("Select") ? Types.All : (Types)CBtype.SelectedItem),
//                        Adults = int.Parse(txtNum.Text),
//                        Children = int.Parse(txtNum2.Text),
//                        Pool = (ThreeChoice)CBPool.SelectedItem,
//                        Jacuzzi = (ThreeChoice)CBJacuzzi.SelectedItem,
//                        Garden = (ThreeChoice)CBGarden.SelectedItem,
//                        ChildrensAttractions = (ThreeChoice)CBChildrensAttractions.SelectedItem,
//                        wifi = (ThreeChoice)CBwifi.SelectedItem,
//                        accessibility = (ThreeChoice)CBaccessibility.SelectedItem,
//                        Meals = (meals)CBMeals.SelectedItem,
//                        specialMmeal = (special_meal)CBspecialMmeal.SelectedItem,
//                    });
//                    MessageBox.Show("Request successfully sent");
//                    new MainWindow().Show();
//                    this.Close();
//                }

//            }

//            if (v.Name.Contains("Back"))
//                Dispatcher.BeginInvoke((Action)(() => TabControl.SelectedIndex -= 1));
//        }

//        private void cbAreaChanged(object sender, SelectionChangedEventArgs e)
//        {
//            if (CBarea.SelectedIndex != 0 && CBarea.SelectedIndex != -1)
//                CBsubArea.IsEnabled = true;
//            else
//            {
//                CBsubArea.IsEnabled = false;
//                CBsubArea.SelectedIndex = 0;
//            }

//        }

//        private void CBclosed(object sender, EventArgs e)
//        {
//            ComboBox comboBox = sender as ComboBox;
//            if (comboBox.SelectedIndex == -1)
//            {
//                comboBox.ItemsSource = null;
//                if (comboBox.Name == "CBarea")
//                {
//                    comboBox.Items.Insert(0, "Select area");
//                    comboBox.SelectedIndex = 0;
//                    return;
//                }
//                if (comboBox.Name == "CBsubArea")
//                {
//                    comboBox.Items.Insert(0, "Select sub area");
//                    comboBox.SelectedIndex = 0;
//                    return;
//                }
//                if (comboBox.Name == "CBtype")
//                {
//                    comboBox.Items.Insert(0, "Select type");
//                    comboBox.SelectedIndex = 0;
//                }
//            }
//        }

//        private void CBopened(object sender, EventArgs e)
//        {
//            ComboBox comboBox = sender as ComboBox;
//            if (comboBox.SelectedItem == "Select area")
//            {
//                comboBox.Items.RemoveAt(0);
//                comboBox.ItemsSource = Enum.GetValues(typeof(Areas));
//                return;
//            }
//            if (comboBox.SelectedItem == "Select sub area")
//            {
//                comboBox.Items.RemoveAt(0);
//                int valArea = (int)Enum.Parse(typeof(Areas), CBarea.SelectedItem.ToString());
//                comboBox.ItemsSource = from i in Enum.GetValues(typeof(SubAreas)).Cast<SubAreas>()
//                                       where (int)i == 0 || ((int)i >= valArea * 100 && (int)i < 100 * (valArea + 1))
//                                       select i;
//                return;
//            }
//            if (comboBox.SelectedItem == "Select type")
//            {
//                comboBox.Items.RemoveAt(0);
//                comboBox.ItemsSource = Enum.GetValues(typeof(Types));
//                return;
//            }
//        }
//        private void datePicker2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
//        {
//            if (_datePicker2.SelectedDate != null)
//            {
//                LBerror.Content = "";
//                return;
//            }
//            FieldInfo fiTextBox = typeof(DatePicker).GetField("_textBox", BindingFlags.Instance | BindingFlags.NonPublic);

//            if (fiTextBox != null)
//            {
//                DatePickerTextBox dateTextBox =
//                 (DatePickerTextBox)fiTextBox.GetValue(_datePicker2);

//                if (dateTextBox != null)
//                {
//                    PropertyInfo piWatermark = dateTextBox.GetType()
//                     .GetProperty("Watermark", BindingFlags.Instance | BindingFlags.NonPublic);

//                    if (piWatermark != null)
//                    {
//                        piWatermark.SetValue(dateTextBox, "Select relese date", null);
//                    }
//                }
//            }
//        }


//        private void Next_MouseEnter(object sender, MouseEventArgs e)
//        {
//            Viewbox v = sender as Viewbox;
//            if (v != null)
//            {
//                v.Width = 75;
//                v.Height = 150;
//            }
//        }

//        private void Next_MouseLeave(object sender, MouseEventArgs e)
//        {
//            Viewbox v = sender as Viewbox;
//            if (v != null)
//            {
//                v.Width = 70;
//                v.Height = 140;
//            }
//        }

//        private void ComboBox_MouseEnter(object sender, MouseEventArgs e)
//        {
//            ComboBox a = sender as ComboBox;
//            a.Background = Brushes.Red;
//        }

//        public bool checkpage(int page)
//        {
//            BL.IBL bl = BL.FactorySingleton.Instance;
//            if (page == 1)
//            {
//                if (_datePicker1.SelectedDate == null || _datePicker2.SelectedDate == null)
//                {
//                    LBerror.Content = "Please select a check-in and check-out date to proceed with your booking";
//                    return false;
//                }
//            }
//            if (page == 2)
//            {
//                if (txtNum.Text.ToString() == "0")
//                {
//                    LBerror2.Content = "A unit cannot be booked without at least one adult";
//                    return false;
//                }
//            }
//            if (page == 3)
//            {
//                try
//                {
//                    bl.IsValidName(TBfname.Text.ToString(), "first");
//                    bl.IsValidName(TBlname.Text.ToString(), "last");
//                    bl.IsValidEmail(TBmail.Text.ToString());

//                }
//                catch (FormatException e)
//                {
//                    if (e.Message.Contains("mail") || e.Message.Contains("דואר"))
//                        LBerror3.Content = "Mail address is not valid";
//                    else
//                        LBerror3.Content = e.Message;
//                    return false;
//                }
//                if (!(bool)CBconfirm.IsChecked)
//                {
//                    LBerror3.Content = "Please confirm receiving emails";
//                    return false;
//                }
//            }

//            return true;
//        }
//    }

//}

