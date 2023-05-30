using Delivery.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Delivery.ViewModels
{
    public class CarViewModel : TabItemViewModel
    {
        private Car _selectedCar;
        private string _brand;
        private string _model;
        private string _regNumber;
        private float _engineHours;
        private int _driverId;
        private Driver _driver;
        private List<Driver> _drivers;
        private readonly Car _car = new Car();
        private ObservableCollection<Car> _cars;
        private Car _newCar = new Car();
        public string Header { get; } = "Car";


        public ObservableCollection<Car> Cars
        {
            get { return _cars; }
            set
            {
                _cars = value;
                RaisePropertyChanged(nameof(Cars));
            }
        }
        public ICommand CreateCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public CarViewModel()
        {

            LoadDrivers();
            LoadCars();
            FormInput_DriverId = 0;
            CreateCommand = new RelayCommand(() => CreateCar());
            UpdateCommand = new RelayCommand<Car>(UpdateCar);
            DeleteCommand = new RelayCommand<Car>(DeleteCar);
        }
        
        public List<Driver> Drivers
        {
            get => _drivers;
            set
            {
                _drivers = value;
                RaisePropertyChanged(nameof(Drivers));
            }
        }

        public string FormInput_Brand
        {
            get { return _brand; }
            set
            {
                _brand = value;
                _newCar.Brand = value;
                RaisePropertyChanged(nameof(FormInput_Brand));
            }
        }

        public string FormInput_Model
        {
            get => _model;
            set
            {
                _model = value;
                RaisePropertyChanged(nameof(FormInput_Model));

            }
        }

        public string FormInput_RegNumber
        {
            get => _regNumber;
            set
            {
                _regNumber = value;
                RaisePropertyChanged(nameof(FormInput_RegNumber));
            }
        }

        public float FormInput_EngineHours
        {
            get => _engineHours;
            set
            {
                _engineHours = value;
                RaisePropertyChanged(nameof(FormInput_EngineHours));
            }
        }

        public int FormInput_DriverId
        {
            get => _driverId;
            set
            {
                _driverId = value;
                RaisePropertyChanged(nameof(FormInput_DriverId));
            }
        }

        public void CreateCar()
        {
            Car car = new Car
            {
                Brand = FormInput_Brand,
                Model = FormInput_Model,
                RegNumber = FormInput_RegNumber,
                EngineHours = FormInput_EngineHours,
                DriverId = _driverId
            };

            _car.CreateCar(car);
            LoadCars();
            ClearFormInputs();
        }

        public void UpdateCar(Car car)
        {

            Debug.WriteLine(car.Driver.ToString());
            Debug.WriteLine(car.DriverId.ToString());

            _car.UpdateCar(car);
            
            LoadCars();
            RaisePropertyChanged(nameof(Cars));
        }

        public void DeleteCar(Car car)
        {
                _car.DeleteCar(car.Id);
                LoadCars();
                ClearFormInputs();
            
        }

        private void LoadDrivers()
        {
            Drivers = _car.GetAllDrivers();
            
            RaisePropertyChanged(nameof(Drivers));
        }

        private void LoadCars()
        {
            Cars = new ObservableCollection<Car>(_car.GetAllCars());
            
            RaisePropertyChanged(nameof(Cars));
            
        }

        private void ClearFormInputs()
        {
            FormInput_Brand = string.Empty;
            FormInput_Model = string.Empty;
            FormInput_RegNumber = string.Empty;
            FormInput_EngineHours = 0;
            FormInput_DriverId = 0;
        }

    }
}
