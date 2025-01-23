using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using FuelStationWPF.Models;

namespace FuelStationWPF.models
{
    public class FuelService
    {
        private readonly BankService _bankService;
        private readonly BonusSystem _bonusSystem;

        public FuelService(BankService bankService, BonusSystem bonusSystem)
        {
            _bankService = bankService;
            _bonusSystem = bonusSystem;
        }

        public bool Refuel(User user, FuelStation station, string fuelType, double liters, out Transaction transaction)
        {
            transaction = null;

            if (!station.FuelPrices.TryGetValue(fuelType, out decimal pricePerLiter))
                return false;

            decimal amount = (decimal)liters * pricePerLiter;
            decimal discount = _bonusSystem.GetDiscount();
            decimal finalAmount = amount * (1 - discount);

            if (_bankService.ProcessPayment(finalAmount, user.CardNumber))
            {
                user.Balance -= finalAmount;
                _bonusSystem.AddPoints((int)(finalAmount / 10));

                transaction = new Transaction(
                    DateTime.Now,
                    fuelType,
                    liters,
                    finalAmount,
                    station.Name
                );

                return true;
            }

            return false;
        }

        public bool RefuelBySum(User user, FuelStation station, string fuelType, decimal desiredAmount, out Transaction transaction)
        {
            transaction = null;

            if (!station.FuelPrices.TryGetValue(fuelType, out decimal pricePerLiter))
                return false;

            double liters = (double)(desiredAmount / pricePerLiter);
            return Refuel(user, station, fuelType, liters, out transaction);
        }
    }
}
