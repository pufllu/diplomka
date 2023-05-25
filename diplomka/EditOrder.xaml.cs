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
    /// Логика взаимодействия для EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Page
    {
        Courier12Entities context;
        public EditOrder(Courier12Entities cont)
        {
            InitializeComponent();
            context = cont;
        }
        Orders ord;
        public EditOrder(Courier12Entities cont, Orders orders)
        {
            InitializeComponent();
            context = cont;
            ord = orders;
            NameUser.Text = orders.ClientFio;
            StateOrder.Text = orders.DeliveryStatus;
            DeliveryAddress.Text = orders.DeliveryAddress;
            DateOrder.SelectedDate = orders.OrderDate;
        
        }
        private void SaveOrder(object sender, RoutedEventArgs e)
        {
            context.Orders.Find(ord.OrderID).UserID = Convert.ToInt32(NameUser.Text);
            context.Orders.Find(ord.OrderID).DeliveryAddress = DeliveryAddress.Text;
            context.Orders.Find(ord.OrderID).OrderDate = Convert.ToDateTime(DateOrder.Text);
            context.Orders.Find(ord.OrderID).DeliveryStatus = StateOrder.Text;
            context.SaveChanges();
            NavigationService.Navigate(new Page1());
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }
    }
}
