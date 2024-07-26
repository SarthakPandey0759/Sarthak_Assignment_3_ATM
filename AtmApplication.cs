using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Sarthak_Assignment_3_ATM
{
    public class AtmApplication
    {
        private Bank bank = new Bank();
        private Account selectedAccount;

        public void Run()
        {
            while (true)
            {
                DisplayMainMenu();
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        SelectAccount();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine("ATM Main Menu:");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Select Account");
            Console.WriteLine("3. Exit");
        }

        private void CreateAccount()
        {
            Console.Write("Enter Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter Initial Balance: ");
            double initialBalance = double.Parse(Console.ReadLine());
            Console.Write("Enter Interest Rate: ");
            double interestRate = double.Parse(Console.ReadLine());
            Console.Write("Enter Account Holder's Name: ");
            string accountHolderName = Console.ReadLine();

            var account = new Account(accountNumber, initialBalance, interestRate, accountHolderName);
            bank.AddAccount(account);
        }

        private void SelectAccount()
        {
            Console.Write("Enter Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            selectedAccount = bank.RetrieveAccount(accountNumber);

            if (selectedAccount != null)
            {
                while (true)
                {
                    DisplayAccountMenu();
                    var choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine($"Balance: {selectedAccount.Balance}");
                            break;
                        case "2":
                            Console.Write("Enter amount to deposit: ");
                            double depositAmount = double.Parse(Console.ReadLine());
                            selectedAccount.Deposit(depositAmount);
                            break;
                        case "3":
                            Console.Write("Enter amount to withdraw: ");
                            double withdrawAmount = double.Parse(Console.ReadLine());
                            if (!selectedAccount.Withdraw(withdrawAmount))
                            {
                                Console.WriteLine("Insufficient funds.");
                            }
                            break;
                        case "4":
                            // Display transactions logic here
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        private void DisplayAccountMenu()
        {
            Console.WriteLine("Account Menu:");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Display Transactions");
            Console.WriteLine("5. Exit Account");
        }
    }
}
