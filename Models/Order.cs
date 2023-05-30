using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Delivery.Models
{
    public class Order : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeparturePoint { get; set; }
        public string DeliveryPoint { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("CarId")]
        public int CarId { get; set; }
        public Car Car { get; set; }

        public List<CargoInOrder> CargosInOrder { get; set; }

        private readonly AppDbContext _dbContext = new AppDbContext();

        public void CreateOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public Order GetOrderById(int id)
        {
            return _dbContext.Orders.FirstOrDefault(o => o.Id == id);
        }

        public List<Order> GetAllOrders()
        {
            return _dbContext.Orders.Include(o => o.Customer).Include(o => o.Car).ToList();
        }
        public void UpdateOrder(Order order)
        {
            var existingOrder = _dbContext.Orders.FirstOrDefault(o => o.Id == order.Id);
            if (existingOrder != null)
            {
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.DeparturePoint = order.DeparturePoint;
                existingOrder.DeliveryPoint = order.DeliveryPoint;
                existingOrder.CustomerId = order.CustomerId;
                existingOrder.CarId = order.CarId;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteOrder(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                _dbContext.SaveChanges();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
