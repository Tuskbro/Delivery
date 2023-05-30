using Delivery.ViewModels;
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

namespace Delivery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void TabControl_LostFocus(object sender, RoutedEventArgs e)
        {
            // Получаем текущую выбранную вкладку
            var tabControl = (TabControl)sender;
            var selectedTabItem = tabControl.SelectedItem as TabItemViewModel;

            // Если есть выбранная вкладка, обновляем ее контекст данных
            if (selectedTabItem != null)
            {
                var selectedContent = tabControl.SelectedContent as FrameworkElement;
                selectedContent?.GetBindingExpression(DataContextProperty)?.UpdateSource();
            }
        }
    }
}
