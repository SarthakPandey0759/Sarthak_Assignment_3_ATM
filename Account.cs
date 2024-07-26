using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarthak_Assignment_3_ATM
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public double Balance { get; set; }
        public double InterestRate { get; set; }
        public string AccountHolderName { get; set; }

        public Account(int accountNumber, double initialBalance, double interestRate, string accountHolderName)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            InterestRate = interestRate;
            AccountHolderName = accountHolderName;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public bool Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public double CalculateInterest()
        {
            return Balance * (InterestRate / 100);
        }
    }
}
