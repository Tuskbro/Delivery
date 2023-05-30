using Delivery.ViewModels;
using System.Windows.Controls;

namespace Delivery.Views
{
    /// <summary>
    /// Логика взаимодействия для CargoView.xaml
    /// </summary>
    public partial class CargoView : UserControl
    {
        public CargoView()
        {
            InitializeComponent();
            DataContext = new CargoViewModel();
        }
    }
}
