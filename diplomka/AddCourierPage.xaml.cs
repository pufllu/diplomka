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
    /// Логика взаимодействия для AddCourierPage.xaml
    /// </summary>
    public partial class AddCourierPage : Page
    {
        Courier12Entities context;
        public AddCourierPage( )
        {
            InitializeComponent();
            context = new Courier12Entities();
        }
      
        private void AddCourier(object sender, RoutedEventArgs e)
        {
            string FIO = TextBoxFio.Text;
            string NumberPhone = TextBoxNumber.Text;
            string VehicleType = TextBoxVehicleType.Text;
            string RegistrationNumber = TextBoxReg.Text;
            string Password = TextBoxPassword.Text;
            Couriers couriers = new Couriers
            {
                FIO = FIO,
                PhoneNumber = NumberPhone,
                VehicleType = VehicleType,
                VehicleRegistrationPlates = RegistrationNumber,
                Password = Password
            };
            context.Couriers.Add(couriers);
            context.SaveChanges();
            NavigationService.Navigate(new CouriersPage());
        }
     
        private void BackBtn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CouriersPage());
        }
    }
}
