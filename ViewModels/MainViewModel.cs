using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private TabItemViewModel _selectedTabItem;
        public TabItemViewModel SelectedTabItem
        {
            get { return _selectedTabItem; }
            set
            {
                _selectedTabItem = value;
                RaisePropertyChanged(nameof(SelectedTabItem));
            }
        }

        private ObservableCollection<TabItemViewModel> _tabItems;
        public ObservableCollection<TabItemViewModel> TabItems
        {
            get { return _tabItems; }
            set
            {
                _tabItems = value;
                RaisePropertyChanged(nameof(TabItems));
            }
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                RaisePropertyChanged(nameof(SelectedIndex));
            }
        }

        public MainViewModel()
        {
            TabItems = new ObservableCollection<TabItemViewModel>
            {
                new CustomerViewModel(),
                new CargoViewModel(),
                new DriverViewModel(),
                new CarViewModel(),
                new CargoInOrderViewModel(),
                new OrderViewModel()
            };
            SelectedIndex = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
