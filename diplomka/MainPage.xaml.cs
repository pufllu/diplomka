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

namespace diplomka
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        //MainWindow window;
        Courier12Entities context;
        public MainPage(Couriers couriers)
        {
            InitializeComponent();
            if (couriers.PositionID == 3)
            {
                OrdersBtn.Visibility = Visibility.Collapsed;
                UsersBtn.Visibility = Visibility.Collapsed;
                CouriersBtn.Visibility = Visibility.Collapsed;
            }             
        }

        private void GoOrderBtn(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new Page1());
        }

        private void GoUserBtn(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new UsersPage());
        }

        private void GoCourierBtn(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new CouriersPage());
        }

        private void GoPayBtn(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new CostPage());
        }

        private void GoAddCourier(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new AddCourierPage());
        }

        private void GoAddOrder(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new AddOrderPage());
        }

        private void GoDeliveries(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new DeliveriesPage());
        }

        private void ExitBtn(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GoMaps(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new MapsPage());
        }
    }
}
