using Delivery.ViewModels;
using System.Windows.Controls;


namespace Delivery.Views
{
    /// <summary>
    /// Логика взаимодействия для CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
            DataContext = new CustomerViewModel();
        }
    }
}
