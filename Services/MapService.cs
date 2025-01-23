using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStationWPF.models
{
    public class MapService
    {
        public ObservableCollection<FuelStation> LoadStations()
        {
            return new ObservableCollection<FuelStation>
        {
            new FuelStation {
                Name = "Лукойл",
                Location = new GeoLocation(55.7558, 37.6176),
                FuelPrices = new Dictionary<string, decimal> {
                    {"АИ-92", 45.60m},
                    {"АИ-95", 50.10m}
                },
                ImageUrl = "/Assets/lukoil.png"
            },
            // Другие АЗС...
        };
        }
    }
