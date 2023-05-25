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
    /// Логика взаимодействия для DeliveriesPage.xaml
    /// </summary>
    public partial class DeliveriesPage : Page
    {
        Courier12Entities context;
        public DeliveriesPage()
        {
            InitializeComponent();
            context = new Courier12Entities();
            TableDelivery.ItemsSource = context.Deliveries.ToList();
        }

        private void ChangeSearch(object sender, TextChangedEventArgs e)
        {

        }

        private void DeleteOrder(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы точно хотите удалить сотрудника?", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Deliveries deliveries = TableDelivery.SelectedItem as Deliveries;
                    context.Deliveries.Remove(deliveries);
                    context.SaveChanges();
                    NavigationService.Navigate(new DeliveriesPage());
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
        }
        private void EditOrder(object sender, RoutedEventArgs e)
        {

        }
    }
}
