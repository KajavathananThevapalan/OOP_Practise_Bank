namespace BankingAppOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Banking System!");

            // Get user details
            Console.Write("Enter Account Number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter Account Holder Name: ");
            string accountHolderName = Console.ReadLine();

            Console.Write("Enter Initial Balance: ");
            double initialBalance;
            while (!double.TryParse(Console.ReadLine(), out initialBalance) || initialBalance < 0)
            {
                Console.Write("Invalid input. Enter a valid positive initial balance: ");
            }

            // Ask for account type
            Console.Write("Select Account Type (1 - Savings, 2 - Current): ");
            int accountType;
            while (!int.TryParse(Console.ReadLine(), out accountType) || (accountType != 1 && accountType != 2))
            {
                Console.Write("Invalid selection. Enter 1 for Savings or 2 for Current: ");
            }

            // Create the appropriate account
            BankAccount userAccount;
            if (accountType == 1)
            {
                Console.Write("Enter Interest Rate for Savings Account: ");
                double interestRate;
                while (!double.TryParse(Console.ReadLine(), out interestRate) || interestRate < 0)
                {
                    Console.Write("Invalid input. Enter a valid interest rate: ");
                }
                userAccount = new SavingsAccount(accountNumber, accountHolderName, initialBalance, interestRate);
            }
            else
            {
                userAccount = new CurrentAccount(accountNumber, accountHolderName, initialBalance);
            }

            // Interactive menu for banking operations
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1 - Check Balance");
                Console.WriteLine("2 - Deposit Money");
                Console.WriteLine("3 - Withdraw Money");
                if (accountType == 1)
                {
                    Console.WriteLine("4 - Calculate Interest (Savings Only)");
                }
                Console.WriteLine("5 - Exit");
                Console.Write("Enter your choice: ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.Write("Invalid choice. Please enter a number between 1 and 5: ");
                }

                switch (choice)
                {
                    case 1:
                        userAccount.DisplayBalance();
                        break;
                    case 2:
                        Console.Write("Enter deposit amount: ");
                        double depositAmount;
                        while (!double.TryParse(Console.ReadLine(), out depositAmount) || depositAmount <= 0)
                        {
                            Console.Write("Invalid input. Enter a positive amount: ");
                        }
                        userAccount.Deposit(depositAmount);
                        break;
                    case 3:
                        Console.Write("Enter withdrawal amount: ");
                        double withdrawAmount;
                        while (!double.TryParse(Console.ReadLine(), out withdrawAmount) || withdrawAmount <= 0)
                        {
                            Console.Write("Invalid input. Enter a positive amount: ");
                        }
                        userAccount.Withdraw(withdrawAmount);
                        break;
                    case 4:
                        if (accountType == 1)  // Interest calculation only for Savings Account
                        {
                            ((SavingsAccount)userAccount).CalculateInterest();
                        }
                        else
                        {
                            Console.WriteLine("Invalid option.");
                        }
                        break;
                    case 5:
                        exit = true;
                        Console.WriteLine("Thank you for using our banking system!");
                        break;
                }
            }
        }
    }
}
