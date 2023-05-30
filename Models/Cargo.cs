using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace Delivery.Models
{
    public class Cargo : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
        public string Description { get; set; }
        public bool IsFragile { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }

        private readonly AppDbContext _dbContext = new AppDbContext();

            public void CreateCargo(Cargo cargo)
            {
                _dbContext.Cargos.Add(cargo);
                _dbContext.SaveChanges();
            }

            public Cargo GetCargoById(int id)
            {
                return _dbContext.Cargos.FirstOrDefault(c => c.Id == id);
            }

            public List<Cargo> GetAllCargos()
            {
                List<Cargo> cargos = _dbContext.Cargos.ToList();
                return cargos;
            }

        public void UpdateCargo(Cargo сargo)
        {
            var existingCargo = _dbContext.Cargos.FirstOrDefault(c => c.Id == сargo.Id);
            if (existingCargo != null)
            {
                existingCargo.Name = сargo.Name;
                existingCargo.Weight = сargo.Weight;
                existingCargo.Description = сargo.Description;
                existingCargo.IsFragile = сargo.IsFragile;
                existingCargo.Width = сargo.Weight;
                existingCargo.Height = сargo.Height;
                existingCargo.Depth = сargo.Depth;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteCargo(int id)
            {
                var cargo = _dbContext.Cargos.FirstOrDefault(c => c.Id == id);
                if (cargo != null)
                {
                    _dbContext.Cargos.Remove(cargo);
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
