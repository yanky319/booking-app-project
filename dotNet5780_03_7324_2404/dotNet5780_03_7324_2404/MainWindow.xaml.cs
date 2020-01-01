//dotNet_5780_03
//yaakov taber 319187324
//moshe helfgot 206262404
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
    /// Interaction logic for MainWindow.xaml
    ///  public partial class MainWindow : Window
    /// </summary>
    /// < parm name = currentHost > the current Host displade </parm>
    /// < parm name = hostsList > list of all the hosts  </parm> 
    public partial class MainWindow : Window
    {
        private Host currentHost;
        List<Host> hostsList;

        /// <summary>
        /// ctor for main Window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            //Quick דקא of the variables
            hostsList = new List<Host>()
            {
                new Host()
                {
                    HostName = "משה רביבו",
                    Units= new List<HostingUnit>()
                    {
                        new HostingUnit()
                        {
                            UnitName ="חוות כינרת",
                            Rooms = 5,
                            IsSwimmimgPool = true,
                            AllOrders =new List<DateTime>(),
                            Uris = new List<string>()
                            {
                                "https://pic.rrr.co.il/images/havakineret/130%20(Big).jpg",
                                "https://pic.rrr.co.il/images/havakineret/93%20(Big).jpg",
                                "https://pic.rrr.co.il/images/havakineret/91%20(Big).jpg",
                            },
                        },
                        new HostingUnit()
                        {
                            UnitName ="חלום בכינרת",
                            Rooms = 3,
                            IsSwimmimgPool = true,
                            AllOrders =new List<DateTime>(),
                            Uris = new List<string>()
                            {
                                "https://pic.rrr.co.il/images/halombakineret/73%20(Big).jpg",
                                "https://pic.rrr.co.il/images/halombakineret/117%20(Big).jpg",
                                "https://pic.rrr.co.il/images/halombakineret/75%20(Big).jpg",
                            },
                        },
                        new HostingUnit()
                        {
                              UnitName ="צימר לכינרת",
                            Rooms = 4,
                            IsSwimmimgPool = false,
                            AllOrders =new List<DateTime>(),
                            Uris = new List<string>()
                            {
                                "https://pic.rrr.co.il/images/lakineret/121%20(Big).jpg",
                                "https://pic.rrr.co.il/images/lakineret/114%20(Big).jpg",
                                "https://pic.rrr.co.il/images/lakineret/147%20(Big).jpg",
                            },
                        },
                    },

                },

                new Host()
                {
                    HostName ="יעקב רוזנטל",
                    Units= new List<HostingUnit>()
                    {
                        new HostingUnit()
                        {
                            UnitName ="שחר המדבר",
                            Rooms = 2,
                            IsSwimmimgPool = false,
                            AllOrders =new List<DateTime>(),
                            Uris = new List<string>()
                            {
                                "https://pic.rrr.co.il/images/shaharha/16%20(Big).jpg",
                                "https://pic.rrr.co.il/images/shaharha/2%20(Big).jpg",
                                "https://pic.rrr.co.il/images/shaharha/39%20(Big).jpg",
                            },
                        },
                        new HostingUnit()
                        {
                            UnitName ="אחוזת וולנברג",
                            Rooms = 4,
                            IsSwimmimgPool = true,
                            AllOrders =new List<DateTime>(),
                            Uris = new List<string>()
                            {
                                "https://pic.rrr.co.il/images/woolenberg/2%20(Big).jpg",
                                "https://pic.rrr.co.il/images/woolenberg/26%20(Big).jpg",
                                "https://pic.rrr.co.il/images/woolenberg/32%20(Big).jpg",
                            },
                        },
                        new HostingUnit()
                        {
                              UnitName ="צימר ונופש בים המלח",
                            Rooms = 2,
                            IsSwimmimgPool = true,
                            AllOrders =new List<DateTime>(),
                            Uris = new List<string>()
                            {
                                "https://pic.rrr.co.il/images/tzimernofesh/63%20(Big).jpg",
                                "https://pic.rrr.co.il/images/tzimernofesh/52%20(Big).jpg",
                                "https://pic.rrr.co.il/images/tzimernofesh/48%20(Big).jpg",
                            },
                        },
                    },

                },

                new Host()
                {
                    HostName = "שמעון אביב",
                    Units= new List<HostingUnit>()
                    {
                        new HostingUnit()
                        {
                            UnitName ="פנינת חוף אלמוג",
                            Rooms = 2,
                            IsSwimmimgPool = false,
                            AllOrders =new List<DateTime>(),
                            Uris = new List<string>()
                            {
                                "https://pic.rrr.co.il/images/pninathof/4%20(Big).jpg",
                                "https://pic.rrr.co.il/images/pninathof/8%20(Big).jpg",
                                "https://pic.rrr.co.il/images/pninathof/17%20(Big).jpg",
                            },
                        },
                      
                    },

                },

                new Host()
                {
                    HostName = "בנימין חמו",
                   Units= new List<HostingUnit>()
                    {
                        new HostingUnit()
                        {
                            UnitName ="חלום בגליל",
                            Rooms = 4,
                            IsSwimmimgPool = true,
                            AllOrders =new List<DateTime>(),
                            Uris = new List<string>()
                            {
                                "https://pic.rrr.co.il/images/halombagalil/162%20(Big).jpg",
                                "https://pic.rrr.co.il/images/halombagalil/134%20(Big).jpg",
                                "https://pic.rrr.co.il/images/halombagalil/161%20(Big).jpg",
                            },
                        },
                        new HostingUnit()
                        {
                            UnitName ="בת הרים",
                            Rooms = 2,
                            IsSwimmimgPool = true,
                            AllOrders =new List<DateTime>(),
                            Uris = new List<string>()
                            {
                                "https://pic.rrr.co.il/images/harim/80%20(Big).jpg",
                                "https://pic.rrr.co.il/images/harim/53%20(Big).jpg",
                                "https://pic.rrr.co.il/images/harim/47%20(Big).jpg",
                            },
                        },
                    },

                },
            };

            cbHostList.ItemsSource = hostsList;
            cbHostList.DisplayMemberPath = "HostName";
            cbHostList.SelectedIndex = 0;
        }

        /// <summary>
        /// A function to perform when the event CbHostList.SelectionChanged is raised
        /// Replaces the host displade
        /// </summary>
        /// <param name="sender">the sender </param>
        /// <param name="e">event param's</param>
        private void CbHostList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InitializeHost(cbHostList.SelectedIndex);
        }

        /// <summary>
        /// Replaces the host displade
        /// </summary>
        /// <param name="index">the index of the host to be displade</param>
        private void InitializeHost(int index)
        {
            MainGrid.Children.RemoveRange(1, 3);   //Deleting the units being displade
            currentHost = hostsList[index];
            UpGrid.DataContext = currentHost;
            for (int i = 0; i < currentHost.Units.Count; i++) //display units of the current Host
            {
                HostingUnitUserControl a = new HostingUnitUserControl(currentHost.Units[i]);
                MainGrid.Children.Add(a);
                Grid.SetRow(a, i + 1);
            }
        }
    }
}
