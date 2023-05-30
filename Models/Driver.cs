using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Delivery.Models
{
    public class Driver : INotifyPropertyChanged
    {
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public int Experience { get; set; }
        public string PhoneNumber { get; set; }

        private readonly AppDbContext _dbContext = new AppDbContext();

        public void CreateDriver(Driver driver)
        {
            _dbContext.Drivers.Add(driver);
            _dbContext.SaveChanges();
        }

        public Driver GetDriverById(int id)
        {
            return _dbContext.Drivers.FirstOrDefault(d => d.Id == id);
        }

        public override string ToString()
        {
            return FirstName+ " " + LastName;
        }

        public List<Driver> GetAllDrivers()
        {

            List<Driver> drivers = _dbContext.Drivers.ToList();

            return drivers;

        }
        public void UpdateDriver(Driver driver)
        {
            var existingDriver = _dbContext.Drivers.FirstOrDefault(c => c.Id == driver.Id);
            if (existingDriver != null)
            {
                existingDriver.FirstName = driver.FirstName;
                existingDriver.LastName = driver.LastName;
                existingDriver.DateOfBirthday = driver.DateOfBirthday;
                existingDriver.Experience = driver.Experience;
                existingDriver.PhoneNumber = driver.PhoneNumber;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteDriver(int id)
        {
            var driver = _dbContext.Drivers.FirstOrDefault(d => d.Id == id);
            if (driver != null)
            {
                _dbContext.Drivers.Remove(driver);
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
