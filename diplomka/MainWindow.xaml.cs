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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Courier12Entities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new Courier12Entities();
        }

        private void authorizationBtn(object sender, RoutedEventArgs e)
        {
            int ID = Convert.ToInt32(login.Text);
            string password = pass.Password;
            using (Courier12Entities context = new Courier12Entities())
            {
                Couriers couriers = context.Couriers.ToList().Find(x => x.CourierID == ID);
                if (couriers == null)
                {
                    MessageBox.Show("Работника с таким логином не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (couriers.Password.Equals(password))
                    {
                        MessageBox.Show("Успешная авторизация", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        FramePage.Content = new MainPage(couriers);
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                
            }
        }
    }
}
