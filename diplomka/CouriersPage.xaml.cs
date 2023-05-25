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
    /// Логика взаимодействия для CouriersPage.xaml
    /// </summary>
    public partial class CouriersPage : Page
    {
        Courier12Entities context;
        public CouriersPage()
        {
            InitializeComponent();
            context = new Courier12Entities();
            CourierTable.ItemsSource = context.Couriers.ToList();
        }
        public void RefreszData()
        {
            var list = context.Couriers.ToList();
            if (!string.IsNullOrWhiteSpace(SearchCourier.Text))
            {
                list = list.Where(x => x.FIO.ToLower().Contains(SearchCourier.Text.ToLower())).ToList();
            }
            CourierTable.ItemsSource = list;
        }
        private void ChangeSearch(object sender, TextChangedEventArgs e)
        {
            RefreszData();
        }

        private void DeleteOrder(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы точно хотите удалить вопрос?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Couriers couriers = CourierTable.SelectedItem as Couriers;
                    context.Couriers.Remove(couriers);
                    context.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            RefreszData();
        }

        private void AddCourier(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCourierPage());
        }
    }
}
