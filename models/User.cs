using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using FuelStationWPF.Models;
using FuelStationWPF.Services;
using System.Threading.Tasks;

namespace FuelStationWPF.models
{
    public class User : INotifyPropertyChanged
    {
        private decimal _balance;
        public decimal Balance
        {
            get => _balance;
            set { _balance = value; OnPropertyChanged(); }
        }

        public int BonusPoints { get; set; }
        public string CardNumber { get; } = "4111 1111 1111 1111";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}