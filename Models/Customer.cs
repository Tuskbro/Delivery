using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Models
{
    public class Customer : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"{Id} - {FirstName} {LastName} ({PhoneNumber})";
        }

        private readonly AppDbContext _dbContext = new AppDbContext();

        public void CreateCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public Customer GetCustomerById(int id)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public List<Customer> GetAllCustomers()
        {

            List<Customer> customers = _dbContext.Customers.ToList();

            return customers;

        }
        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.PhoneNumber = customer.PhoneNumber;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteCustomer(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
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
