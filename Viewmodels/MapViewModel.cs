using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using FuelStationWPF.Models;
using FuelStationWPF.Services;
using FuelStationWPF.Utilities;

namespace FuelStationWPF.models
{
    public class MapViewModel : INotifyPropertyChanged
    {
        private readonly MapService _mapService;
        private FuelStation _selectedStation;

        public ObservableCollection<FuelStation> Stations { get; }
        public ICommand SelectStationCommand { get; }

        public FuelStation SelectedStation
        {
            get => _selectedStation;
            set
            {
                _selectedStation = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(StationDetailsVisible));
            }
        }

        public bool StationDetailsVisible => SelectedStation != null;

        public MapViewModel()
        {
            _mapService = new MapService();
            Stations = new ObservableCollection<FuelStation>(_mapService.LoadStations());
            SelectStationCommand = new RelayCommand(ExecuteSelectStation);
        }

        private void ExecuteSelectStation(object parameter)
        {
            if (parameter is FuelStation station)
            {
                SelectedStation = station;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}