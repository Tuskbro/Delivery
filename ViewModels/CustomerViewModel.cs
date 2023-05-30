using Delivery.Models;
using Delivery.Utilities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Delivery.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        private readonly Customer _customer = new Customer();
        private ObservableCollection<Customer> _customers;
        private Customer _newCustomer = new Customer();

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                RaisePropertyChanged(nameof(Customers));
            }
        }
       


        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        public string FormInput_FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                _newCustomer.FirstName = value;
                RaisePropertyChanged(nameof(FormInput_FirstName));
            }
        }

        public string FormInput_LastName
        {
            get { return _lastName; }
            set { 
                _lastName= value;
                _newCustomer.LastName = value;
                RaisePropertyChanged(nameof(FormInput_LastName));
            }
        }

        public string FormInput_PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                _newCustomer.PhoneNumber = value;
                RaisePropertyChanged(nameof(FormInput_PhoneNumber));
            }
        }


        public ICommand CreateCommand { get; }

        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public CustomerViewModel()
        {
            LoadCustomers();
            CreateCommand = new RelayCommand(() => CreateCustomer());
            UpdateCommand = new RelayCommand<Customer>(UpdateCustomer);
            DeleteCommand = new RelayCommand<Customer>(DeleteCustomer);
        }

        private void LoadCustomers()
        {
            Customers = new ObservableCollection<Customer>(_customer.GetAllCustomers());
            RaisePropertyChanged(nameof(Customers));
        }

        private void CreateCustomer()
        {
            if (!Validation.IsNullOrEmpty(new List<string> { FormInput_FirstName, FormInput_LastName, FormInput_PhoneNumber }))
            {
                Customer castomer = new Customer
                {
                    FirstName = FormInput_FirstName,
                    LastName = FormInput_LastName,
                    PhoneNumber = FormInput_PhoneNumber,
                };

                _customer.CreateCustomer(castomer);

                FormInput_FirstName = string.Empty;
                FormInput_LastName = string.Empty;
                FormInput_PhoneNumber = string.Empty;


                LoadCustomers();
            }

        }

        private void UpdateCustomer(Customer customer)
        {
            _customer.UpdateCustomer(customer);
            LoadCustomers();
            RaisePropertyChanged(nameof(Customers)); // Добавлено вызов события PropertyChanged
        }

        private void DeleteCustomer(Customer customer)
        {
            _customer.DeleteCustomer(customer.Id);
            LoadCustomers();
        }
    }
}
