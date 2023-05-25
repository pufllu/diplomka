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
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        Courier12Entities context;
        public EditUserPage(Courier12Entities cont)
        {
            InitializeComponent();
            context = cont;
        }
        Users us;
        public EditUserPage(Courier12Entities cont, Users users)
        {
            InitializeComponent();
            context = cont;
            us = users;
            TextBoxFio.Text = users.FIO;
            TextBoxNumber.Text = users.UserPhoneNumber;
            TextBoxPassword.Text = users.Password;
            TextBoxEmail.Text = users.Email;
        }
       
        private void BackBtn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsersPage());
        }

        private void EditCourier(object sender, RoutedEventArgs e)
        {
            Users userToUpdate = context.Users.Find(us.UserID);
            if (userToUpdate != null)
            {
                userToUpdate.FIO = TextBoxFio.Text;
                userToUpdate.UserPhoneNumber = TextBoxNumber.Text;
                userToUpdate.Password = TextBoxPassword.Text;
                userToUpdate.Email = TextBoxEmail.Text;
                context.SaveChanges();
            }
            NavigationService.Navigate(new UsersPage());
        }
    }
}
