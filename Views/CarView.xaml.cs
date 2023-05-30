using Delivery.ViewModels;
using System.Windows.Controls;

namespace Delivery.Views
{
    /// <summary>
    /// Логика взаимодействия для CarView.xaml
    /// </summary>
    public partial class CarView : UserControl
    {
        public CarView()
        {
            InitializeComponent();
            DataContext = new CarViewModel();
        }
    }
}
