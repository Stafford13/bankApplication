using BankApp.BLL;
using BankApp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Workflows
{
    public class DepositWorkflow
    {
        public void Execute()
        {
            Console.Clear();

            AccountManager accountManager = AccountManagerFactory.Create();

            Console.Write("Enter an account number: ");
            string accountNumber = Console.ReadLine();
            if (accountNumber != accountNumber.ToString())
            {
                Console.WriteLine("What was that? An error occurred.");
                //Console.WriteLine(response.Message);
            }
            else
            {
            }

            Console.Write("Enter a deposit amount: ");
            decimal amount;
            //decimal amount = decimal.Parse(Console.ReadLine());
            while (decimal.TryParse(Console.ReadLine(), out amount) == false)
            {
                Console.WriteLine("This is an error, try again.");
                Console.WriteLine("Enter a deposit amount");
            }

            AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Deposit Completed!");
                Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
                Console.WriteLine($"Old Balance: {response.OldBalance:c}");
                Console.WriteLine($"Amount Deposited: {response.Amount:c}");
                Console.WriteLine($"New Balance: {response.Account.Balance:c}");

            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
