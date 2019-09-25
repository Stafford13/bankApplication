using BankApp.Models;
using BankApp.Models.Interfaces;
using BankApp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.BLL.WithdrawRules
{
    public class PremiumAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if (account.Type != AccountType.Premium)
            {
                response.Success = false;
                response.Message = "Error: a non Premium account hit the Premium Withdraw Rule. Contact IT";
                return response;
            }

            if (amount >= 0)
            {
                response.Success = false;
                response.Message = "Withdrawl amounts must be negative!";
                return response;
            }

            if (account.Balance + amount < -500)
                {
                    response.Success = false;
                    response.Message = "This amount will overdraft more than your $500 limit!";
                    return response;
                }
            
            response.OldBalance = account.Balance;
            account.Balance += amount;
            response.Account = account;
            response.Amount = amount;
            response.Success = true;
            if (account.Balance == -account.Balance)
            {
                account.Balance -= 10;
            }

            return response;
        }
    }
}
