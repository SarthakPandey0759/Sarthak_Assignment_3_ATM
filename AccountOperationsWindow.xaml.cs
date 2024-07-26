using System.Windows;

namespace Sarthak_Assignment_3_ATM
{
    public partial class AccountOperationsWindow : Window
    {
        private Account account;
        private Bank bank;

        public AccountOperationsWindow(Account account, Bank bank)
        {
            InitializeComponent();
            this.account = account;
            this.bank = bank;
            UpdateBalanceDisplay();
        }

        private void UpdateBalanceDisplay()
        {
            AccountBalanceLabel.Content = account.Balance.ToString("C");
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            double amount;

            if (double.TryParse(AmountTextBox.Text, out amount))
            {
                account.Deposit(amount);
                UpdateBalanceDisplay();
                MessageBox.Show("Amount deposited successfully!");
            }
            else
            {
                MessageBox.Show("Please enter a valid amount.");
            }
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            double amount;

            if (double.TryParse(AmountTextBox.Text, out amount))
            {
                if (account.Withdraw(amount))
                {
                    UpdateBalanceDisplay();
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
    }
}
