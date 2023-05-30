using Delivery.Models;
using Microsoft.EntityFrameworkCore;


namespace Delivery
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CargoInOrder> CargosInOrder { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;port=3306;database=Delivery;user=root;password=Exit_Now;";

            optionsBuilder.UseMySQL(connectionString);
            
        }
    }
}
