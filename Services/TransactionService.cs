using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStationWPF.Models;

namespace FuelStationWPF.Services
{
    public class TransactionService
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return _transactions;
        }
    }
}