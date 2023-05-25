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
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        Courier12Entities context;
        public AddOrderPage( )
        {
            InitializeComponent();
            context = new Courier12Entities();
            
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(TextBoxId.Text);
            int userid = Convert.ToInt32(TextBoxFio.Text);
            string address = TextBoxAddress.Text;
            DateTime date = Convert.ToDateTime(TextBoxDateOrder.Text);
            string status = TextBoxStatus.Text;
            Orders orders = new Orders()
            {
                OrderID = id,
                UserID = userid,
                DeliveryAddress = address,
                OrderDate = date,
                DeliveryStatus = status,
            };
            context.Orders.Add(orders);
            context.SaveChanges();
            NavigationService.Navigate(new Page1());
        }
        //    if(flag == true)
        //    {
        //        Orders orders = new Orders()
        //        {
        //            OrderID = Convert.ToInt32(TextBoxId.Text),
        //            UserID = Convert.ToInt32(TextBoxFio.Text),
        //            DeliveryAddress = TextBoxAddress.Text,
        //            OrderDate = Convert.ToDateTime(TextBoxDateOrder.Text),
        //            DeliveryStatus = TextBoxStatus.Text
        //        };
        //        context.Orders.Add(orders);
        //        context.SaveChanges();
        //        NavigationService.Navigate(new Page1());
        //    }
        //    else
        //    {
        //        Orders existingOrder = context.Orders.Find(ord.OrderID);
        //        if (existingOrder != null)
        //        {
        //            existingOrder.UserID = Convert.ToInt32(TextBoxFio.Text);
        //            existingOrder.DeliveryAddress = TextBoxAddress.Text;
        //            existingOrder.OrderDate = Convert.ToDateTime(TextBoxDateOrder.Text);
        //            existingOrder.DeliveryStatus = TextBoxStatus.Text;
        //            context.SaveChanges();
        //            NavigationService.Navigate(new Page1());
        //        }
        //    }
        //}
        //Orders ord;
        //public AddOrderPage(Courier12Entities cont, Orders orders)
        //{
        //    InitializeComponent();
        //    context = cont;
        //    ord = orders;
        //    TextBoxId.Text = orders.OrderID.ToString();
        //    TextBoxFio.Text = orders.UserID.ToString();
        //    TextBoxAddress.Text = orders.DeliveryAddress;
        //    TextBoxDateOrder.SelectedDate = orders.OrderDate;
        //    TextBoxStatus.Text = orders.DeliveryStatus;
        //    flag = false;
        //}
        private void BackBtn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }
    }
}
