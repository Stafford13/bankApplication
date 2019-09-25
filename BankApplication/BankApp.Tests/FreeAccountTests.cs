using System;
using NUnit.Framework;
using BankApp.Models.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.BLL;
using BankApp.Models;
using BankApp.Models.Interfaces;
using BankApp.BLL.DepositRules;
using BankApp.BLL.WithdrawRules;

namespace BankApp.Tests
{
    [TestFixture]
    public class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);
        }

        [TestCase("12345", "Free Account", 100, AccountType.Free, 250, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 50, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, true)]
        public void FreeAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
        IDeposit deposit = new FreeAccountDepositRule();
        Account accountDesposit = new Account()
        {
            AccountNumber = accountNumber,
            Name = name,
            Balance = balance,
            Type = accountType
        };
        AccountDepositResponse Response = deposit.Deposit(accountDesposit, amount);
        Assert.AreEqual(expectedResult, Response.Success);
        }

        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, false)]
        [TestCase("12345", "Free Account", 150, AccountType.Free, -101, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, -50, false)]
        [TestCase("12345", "Free Account", 50, AccountType.Free, -51, false)]
        [TestCase("12345", "Free Account", 200, AccountType.Free, -50, true)]
        public void FreeAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
        IWithdraw withdrawal = new FreeAccountWithdrawRule();
        Account accountWithdraw = new Account() { AccountNumber = accountNumber, Type = accountType, Balance = balance };
        AccountWithdrawResponse response = withdrawal.Withdraw(accountWithdraw, amount);

        Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
