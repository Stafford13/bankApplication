using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data
{
    public class AccountMapper
    {
        public static string ToString(Account account)
        {
            return $"{account.AccountNumber},{account.Name},{account.Balance.ToString()},{account.Type.ToString().Remove(1)}";
        }

        public static Account ToAccount(string row)
        {
            Account a = new Account();
            string[] fields = row.Split(',');

            switch (fields[3])
            {
                case "F":
                    a.Type = AccountType.Free;
                    break;
                case "B":
                    a.Type = AccountType.Basic;
                    break;
                case "P":
                    a.Type = AccountType.Premium;
                    break;
            }

            a.AccountNumber = fields[0];
            a.Name = fields[1];
            a.Balance = decimal.Parse(fields[2]);
           
            return a;
        }
    }
}
