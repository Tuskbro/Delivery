using Delivery.ViewModels;
using System.Windows.Controls;

namespace Delivery.Views
{
    /// <summary>
    /// Логика взаимодействия для OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        public OrderView()
        {
            InitializeComponent();
            DataContext = new OrderViewModel();
        }
    }
}
