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

namespace WpfPL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string strArea = "Select area";
        string strSubArea = "Select sub area";
        string strType = "Select type";
        public MainWindow()
        {
            InitializeComponent();
            Uri dictUri = new Uri(@"/Resources/Languages/EN_STRINGS.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(dictUri) as ResourceDictionary;
            Uri uri = new Uri(@"/Resources/images/nof.jpg", UriKind.Relative);


            CBarea.Items.Add(strArea);
            CBarea.SelectedIndex = 0;
            CBsubArea.Items.Add(strSubArea);
            CBsubArea.SelectedIndex = 0;
            CBtype.Items.Add(strType);
            CBtype.SelectedIndex = 0;
            CBarea.DropDownOpened += CBopened;
            CBarea.DropDownClosed += CBclosed;
            CBarea.SelectionChanged += cbAreaChanged;
            CBsubArea.DropDownOpened += CBopened;
            CBsubArea.DropDownClosed += CBclosed;
            CBtype.DropDownOpened += CBopened;
            CBtype.DropDownClosed += CBclosed;
            CBPool.ItemsSource = Enum.GetValues(typeof(ThreeChoice));
            CBPool.SelectedIndex = 0;
            CBJacuzzi.ItemsSource = Enum.GetValues(typeof(ThreeChoice));
            CBJacuzzi.SelectedIndex = 0;
            CBGarden.ItemsSource = Enum.GetValues(typeof(ThreeChoice));
            CBGarden.SelectedIndex = 0;
            CBChildrensAttractions.ItemsSource = Enum.GetValues(typeof(ThreeChoice));
            CBChildrensAttractions.SelectedIndex = 0;
            CBwifi.ItemsSource = Enum.GetValues(typeof(ThreeChoice));
            CBwifi.SelectedIndex = 0;
            CBaccessibility.ItemsSource = Enum.GetValues(typeof(ThreeChoice));
            CBaccessibility.SelectedIndex = 0;
            CBMeals.ItemsSource = Enum.GetValues(typeof(meals));
            CBMeals.SelectedIndex = 0;
            CBspecialMmeal.ItemsSource = Enum.GetValues(typeof(special_meal));
            CBspecialMmeal.SelectedIndex = 0;
            CBMeals.SelectionChanged += CBmealsCanged;
            Next.MouseDown += changePage;
            Back2.MouseDown += changePage;
            //_datePicker1.BlackoutDates.Add(new CalendarDateRange(new DateTime(2010, 1, 1), DateTime.Today));
            _datePicker1.DisplayDateStart = DateTime.Today;
            _datePicker1.DisplayDateEnd = DateTime.Today.AddMonths(11);
            _datePicker2.DisplayDateStart = DateTime.Today;
            _datePicker2.DisplayDateEnd = DateTime.Today.AddMonths(11);
            _datePicker2.SelectedDateChanged += datePicker2_SelectedDateChanged;
        }

        private void CBmealsCanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBMeals.SelectedIndex != 0 && CBMeals.SelectedIndex != -1)
                CBspecialMmeal.IsEnabled = true;
            else
            {
                CBspecialMmeal.IsEnabled = false;
                CBspecialMmeal.SelectedIndex = 0;
            }
        }

        private void datePicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_datePicker1.SelectedDate != null)
            {

                _datePicker2.SelectedDate = null;
                _datePicker2.IsEnabled = true;

                DateTime a = (DateTime)_datePicker1.SelectedDate;
                _datePicker2.BlackoutDates.Add(new CalendarDateRange(new DateTime(2010, 1, 1), a));
            }
        }

        //private void plusMinus(object sender, RoutedEventArgs e)
        //{
        //    Button b = sender as Button;
        //    if (b.Name == "AdultsPlusButton")
        //    {
        //        LBNumAdults.Content = (int.Parse(LBNumAdults.Content.ToString()) + 1).ToString();
        //        return;
        //    }
        //    if(b.Name == "AdultsMinusButton" && int.Parse(LBNumAdults.Content.ToString()) >0)
        //    {
        //        (LBNumAdults.Content = int.Parse(LBNumAdults.Content.ToString()) - 1).ToString();
        //        return;
        //    }
        //}

        private void changePage(object sender, MouseButtonEventArgs e)
        {
            Viewbox v = sender as Viewbox;
            if (v.Name.Contains("Next"))
                Dispatcher.BeginInvoke((Action)(() => TabControl.SelectedIndex += 1));
            if (v.Name.Contains("Back"))
                Dispatcher.BeginInvoke((Action)(() => TabControl.SelectedIndex -= 1));
        }

        private void cbAreaChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBarea.SelectedIndex != 0 && CBarea.SelectedIndex != -1)
                CBsubArea.IsEnabled = true;
            else
            {
                CBsubArea.IsEnabled = false;
                CBsubArea.SelectedIndex = 0;
            }

        }

        private void CBclosed(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedIndex == -1)
            {
                comboBox.ItemsSource = null;
                if (comboBox.Name == "CBarea")
                {
                    comboBox.Items.Insert(0, "Select area");
                    comboBox.SelectedIndex = 0;
                    return;
                }
                if (comboBox.Name == "CBsubArea")
                {
                    comboBox.Items.Insert(0, "Select sub area");
                    comboBox.SelectedIndex = 0;
                    return;
                }
                if (comboBox.Name == "CBtype")
                {
                    comboBox.Items.Insert(0, "Select type");
                    comboBox.SelectedIndex = 0;
                }
            }
        }

        private void CBopened(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedItem == "Select area")
            {
                comboBox.Items.RemoveAt(0);
                comboBox.ItemsSource = Enum.GetValues(typeof(Areas));
                return;
            }
            if (comboBox.SelectedItem == "Select sub area")
            {
                comboBox.Items.RemoveAt(0);
                int valArea = (int)Enum.Parse(typeof(Areas), CBarea.SelectedItem.ToString());
                comboBox.ItemsSource = from i in Enum.GetValues(typeof(SubAreas)).Cast<SubAreas>()
                                       where (int)i == 0 || ((int)i >= valArea * 100 && (int)i < 100 * (valArea + 1))
                                       select i;
                return;
            }
            if (comboBox.SelectedItem == "Select type")
            {
                comboBox.Items.RemoveAt(0);
                comboBox.ItemsSource = Enum.GetValues(typeof(Types));
                return;
            }
        }
        private void datePicker2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_datePicker2.SelectedDate != null) return;

            FieldInfo fiTextBox = typeof(DatePicker)
              .GetField("_textBox", BindingFlags.Instance | BindingFlags.NonPublic);

            if (fiTextBox != null)
            {
                DatePickerTextBox dateTextBox =
                 (DatePickerTextBox)fiTextBox.GetValue(_datePicker2);

                if (dateTextBox != null)
                {
                    PropertyInfo piWatermark = dateTextBox.GetType()
                     .GetProperty("Watermark", BindingFlags.Instance | BindingFlags.NonPublic);

                    if (piWatermark != null)
                    {
                        piWatermark.SetValue(dateTextBox, "Select relese date", null);
                    }
                }
            }
        }





        /// <summary>
        /// changes the date-picker calender size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



        private void Next_MouseEnter(object sender, MouseEventArgs e)
        {
            nextIcon.Foreground = Brushes.Black;
        }

        private void Next_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!Next.IsMouseOver)
            {
                nextIcon.Foreground = (Brush)new BrushConverter().ConvertFromString("White");
            }

        }

        private void ComboBox_MouseEnter(object sender, MouseEventArgs e)
        {
            ComboBox a = sender as ComboBox;
            a.Background = Brushes.Red;
        }
    }
}








