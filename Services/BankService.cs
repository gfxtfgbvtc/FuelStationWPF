using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStationWPF.models
{
    public class BankService
    {
        public bool ProcessPayment(decimal amount, string cardNumber)
        {
            // Имитация банковской проверки
            if (cardNumber.Length != 16 || amount <= 0)
                return false;

            return new Random().Next(0, 10) > 2; // 80% успешных транзакций
        }
    }
