using Delivery.Models;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace Delivery.ViewModels
{
    public class CargoViewModel : TabItemViewModel
    {
        private readonly Cargo _cargo = new Cargo();
        private  Cargo _newCargo = new Cargo();
        public string Header { get; } = "Cargo";

        private ObservableCollection<Cargo> _cargos;

        public ObservableCollection<Cargo> Cargos
        {
            get { return _cargos; }
            set
            {
                _cargos = value;
                RaisePropertyChanged(nameof(Cargos));
            }
        }

        private string _name;
        private float _weight;
        private string _description;
        private bool _isFragile;
        private float _width;
        private float _height;
        private float _depth;
        public string FormInput_Name
        {
            get { return _name; }
            set
            {
                _name = value;
                _newCargo.Name = value;
                RaisePropertyChanged(nameof(FormInput_Name));
            }
        }

        public float FormInput_Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                _newCargo.Weight = value;
                RaisePropertyChanged(nameof(FormInput_Weight));
            }
        }

        public string FormInput_Description
        {
            get { return _description; }
            set
            {
                _description = value;
                _newCargo.Description = value;
                RaisePropertyChanged(nameof(FormInput_Description));
            }
        }

        public bool FormInput_IsFragile
        {
            get { return _isFragile; }
            set
            {
                _isFragile = value;
                _newCargo.IsFragile = value;
                RaisePropertyChanged(nameof(FormInput_IsFragile));
            }
        }

        public float FormInput_Width
        {
            get { return _width; }
            set
            {
                _width = value;
                _newCargo.Width = value;
                RaisePropertyChanged(nameof(FormInput_Width));
            }
        }
        public float FormInput_Height
        {
            get { return _height; }
            set
            {
                _height = value;
                _newCargo.Height = value;
                RaisePropertyChanged(nameof(FormInput_Height));
            }
        }
        
        public float FormInput_Depth
        {
            get { return _depth; }
            set
            {
                _depth = value;
                _newCargo.Depth = value;
                RaisePropertyChanged(nameof(FormInput_Depth));
            }
        }

        public ICommand CreateCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public CargoViewModel()
        {
            LoadCargos();
            CreateCommand = new RelayCommand(() => CreateCargo());

            UpdateCommand = new RelayCommand<Cargo>(UpdateCargo);
            DeleteCommand = new RelayCommand<Cargo>(DeleteCargo);
        }

        private void LoadCargos()
        {
            Cargos = new ObservableCollection<Cargo>(_cargo.GetAllCargos());
            RaisePropertyChanged(nameof(Cargos));

        }

        private void CreateCargo()
        {
            Cargo cargo = new Cargo
            {
                Name = FormInput_Name,
                Weight = FormInput_Weight,
                Description = FormInput_Description,
                IsFragile = FormInput_IsFragile,
                Width = FormInput_Width,
                Height = FormInput_Height,
                Depth = FormInput_Depth
            };

            _cargo.CreateCargo(cargo);

            FormInput_Name = string.Empty;
            FormInput_Weight = 0;
            FormInput_Description = string.Empty;
            FormInput_IsFragile = false;
            FormInput_Width = 0;
            FormInput_Height = 0;
            FormInput_Depth = 0;

            LoadCargos();

        }

        private void UpdateCargo(Cargo cargo)
        {
            _cargo.UpdateCargo(cargo);
            LoadCargos();
            RaisePropertyChanged(nameof(Cargos));
            LoadCargos();
        }

        private void DeleteCargo(Cargo cargo)
        {
            _cargo.DeleteCargo(cargo.Id);
            LoadCargos();
        }
    }
}
