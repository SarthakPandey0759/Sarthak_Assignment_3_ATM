using System;
using System.Windows;

namespace Sarthak_Assignment_3_ATM
{
    public partial class MainWindow : Window
    {
        private AtmApplication atmApp = new AtmApplication();
        private Bank bank = new Bank();
        private Account selectedAccount;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            int accountNumber;
            double initialBalance, interestRate;
            string accountHolderName = AccountHolderNameTextBox.Text;

            if (int.TryParse(AccountNumberTextBox.Text, out accountNumber) &&
                double.TryParse(InitialBalanceTextBox.Text, out initialBalance) &&
                double.TryParse(InterestRateTextBox.Text, out interestRate))
            {
                var account = new Account(accountNumber, initialBalance, interestRate, accountHolderName);
                bank.AddAccount(account);
                MessageBox.Show("Account created successfully!");
            }
            else
            {
                MessageBox.Show("Please enter valid account details.");
            }
        }

        private void SelectAccountButton_Click(object sender, RoutedEventArgs e)
        {
            int accountNumber;

            if (int.TryParse(AccountNumberTextBox.Text, out accountNumber))
            {
                selectedAccount = bank.RetrieveAccount(accountNumber);

                if (selectedAccount != null)
                {
                    MessageBox.Show("Account selected successfully!");
                }
                else
                {
                    MessageBox.Show("Account not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid account number.");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenAccountOperationsButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAccount != null)
            {
                var accountOperationsWindow = new AccountOperationsWindow(selectedAccount, bank);
                accountOperationsWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select an account first.");
            }
        }

        private void CheckBalanceButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAccount != null)
            {
                CurrentBalanceLabel.Content = selectedAccount.Balance.ToString("C");
            }
            else
            {
                MessageBox.Show("No account selected.");
            }
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAccount != null)
            {
                double amount;
                if (double.TryParse(AmountTextBox.Text, out amount))
                {
                    selectedAccount.Deposit(amount);
                    CurrentBalanceLabel.Content = selectedAccount.Balance.ToString("C");
                    MessageBox.Show("Amount deposited successfully!");
                }
                else
                {
                    MessageBox.Show("Please enter a valid amount.");
                }
            }
            else
            {
                MessageBox.Show("No account selected.");
            }
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
{
    if (selectedAccount != null)
    {
        double amount;
        if (double.TryParse(AmountTextBox.Text, out amount))
        {
            if (selectedAccount.Withdraw(amount))
            {
                CurrentBalanceLabel.Content = selectedAccount.Balance.ToString("C");
                MessageBox.Show("Amount withdrawn successfully!");
            }
            else
            {
                MessageBox.Show("Insufficient funds.");
            }
        }
        else
        {
            MessageBox.Show("Please enter a valid amount.");
        }
    }
    else
    {
        MessageBox.Show("No account selected.");
    }
}


    }
}
