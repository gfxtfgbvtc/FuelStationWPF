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


namespace FuelStationWPF.models
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        private readonly User _user;
        private readonly TransactionService _transactionService;

        public decimal Balance => _user.Balance;
        public int BonusPoints => _user.BonusPoints;
        public ObservableCollection<Transaction> Transactions { get; }

        public ICommand RefreshCommand { get; }
        public ICommand AddFundsCommand { get; }

        public ProfileViewModel(User user, TransactionService transactionService)
        {
            _user = user;
            _transactionService = transactionService;
            Transactions = new ObservableCollection<Transaction>(_transactionService.GetTransactions());

            RefreshCommand = new RelayCommand(ExecuteRefresh);
            AddFundsCommand = new RelayCommand(ExecuteAddFunds);
        }

        private void ExecuteRefresh(object parameter)
        {
            Transactions.Clear();
            foreach (var transaction in _transactionService.GetTransactions())
            {
                Transactions.Add(transaction);
            }
        }

        private void ExecuteAddFunds(object parameter)
        {
            if (parameter is decimal amount)
            {
                _user.Balance += amount;
                OnPropertyChanged(nameof(Balance));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}