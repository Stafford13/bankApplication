﻿using BankApp.Models;
using BankApp.Models.Interfaces;
using System;
using BankApp.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.BLL.DepositRules
{
    public class DespositRulesFactory
    {
        public static IDeposit Create(AccountType type)
        {
            switch(type)
            {
                case AccountType.Free:
                    return new FreeAccountDepositRule();
                case AccountType.Basic:
                    return new NoLimitDepositRule();
                case AccountType.Premium:
                    return new NoLimitDepositRule();

            }

            throw new Exception("Account type is not supported!");
        }
    }
}
