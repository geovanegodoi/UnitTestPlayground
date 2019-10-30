using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary
{
    public class BankAccount
    {
        public int Balance { get; private set; }

        public BankAccount(int startingBalance)
        {
            Balance = startingBalance;
        }

        public void Deposit(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive", nameof(amount));

            Balance += amount;
        }

        public bool Withdraw(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdraw amount must be positive", nameof(amount));

            if (Balance >= amount && amount > 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        private Dictionary<string, string> credentials = new Dictionary<string, string>
        {
            { "geovane.godoi", "godoi123" },
            { "vanessa.godoi", "pistoni123" }
        };

        public bool Login(string login, string password)
        {
            if (credentials.TryGetValue(login, out string value))
            {
                if (value == password)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}
