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
using System.Runtime.InteropServices;
using System.Windows.Interop;
namespace WpfPL.windos
{

    /// <summary>
    /// Interaction logic for Owner_Login.xaml
    /// </summary>
    public partial class Owner_Login_Window : Window
    {
        //protected override void OnSourceInitialized(EventArgs e)
        //{
        //    base.OnSourceInitialized(e);

        //    HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;

        //    if (hwndSource != null)
        //    {
        //        hwndSource.AddHook(HwndSourceHook);
        //    }

        //}

        //private bool allowClosing = false;

        //[DllImport("user32.dll")]
        //private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        //[DllImport("user32.dll")]
        //private static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        //private const uint MF_BYCOMMAND = 0x00000000;
        //private const uint MF_GRAYED = 0x00000001;

        //private const uint SC_CLOSE = 0xF060;

        //private const int WM_SHOWWINDOW = 0x00000018;
        //private const int WM_CLOSE = 0x10;

        //private IntPtr HwndSourceHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        //{
        //    switch (msg)
        //    {
        //        case WM_SHOWWINDOW:
        //            {
        //                IntPtr hMenu = GetSystemMenu(hwnd, false);
        //                if (hMenu != IntPtr.Zero)
        //                {
        //                    EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND | MF_GRAYED);
        //                }
        //            }
        //            break;
        //        case WM_CLOSE:
        //            if (!allowClosing)
        //            {
        //                handled = true;
        //            }
        //            break;
        //    }
        //    return IntPtr.Zero;
        //}

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public Owner_Login_Window()
        {
            InitializeComponent();
            //this.WindowStyle = WindowStyle.None;
            this.ResizeMode = ResizeMode.NoResize;
            this.Topmost = true;
            Loaded += Loade;
            NameTextBox.MouseDoubleClick += NameTextBox_MouseDoubleClick;
            NameTextBox.KeyDown += NameTextBox_KeyDown;
            PasswordPasswordBox.KeyDown += PasswordPasswordBox_KeyDown;
            CancelButton.Click += CancelButton_Click;
        }

        private void Loade(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NameTextBox_MouseDoubleClick(object sender, System.EventArgs e)
        {
            NameTextBox.SelectAll();
        }
        void NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter & (sender as TextBox).AcceptsReturn == false)
                PasswordPasswordBox.Focus();
        }
        void PasswordPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                LoginButton_Click(sender, e);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "yanky" && PasswordPasswordBox.Password == "moshe")
            {
                new Owner_screen().Show();
                Application.Current.MainWindow.Close();
                this.Close();
                
            }
            else
            {
                var bc = new BrushConverter();
                NameTextBox.Text = this.FindResource("Incorrect_login_information").ToString();
                NameTextBox.BorderBrush = Brushes.Red;
                NameTextBox.Background = (Brush)bc.ConvertFrom("#FFA07A");
            }
        }
    }
}
