using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.ViewModels
{
    public class TabItemViewModel : ViewModelBase
    {
        private string _header;
        public string Header
        {
            get { return _header; }
            set
            {
                _header = value;
                RaisePropertyChanged(nameof(Header));
            }
        }

       
    }
}
