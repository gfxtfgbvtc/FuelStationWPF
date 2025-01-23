using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FuelStationWPF.Models;
using FuelStationWPF.Services;

namespace FuelStationWPF.models
{
    public class Transaction : INotifyPropertyChanged
    {
        private DateTime _time;
        private string _fuelType;
        private double _liters;
        private decimal _amount;
        private string _stationName;

        public DateTime Time
        {
            get => _time;
            set { _time = value; OnPropertyChanged(); }
        }

        public string FuelType
        {
            get => _fuelType;
            set { _fuelType = value; OnPropertyChanged(); }
        }

        public double Liters
        {
            get => _liters;
            set { _liters = value; OnPropertyChanged(); }
        }

        public decimal Amount
        {
            get => _amount;
            set { _amount = value; OnPropertyChanged(); }
        }

        public string StationName
        {
            get => _stationName;
            set { _stationName = value; OnPropertyChanged(); }
        }

        public Transaction(DateTime time, string fuelType, double liters, decimal amount, string stationName)
        {
            Time = time;
            FuelType = fuelType;
            Liters = liters;
            Amount = amount;
            StationName = stationName;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
