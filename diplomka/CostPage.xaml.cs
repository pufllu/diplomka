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
    /// Логика взаимодействия для CostPage.xaml
    /// </summary>
    public partial class CostPage : Page
    {
        public CostPage()
        {
            InitializeComponent();
        }

        private void DecisionBtn(object sender, RoutedEventArgs e)
        {
            double weight = double.Parse(WeightTextBox.Text);
            //double dimensions = double.Parse(DimensionsTextBox.Text);
            double distance = double.Parse(DistanceTextBox.Text);

            // Выполняем расчет стоимости посылки (это просто пример, фактический алгоритм может отличаться в зависимости от конкретной курьерской службы)
            //double basePrice = weight * 2 + dimensions * 0.5 + distance * 0.1;
            double basePrice = weight * 2 + distance * 0.1;
            double totalPrice = basePrice;
            double exchangeRate = 79;
            double totalPriceRub = totalPrice * exchangeRate;
            TotalPriceTextBox.Text = $"Общая стоимость: {totalPriceRub} руб.";



         
        }
    }
}
