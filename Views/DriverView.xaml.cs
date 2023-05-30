using Delivery.ViewModels;
using System.Windows.Controls;

namespace Delivery.Views
{
    /// <summary>
    /// Логика взаимодействия для DriverView.xaml
    /// </summary>
    public partial class DriverView : UserControl
    {
        public DriverView()
        {
            InitializeComponent();
            DataContext = new DriverViewModel();
        }
    }
}
