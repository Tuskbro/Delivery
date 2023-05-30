using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Delivery.Models
{
    public class CargoInOrder : INotifyPropertyChanged
    {
        public int Id { get; set; }
        [ForeignKey("CargoId")]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Count { get; set; }


        
       

        private readonly AppDbContext _dbContext = new AppDbContext();
        public void CreateCargoInOrder(CargoInOrder cargoInOrder)
        {
            _dbContext.CargosInOrder.Add(cargoInOrder);
            _dbContext.SaveChanges();
        }

        public CargoInOrder GetCargoInOrderById(int id)
        {
            return _dbContext.CargosInOrder.FirstOrDefault(cio => cio.Id == id);
        }

        public List<CargoInOrder> GetAllCargoInOrders()
        {
            return _dbContext.CargosInOrder.Include(cio => cio.Cargo)
                                          .Include(cio => cio.Order)
                                          .ToList();
        }
        public void UpdateCargoInOrder(CargoInOrder cargoInOrder)
        {
            var existingCargoInOrder = _dbContext.CargosInOrder.FirstOrDefault(cio => cio.Id == cargoInOrder.Id);
            if (existingCargoInOrder != null)
            {
                existingCargoInOrder.CargoId = cargoInOrder.CargoId;
                existingCargoInOrder.OrderId = cargoInOrder.OrderId;
                existingCargoInOrder.Count = cargoInOrder.Count;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteCargoInOrder(int id)
        {
            var cargoInOrder = _dbContext.CargosInOrder.FirstOrDefault(cio => cio.Id == id);
            if (cargoInOrder != null)
            {
                _dbContext.CargosInOrder.Remove(cargoInOrder);
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
