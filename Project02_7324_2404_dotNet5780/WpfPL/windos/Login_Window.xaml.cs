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
    public partial class Login_Window : Window
    {
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public Login_Window()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            this.Topmost = true;
            Loaded += Loade;

            NameTextBox.MouseDoubleClick += DoubleClick;
            NameTextBox2.MouseDoubleClick += DoubleClick;
            PasswordPasswordBox.MouseDoubleClick += DoubleClick;
            PasswordPasswordBox2.MouseDoubleClick += DoubleClick;

            NameTextBox.KeyDown += keyDown;
            NameTextBox2.KeyDown += keyDown;
            PasswordPasswordBox.KeyDown += keyDown;
            PasswordPasswordBox2.KeyDown += keyDown;
            LoginLable.KeyDown += keyDown2;
            LoginLable2.KeyDown += keyDown2;

            CancelLable.MouseDown += CancelLable_Click;
            CancelLable2.MouseDown += CancelLable_Click; 
            LoginLable.MouseDown += LoginLable_Click;
            LoginLable2.MouseDown += LoginLable2_Click;

            CancelLable.MouseEnter += mouseEnter;
            CancelLable2.MouseEnter += mouseEnter;
            LoginLable.MouseEnter += mouseEnter;
            LoginLable2.MouseEnter += mouseEnter;

            CancelLable.MouseLeave += mouseLeave;
            CancelLable2.MouseLeave += mouseLeave;
            LoginLable.MouseLeave += mouseLeave;
            LoginLable2.MouseLeave += mouseLeave;
        }

        private void mouseEnter(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            label.FontSize = int.Parse(FindResource("over_size").ToString());
            label.Foreground = (Brush) new BrushConverter().ConvertFromString(FindResource("over_color").ToString());
        }

        private void mouseLeave(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            label.FontSize = int.Parse(FindResource("not_over_size").ToString());
            label.Foreground = (Brush)new BrushConverter().ConvertFromString(FindResource("not_over_color").ToString());
        }

        private void keyDown2(object sender, KeyEventArgs e)
        {
            try
            {
                Label a = sender as Label;
                if (e.Key == Key.Tab)
                {
                    if (a.Name == "LoginLable")
                        CancelLable.Focus();
                    if (a.Name == "LoginLable2")
                        CancelLable2.Focus();
                }
                if (e.Key == Key.Enter)
                {
                    if (a.Name == "LoginLable")
                        LoginLable_Click(sender,e);
                    if (a.Name == "LoginLable2")
                        LoginLable2_Click(sender, e);
                }
            }
            catch
            {

            }
        }
        private void Loade(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
        private void CancelLable_Click(object sender, RoutedEventArgs e)
        { 
            this.Close();
        }
        private void DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                TextBox a = sender as TextBox;
                a.SelectAll();
            }
            catch
            {

            }
            try
            {
                PasswordBox a = sender as PasswordBox;
                a.SelectAll();
            }
            catch
            {

            }

        }


        void keyDown(object sender, KeyEventArgs e)
        {
            try
            {
                TextBox a = sender as TextBox;
                if (e.Key == Key.Enter || e.Key == Key.Tab)
                {
                    if (a.Name == "NameTextBox")
                        PasswordPasswordBox.Focus();
                    if (a.Name == "NameTextBox2")
                        PasswordPasswordBox2.Focus();
                }
            }
            catch
            {

            }
            try
            {
                PasswordBox a = sender as PasswordBox;
                if (e.Key == Key.Enter || e.Key == Key.Tab)
                {
                    if (a.Name == "PasswordPasswordBox")
                        LoginLable.Focus();
                    if (a.Name == "PasswordPasswordBox2")
                        LoginLable2.Focus();
                }
            }
            catch
            {

            }

        }
        private void LoginLable_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "yanky" && PasswordPasswordBox.Password == "moshe")
            {
                for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                    if (App.Current.Windows[intCounter] != this)
                        App.Current.Windows[intCounter].Close();
                new Owner_screen().Show();
                this.Close();
            }
            else
            {
                ERROR_LABLE.Content = this.FindResource("Incorrect_login_information").ToString();
                ERROR_LABLE.Foreground = Brushes.Red;
            }
        }
        private void LoginLable2_Click(object sender, RoutedEventArgs e)
        {
            BL.IBL  bl = BL.FactorySingleton.Instance;
            List<BE.Host> hosts = bl.getHosts().ToList();
            foreach (BE.Host host in hosts)
            {
                if (host.PrivateName + ' ' + host.FamilyName == NameTextBox2.Text && host.passwordeHash == PasswordPasswordBox2.Password.GetHashCode())
                {
                    for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                        if (App.Current.Windows[intCounter] != this)
                            App.Current.Windows[intCounter].Close();
                    new Host_Window(host,true).Show();
                    this.Close();

                }
            }
            ERROR_LABLE2.Content = this.FindResource("Incorrect_login_information").ToString();
            ERROR_LABLE2.Foreground = Brushes.Red;
        }
    }
}
