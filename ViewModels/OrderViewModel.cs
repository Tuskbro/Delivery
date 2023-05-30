using Delivery.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Delivery.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        private Order _selectedOrder;
        private string _departurePoint;
        private string _deliveryPoint;
        private int _customerId;
        private int _carId;
        private Customer _customer;
        private List<Customer> _customers;
        private Car _car;
        private List<Car> _cars;
        private readonly Order _order = new Order();
        private ObservableCollection<Order> _orders;
        private Order _newOrder = new Order();

        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                RaisePropertyChanged(nameof(Orders));
            }
        }

        

        private ObservableCollection<CargoInOrder> cargosInOrder;
        public ObservableCollection<CargoInOrder> CargosInOrder
        {
            get { return cargosInOrder; }
            set
            {
                cargosInOrder = value;
                RaisePropertyChanged(nameof(CargosInOrder));
            }
        }

        private CargoInOrder selectedCargoInOrder;
        public CargoInOrder SelectedCargoInOrder
        {
            get { return selectedCargoInOrder; }
            set
            {
                selectedCargoInOrder = value;
                RaisePropertyChanged(nameof(SelectedCargoInOrder));
            }
        }
        private readonly AppDbContext _dbContext = new AppDbContext();
        

        public ICommand DeleteCargoInOrderCommand { get; private set; }
        public ICommand AddCargoCommand { get; private set; }

        public ICommand CreateCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public OrderViewModel()
        {
            LoadCustomers();
            LoadCars();
            LoadOrders();
            foreach (var order in Orders)
            {
                foreach(var cargo in order.CargosInOrder)
                {
                    Debug.WriteLine(cargo.Cargo.Name);
                }
            }
            CreateCommand = new RelayCommand(() => CreateOrder());
            UpdateCommand = new RelayCommand<Order>(UpdateOrder);
            DeleteCommand = new RelayCommand<Order>(DeleteOrder);
        }

        public List<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                RaisePropertyChanged(nameof(Customers));
            }
        }

        public List<Car> Cars
        {
            get => _cars;
            set
            {
                _cars = value;
                RaisePropertyChanged(nameof(Cars));
            }
        }

        public string FormInput_DeparturePoint
        {
            get { return _departurePoint; }
            set
            {
                _departurePoint = value;
                _newOrder.DeparturePoint = value;
                RaisePropertyChanged(nameof(FormInput_DeparturePoint));
            }
        }

        public string FormInput_DeliveryPoint
        {
            get => _deliveryPoint;
            set
            {
                _deliveryPoint = value;
                _newOrder.DeliveryPoint = value;
                RaisePropertyChanged(nameof(FormInput_DeliveryPoint));
            }
        }

        public int FormInput_CustomerId
        {
            get => _customerId;
            set
            {
                _customerId = value;
                _newOrder.CustomerId = value;
                RaisePropertyChanged(nameof(FormInput_CustomerId));
            }
        }

        public int FormInput_CarId
        {
            get => _carId;
            set
            {
                _carId = value;
                _newOrder.CarId = value;
                RaisePropertyChanged(nameof(FormInput_CarId));
            }
        }

        public void CreateOrder()
        {
            Order order = new Order
            {
                DeparturePoint = FormInput_DeparturePoint,
                DeliveryPoint = FormInput_DeliveryPoint,
                CustomerId = FormInput_CustomerId,
                CarId = FormInput_CarId
            };

            _order.CreateOrder(order);
            LoadOrders();
            ClearFormInputs();
        }

        public void UpdateOrder(Order order)
        {
            

            _order.UpdateOrder(order);

            LoadOrders();
            RaisePropertyChanged(nameof(Orders));
        }

        public void DeleteOrder(Order order)
        {
            _order.DeleteOrder(order.Id);
            LoadOrders();
            ClearFormInputs();
        }

        private void LoadCustomers()
        {
            Customer customer= new Customer();
            Customers = customer.GetAllCustomers();
            RaisePropertyChanged(nameof(Customers));
        }

        private void LoadCars()
        {
            Car car= new Car();
            Cars = car.GetAllCars();
            RaisePropertyChanged(nameof(Cars));
        }

        private void LoadOrders()
        {
            List<Order> orders = _order.GetAllOrders();

            foreach (var order in orders)
            {
                order.CargosInOrder = _dbContext.CargosInOrder
                    .Include(cio => cio.Cargo)
                    .Where(cio => cio.OrderId == order.Id)
                    .ToList();

            }

            Orders = new ObservableCollection<Order>(_order.GetAllOrders());
            RaisePropertyChanged(nameof(Orders));
        }

        private void ClearFormInputs()
        {
            FormInput_DeparturePoint = string.Empty;
            FormInput_DeliveryPoint = string.Empty;
            FormInput_CustomerId = 0;
            FormInput_CarId = 0;
        }
    }


}

