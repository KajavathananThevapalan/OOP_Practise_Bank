using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppOOP
{
    // Base class
    public abstract class BankAccount
    {
        // Properties
        public string AccountNumber { get; private set; }
        public string AccountHolderName { get; set; }
        public double Balance { get; protected set; }

        // Constructor
        public BankAccount(string accountNumber, string accountHolderName, double initialBalance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = initialBalance;
        }

        // Methods
        public virtual void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposited {amount}. New balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        public virtual void Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew {amount}. New balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount.");
            }
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"Account Number: {AccountNumber}, Balance: {Balance}");
        }
    }
}
