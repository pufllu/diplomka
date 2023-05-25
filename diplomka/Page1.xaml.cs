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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        Courier12Entities context;
        public Page1()
        {
            InitializeComponent();
            context = new Courier12Entities();
            TableOrder.ItemsSource = context.Orders.ToList();
        }
        public void RefreszData()
        {
            var list = context.Orders.ToList();
            if (!string.IsNullOrWhiteSpace(SearchOrder.Text))
            {
                list = list.Where(x => x.ClientFio.ToLower().Contains(SearchOrder.Text.ToLower())).ToList();
            }
            TableOrder.ItemsSource = list;
        }


        private void ChangeSearch(object sender, TextChangedEventArgs e)
        {
            RefreszData();
        }

        private void EditOrder(object sender, RoutedEventArgs e)
        {
            Orders orders = TableOrder.SelectedItem as Orders;
            NavigationService.Navigate(new EditOrder(context, orders));
        }

        private void DeleteOrder(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы точно хотите удалить вопрос?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Orders orders = TableOrder.SelectedItem as Orders;
                    context.Orders.Remove(orders);
                    context.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            RefreszData();
        }

        private void AddOrderClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
