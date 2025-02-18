using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankingAppOOP.BankAccount;

namespace BankingAppOOP
{
    // Derived class
    public class CurrentAccount : BankAccount
    {
        // Constructor
        public CurrentAccount(string accountNumber, string accountHolderName, double initialBalance)
            : base(accountNumber, accountHolderName, initialBalance)
        {
        }

        // Override Withdraw method to allow overdraft
        public override void Withdraw(double amount)
        {
            if (amount > 0)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew {amount}. New balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount.");
            }
        }
    }
}
