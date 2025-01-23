using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;
using FuelStationWPF.Views;

namespace FuelStationWPF.models
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly BankService _bankService;
        private readonly FuelService _fuelService;

        public User CurrentUser { get; } = new User { Balance = 5000.00m };

        public ObservableCollection<FuelStation> Stations { get; }
        public ObservableCollection<Transaction> Transactions { get; } = new();

        public ICommand RefuelCommand { get; }
        public ICommand ShowPaymentDialogCommand { get; }

        public MainViewModel()
        {
            _bankService = new BankService();
            _fuelService = new FuelService();
            Stations = new MapService().LoadStations();

            RefuelCommand = new RelayCommand(OnRefuel);
            ShowPaymentDialogCommand = new RelayCommand(ShowPaymentDialog);
        }

        private void OnRefuel(object parameter)
        {
            if (parameter is FuelStation station)
            {
                var dialog = new PaymentDialog(station);
                if (dialog.ShowDialog() == true)
                {
                    ProcessPayment(station, dialog.SelectedFuel, dialog.Amount);
                }
            }
        }

        private void ProcessPayment(FuelStation station, string fuelType, decimal amount)
        {
            if (_bankService.ProcessPayment(amount, CurrentUser.CardNumber))
            {
                CurrentUser.Balance -= amount;
                Transactions.Add(new Transaction(DateTime.Now, station.Name, amount));
                UpdateBonusSystem(amount);
            }
        }

        private void UpdateBonusSystem(decimal amount)
        {
            CurrentUser.BonusPoints += (int)(amount / 100);
            // Каждые 1000 баллов = 1% скидки
            CurrentUser.BonusLevel = CurrentUser.BonusPoints / 1000;
        }
    }
}
