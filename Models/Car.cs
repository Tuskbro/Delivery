using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Delivery.Models
{
    public class Car : INotifyPropertyChanged
    {

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string RegNumber { get; set; }
        public float EngineHours { get; set; }
        [ForeignKey("Driver")]
        public int DriverId { get; set; }
        
        public Driver Driver { get; set; }
        

        private readonly AppDbContext _dbContext = new AppDbContext();

        public void CreateCar(Car car)
        {
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();
        }

        public Car GetCarById(int id)
        {
            return _dbContext.Cars.FirstOrDefault(c => c.Id == id);
        }

        public List<Car> GetAllCars()
        {
            List<Car> cars = _dbContext.Cars.Include(c => c.Driver).ToList();
            
            
            return cars;
        }

        public List<Driver> GetAllDrivers() 
        {
            Driver driver = new Driver();
            return driver.GetAllDrivers();
        }

        public void UpdateCar(Car car)
        {
            var existingCar = _dbContext.Cars.FirstOrDefault(c => c.Id == car.Id);
            if (existingCar != null)
            {
                

                existingCar.Brand = car.Brand;
                existingCar.Model = car.Model;
                existingCar.RegNumber = car.RegNumber;
                existingCar.EngineHours = car.EngineHours;
                existingCar.DriverId = car.DriverId;
                

                _dbContext.SaveChanges();
            }
        }

        public void DeleteCar(int id)
        {
            var car = _dbContext.Cars.FirstOrDefault(c => c.Id == id);
            if (car != null)
            {
                _dbContext.Cars.Remove(car);
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
