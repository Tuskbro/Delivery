﻿using Delivery.Models;
using Delivery.Utilities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Delivery.ViewModels
{
    public class CargoInOrderViewModel : TabItemViewModel
    {
        private CargoInOrder _selectedCargoInOrder;
        private int _cargoId;
        private int _orderId;
        private int _count;
        private readonly CargoInOrder _cargoInOrder = new CargoInOrder();
        private List<Cargo> _cargos;
        private ObservableCollection<CargoInOrder> _cargoInOrders;
        private CargoInOrder _newCargoInOrder = new CargoInOrder();
        private List<Order> _orders;
        public string Header { get; } = "Cargo In Order";

        public ObservableCollection<CargoInOrder> CargoInOrders
        {
            get { return _cargoInOrders; }
            set
            {
                _cargoInOrders = value;
                RaisePropertyChanged(nameof(CargoInOrders));
            }
        }

        public List<Cargo> Cargos
        {
            get => _cargos;
            set
            {
                _cargos = value;
                RaisePropertyChanged(nameof(Cargos));
            }
        }

        public List<Order> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                RaisePropertyChanged(nameof(Orders));
            }
        }

        public ICommand CreateCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }


        public CargoInOrderViewModel()
        {
            LoadCargos();
            LoadOrder();
            LoadCargoInOrders();
            CreateCommand = new RelayCommand(() => CreateCargoInOrder());
            UpdateCommand = new RelayCommand<CargoInOrder>(UpdateCargoInOrder);
            DeleteCommand = new RelayCommand<CargoInOrder>(DeleteCargoInOrder);
            foreach (var order in Orders)
            {
                Debug.WriteLine(order.Customer.FirstName);
            }
            
        }

        public int FormInput_CargoId
        {
            get { return _cargoId; }
            set
            {
                _cargoId = value;
                RaisePropertyChanged(nameof(FormInput_CargoId));
            }
        }

        public int FormInput_OrderId
        {
            get => _orderId;
            set
            {
                _orderId = value;
                RaisePropertyChanged(nameof(FormInput_OrderId));
            }
        }

        public int FormInput_Count
        {
            get => _count;
            set
            {
                _count = value;
                RaisePropertyChanged(nameof(FormInput_Count));
            }
        }

        public void CreateCargoInOrder()
        {
            if (FormInput_CargoId!=0 && FormInput_OrderId!=0 && FormInput_Count!=0)
                {
                CargoInOrder cargoInOrder = new CargoInOrder
                {
                    CargoId = FormInput_CargoId,
                    OrderId = FormInput_OrderId,
                    Count = FormInput_Count
                };

                _cargoInOrder.CreateCargoInOrder(cargoInOrder);
                LoadCargoInOrders();
                ClearFormInputs(); 
            }
        }

        public void UpdateCargoInOrder(CargoInOrder cargoInOrder)
        {
            _cargoInOrder.UpdateCargoInOrder(cargoInOrder);
            LoadCargoInOrders();
        }

        public void DeleteCargoInOrder(CargoInOrder cargoInOrder)
        {
            _cargoInOrder.DeleteCargoInOrder(cargoInOrder.Id);
            LoadCargoInOrders();
        }

        private void LoadCargoInOrders()
        {
            CargoInOrders = new ObservableCollection<CargoInOrder>(_cargoInOrder.GetAllCargoInOrders());
            RaisePropertyChanged(nameof(CargoInOrders));
        }

        private void LoadCargos()
        {
            Cargo cargo = new Cargo();
            Cargos = cargo.GetAllCargos();
            RaisePropertyChanged(nameof(Cargos));
        }

        private void LoadOrder()
        {
            Order order = new Order();
            Orders = order.GetAllOrders();
            RaisePropertyChanged(nameof(Orders));
        }

        private void ClearFormInputs()
        {
            FormInput_CargoId = 0;
            FormInput_OrderId = 0;
            FormInput_Count= 0;
        }
    }
}
