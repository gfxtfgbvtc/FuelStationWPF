using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStationWPF.Models;
using FuelStationWPF.Services;

namespace FuelStationWPF.models
{
    public class FuelStation
    {
        public string Name { get; set; }
        public GeoLocation Location { get; set; }
        public Dictionary<string, decimal> FuelPrices { get; set; }
        public string ImageUrl { get; set; } // URL логотипа АЗС
    }

    public record GeoLocation(double Latitude, double Longitude);
