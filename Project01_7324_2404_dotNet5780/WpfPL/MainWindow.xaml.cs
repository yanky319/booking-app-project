using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
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

        private void AA_Click(object sender, RoutedEventArgs e)
        {
            //new Login_Window().ShowDialog();
            new Host_Window(new BE.Host()
            {
                HostID = 10000002,
                PrivateName = "Chna",
                FamilyName = "Esterzon",
                FhoneNumber = "05276140977",
                MailAddress = "bb@b.b",
                BankBranch = new BE.BankBranch()
                {
                    BankNumber = 123,
                    BankName = BankNames.Hapoalim,
                    BranchNumber = 765,
                    BranchAddress = "ggg",
                    BranchCity = "jerusalem"
                },
                BankAccountNumber = 2468,
                CollectionClearance = false,
            }).ShowDialog();

        }
    }

    //#region
    //AA.Click += AdjustWindowSize;
    //    [DllImport("user32.dll")]
    //private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    //[DllImport("user32.dll")]
    //private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    //private const int GWL_STYLE = -16;
    //private const int WS_MAXIMIZEBOX = 0x10000; //maximize button
    //private const int WS_MINIMIZEBOX = 0x20000; //minimize button



    //private IntPtr _windowHandle;
    //private void MainWindow_SourceInitialized(object sender, EventArgs e)
    //{
    //    _windowHandle = new WindowInteropHelper(this).Handle;

    //    //disable minimize button
    //    DisableMinimizeButton();
    //}

    //protected void DisableMinimizeButton()
    //{
    //    if (_windowHandle == IntPtr.Zero)
    //        throw new InvalidOperationException("The window has not yet been completely initialized");

    //    SetWindowLong(_windowHandle, GWL_STYLE, GetWindowLong(_windowHandle, GWL_STYLE) & ~WS_MAXIMIZEBOX);
    //}







    //private void AdjustWindowSize(object sender, RoutedEventArgs e)
    //{

    //    if (this.WindowState == WindowState.Maximized)
    //    {
    //        this.WindowState = WindowState.Normal;

    //    }
    //    else
    //    {
    //        this.WindowState = WindowState.Maximized;
    //    }
    //}
    ////private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    ////{
    ////    MessageBox.Show("AAAAAAA");
    ////    this.WindowState = WindowState.Minimized;
    ////}

    ////private void MaximizeButton_Click(object sender, RoutedEventArgs e)
    ////{
    ////    MessageBox.Show("AAAAAAA");
    ////    AdjustWindowSize();
    ////}

    ////private void AdjustWindowSize()
    ////{
    ////    MessageBox.Show("AAAAAAA");
    ////    if (this.WindowState == WindowState.Maximized)
    ////    {
    ////        this.WindowState = WindowState.Normal;

    ////    }
    ////    else
    ////    {
    ////        this.WindowState = WindowState.Maximized;
    ////    }
    ////}

    ////private void FakeTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
    ////{
    ////    if (e.ChangedButton == MouseButton.Left)
    ////    {
    ////        if (e.ClickCount == 2)
    ////        {
    ////            AdjustWindowSize();
    ////        }
    ////        else
    ////        {
    ////            Application.Current.MainWindow.DragMove();
    ////        }
    ////    }
    ////}
    //#endregion
}
