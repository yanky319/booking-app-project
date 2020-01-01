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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNet5780_03_7324_2404
{
    /// <summary>
    /// Interaction logic for HostingUnitUserControl.xaml
    /// public partial class HostingUnitUserControl : UserControl
    /// </summary>
    /// < parm name = CurrentHostingUnit > the Unit in this control </parm>
    /// < parm name = MyCalendar > the Calendar in the control (incloding marked out days)  </parm>
    /// < parm name = imageIndex >index of the pic visible  </parm>
    /// < parm name = vbImage > Viewbox for shoing the picturs </parm>
    /// < parm name = MyImage > the current picture  </parm>
    public partial class HostingUnitUserControl : UserControl
    {
        public HostingUnit CurrentHostingUnit { get; set; }
        private Calendar MyCalendar;
        int imageIndex;
        Viewbox vbImage;
        Image MyImage;

        /// <summary>
        /// ctor of the control
        /// </summary>
        /// <param name="unit"> the unit to represent</param>
        public HostingUnitUserControl(HostingUnit unit)
        {
            CurrentHostingUnit = unit;
            vbImage = new Viewbox();
            InitializeComponent();
            UserControlGrid.DataContext = CurrentHostingUnit;

            //set a Calendar to display
            MyCalendar = CreateCalendar();
            vbCalendar.Child = null; 
            vbCalendar.Child = MyCalendar;
            SetBlackOutDates();

            //set a picture to display
            imageIndex = 0;
            vbImage.Width = 150;
            vbImage.Height = 150;
            vbImage.Stretch = Stretch.Fill;
            UserControlGrid.Children.Add(vbImage);
            Grid.SetColumn(vbImage, 2);
            Grid.SetRow(vbImage, 0);
            MyImage = CreateViewImage();
            vbImage.Child = null;
            vbImage.Child = MyImage;

            //Register functions for events
            vbImage.MouseUp += vbImage_MouseUp;
            vbImage.MouseEnter += vbImage_MouseEnter;
            vbImage.MouseLeave += vbImage_MouseLeave;
        }

        /// <summary>
        /// Create's a Image for disply With our settings
        /// </summary>
        /// <returns>the Image </returns>
        private Image CreateViewImage()
        {
            Image dynamicImage = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@CurrentHostingUnit.Uris[imageIndex]);
            bitmap.EndInit();
            // Set Image.Source
            dynamicImage.Source = bitmap;
            // Add Image to Window
            return dynamicImage;
        }

        /// <summary>
        /// Create's a Calendar With our settings
        /// </summary>
        /// <returns>a new Calendar </returns>
        private Calendar CreateCalendar()
        {
            Calendar MonthlyCalendar = new Calendar();
            MonthlyCalendar.Name = "MonthlyCalendar";
            MonthlyCalendar.DisplayMode = CalendarMode.Month;
            MonthlyCalendar.SelectionMode = CalendarSelectionMode.SingleRange;
            MonthlyCalendar.IsTodayHighlighted = true;
            return MonthlyCalendar;
        }

        /// <summary>
        /// A function to perform when the event BtOrder.Click is raised
        /// marks the new order in the Calendar
        /// </summary>
        /// <param name="sender">the sender </param>
        /// <param name="e">event param's</param>
        private void BtOrder_Click(object sender, RoutedEventArgs e)
        {
            List<DateTime> myList = MyCalendar.SelectedDates.ToList();
            MyCalendar = CreateCalendar();
            vbCalendar.Child = null;
            vbCalendar.Child = MyCalendar;
            addCurrentList(myList);
            SetBlackOutDates();
        }

        /// <summary>
        /// Blocks the busy days on the calendar
        /// </summary>
        private void SetBlackOutDates()
        {
            foreach (DateTime date in CurrentHostingUnit.AllOrders)
            {
                MyCalendar.BlackoutDates.Add(new CalendarDateRange(date));
            }
        }

        /// <summary>
        /// Adds the selected days to the hosting unit's occupancy list
        /// </summary>
        /// <param name="tList">the list of selected days </param>
        private void addCurrentList(List<DateTime> tList)
        {
            foreach (DateTime d in tList)
            {
                CurrentHostingUnit.AllOrders.Add(d);
            }
        }

        /// <summary>
        /// A function to perform when the eventvbImage.MouseLeave is raised
        /// sets the size of the image
        /// </summary>
        /// <param name="sender">the sender </param>
        /// <param name="e">event param's</param>
        private void vbImage_MouseLeave(object sender, MouseEventArgs e)
        {
            vbImage.Width = 150;
            vbImage.Height = 150;
        }

        /// <summary>
        /// A function to perform when the event vbImage.MouseEnter is raised
        /// sets the size of the image
        /// </summary>
        /// <param name="sender">the sender </param>
        /// <param name="e">event param's</param>
        private void vbImage_MouseEnter(object sender, MouseEventArgs e)
        {
            vbImage.Width = this.Width / 3;
            vbImage.Height = this.Height;
        }

        /// <summary>
        /// A function to perform when the event vbImage.MouseUp is raised
        /// Replaces the image shoun
        /// </summary>
        /// <param name="sender">the sender </param>
        /// <param name="e">event param's</param>
        private void vbImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            vbImage.Child = null;
            imageIndex =
            (imageIndex + CurrentHostingUnit.Uris.Count - 1) % CurrentHostingUnit.Uris.Count;
            MyImage = CreateViewImage();
            vbImage.Child = MyImage;
        }


    }
}
