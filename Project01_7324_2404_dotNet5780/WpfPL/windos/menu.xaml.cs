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

namespace WpfPL.windos
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class menuControl : UserControl
    {
        public menuControl()
        {
            InitializeComponent();
        }

        private void MenuGuest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Application.Current.Windows[0].Close();
            mainWindow.Show();  
        }

        private void MenuHost_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuOwner_Click(object sender, RoutedEventArgs e)
        {
            Owner_Login_Window owner_Login_Window = new Owner_Login_Window();
            owner_Login_Window.ShowDialog();
        }
        
        private void He_Item_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void En_Item_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
