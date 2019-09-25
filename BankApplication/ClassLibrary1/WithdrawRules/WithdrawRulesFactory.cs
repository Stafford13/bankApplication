using BankApp.Models;
using BankApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.BLL.WithdrawRules
{
    public class WithdrawRulesFactory
    {
         public static IWithdraw Create(AccountType type)
            {
                switch (type)
                {
                    case AccountType.Free:
                        return new FreeAccountWithdrawRule();
                    case AccountType.Basic:
                        return new BasicAccountWithdrawRule();
                    case AccountType.Premium:
                        return new PremiumAccountWithdrawRule();
                }

                throw new Exception("Account type is not supported!");
            }
    }
}
