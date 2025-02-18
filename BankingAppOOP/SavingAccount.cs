using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static BankingAppOOP.BankAccount;

namespace BankingAppOOP
{
    // Derived class
    public class SavingsAccount : BankAccount
    {
        private double InterestRate { get; set; }

        // Constructor
        public SavingsAccount(string accountNumber, string accountHolderName, double initialBalance, double interestRate)
            : base(accountNumber, accountHolderName, initialBalance)
        {
            InterestRate = interestRate;
        }

        // Method to calculate interest
        public void CalculateInterest()
        {
            double interest = Balance * InterestRate / 100;
            Deposit(interest);
            Console.WriteLine($"Interest calculated and added: {interest}");
        }
    }
}
