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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        Courier12Entities context;
        public UsersPage()
        {
            InitializeComponent();
            context = new Courier12Entities();
            UsersTable.ItemsSource = context.Users.ToList();
        }

        private void EditUser(object sender, RoutedEventArgs e)
        {
            Users users = UsersTable.SelectedItem as Users;
            NavigationService.Navigate(new EditUserPage(context, users ));
        }

        public void RefreszData()
        {
            var list = context.Couriers.ToList();
            if (!string.IsNullOrWhiteSpace(TextBoxUser.Text))
            {
                list = list.Where(x => x.FIO.ToLower().Contains(TextBoxUser.Text.ToLower())).ToList();
            }
            UsersTable.ItemsSource = list;
        }
        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы точно хотите удалить вопрос?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Couriers couriers = UsersTable.SelectedItem as Couriers;
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

        private void ChangeSearch(object sender, TextChangedEventArgs e)
        {
            RefreszData();
        }
    }
}
