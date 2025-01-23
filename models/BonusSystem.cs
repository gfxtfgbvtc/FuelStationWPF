using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStationWPF.Models;
using FuelStationWPF.Services;

namespace FuelStationWPF.models
{
    public class BonusSystem : INotifyPropertyChanged
    {
        private int _points;
        public int Points
        {
            get => _points;
            set { _points = value; UpdateLevel(); }
        }

        public int Level { get; private set; }

        public decimal GetDiscount()
        {
            return Level * 0.01m; // 1% за каждый уровень
        }

        private void UpdateLevel()
        {
            Level = Points / 1000;
            OnPropertyChanged(nameof(Level));
        }
    }
}