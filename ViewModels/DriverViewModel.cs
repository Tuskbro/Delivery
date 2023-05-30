using Delivery.Models;
using Delivery.Utilities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Delivery.ViewModels
{
    public class DriverViewModel : TabItemViewModel
    {
        private readonly Driver _driver = new Driver();
        private ObservableCollection<Driver> _drivers;
        private Driver _newDriver = new Driver();

        private Driver _selectedDriver;
        public string Header { get; } = "Driver";
        public ObservableCollection<Driver> Drivers
        {
            get { return _drivers; }
            set
            {
                _drivers = value;
                RaisePropertyChanged(nameof(Drivers));
            }
        }

        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private DateTime _dateOfBirthday;
        private int _experience;
        public string FormInput_FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                _newDriver.FirstName = value;
                RaisePropertyChanged(nameof(FormInput_FirstName));
            }
        }

        public string FormInput_LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                _newDriver.LastName = value;
                RaisePropertyChanged(nameof(FormInput_LastName));
            }
        }

        public string FormInput_PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                _newDriver.PhoneNumber = value;
                RaisePropertyChanged(nameof(FormInput_PhoneNumber));
            }
        }

        public DateTime FormInput_DateOfBirthday
        {
            get { return _dateOfBirthday; }
            set 
            { 
                _dateOfBirthday = value;
                _newDriver.DateOfBirthday = value;
                RaisePropertyChanged(nameof(FormInput_DateOfBirthday));
            }
        }

        public int FormInput_Experience
        {
            get { return _experience; }
            set 
            { 
                _experience = value;
                _newDriver.Experience = value;
                RaisePropertyChanged(nameof(FormInput_Experience));
            }
        }
        public ICommand CreateCommand { get; }

        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public DriverViewModel()
        {
            LoadDrivers();
            CreateCommand = new RelayCommand(() => CreateDriver());

            UpdateCommand = new RelayCommand<Driver>(UpdateDriver);
            DeleteCommand = new RelayCommand<Driver>(DeleteDriver);
            FormInput_DateOfBirthday = new DateTime(2000, 1, 1);
        }

        private void LoadDrivers()
        {
            Drivers = new ObservableCollection<Driver>(_driver.GetAllDrivers());
            RaisePropertyChanged(nameof(Driver));

        }

        private void CreateDriver()
        {
            if (!Validation.IsNullOrEmpty(new List<string> 
            {   
                FormInput_FirstName,
                FormInput_LastName,
                FormInput_PhoneNumber,
                FormInput_DateOfBirthday.ToString(), 
                FormInput_Experience.ToString() 
            }))
            {
                Driver driver = new Driver
                {
                    FirstName = FormInput_FirstName,
                    LastName = FormInput_LastName,
                    PhoneNumber = FormInput_PhoneNumber,
                    DateOfBirthday = FormInput_DateOfBirthday,
                    Experience = FormInput_Experience,
                    
                };

                _driver.CreateDriver(driver);

                FormInput_FirstName = string.Empty;
                FormInput_LastName = string.Empty;
                FormInput_PhoneNumber = string.Empty;
                FormInput_DateOfBirthday = new DateTime(2000, 1, 1);
                LoadDrivers();
            }

        }

        private void UpdateDriver(Driver driver)
        {
            _driver.UpdateDriver(driver);
            LoadDrivers();
            RaisePropertyChanged(nameof(Driver)); 

        }

        private void DeleteDriver(Driver driver)
        {
            _driver.DeleteDriver(driver.Id);
            LoadDrivers();
        }
    }
}
