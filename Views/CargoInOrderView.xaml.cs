using Delivery.ViewModels;
using System.Windows.Controls;

namespace Delivery.Views
{
    /// <summary>
    /// Логика взаимодействия для CargoInOrderView.xaml
    /// </summary>
    public partial class CargoInOrderView : UserControl
    {
        public CargoInOrderView()
        {
            InitializeComponent();
            DataContext = new CargoInOrderViewModel();
        }
    }
}
