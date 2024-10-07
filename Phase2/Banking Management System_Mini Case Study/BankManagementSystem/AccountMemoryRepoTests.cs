using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankManagementProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace BankManagementProject.Tests
{
    [TestClass()]
    public class AccountMemoryRepoTests
    {
        private AccountMemoryRepo _repo;
        [TestInitialize]
        public void initialize()
        {
            _repo = AccountMemoryRepo.Instance;
        }
        [TestMethod()]
        public void CreateTest()
        {
            var account = new AccountModel()
            {
                AccNo = 49,
                Name = "Ammu",
                Balance = 0,
                AccType = "current",
                Email = "ammu@gmail.com",
                PhNo = "5236526526",
                Address = "address",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            };
            _repo.Create(account);

            Assert.IsTrue(_repo.ReadAllAccount().Any(ac => ac.AccNo == 49));
        }

        [TestMethod()]
        public void UpdateAccountTest()
        {
            AccountModel account = new AccountModel
            {
                AccNo = 1234,
                Name = "Anamika",
                Balance = 0,
                AccType = "savings",
                Email = "anamika@gmail.com",
                PhNo = "789456123",
                Address = "xxx street",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            };

            account.Address = "New Address";
            _repo.UpdateAccount(account);
            Assert.AreEqual("New Address", _repo.ReadAllAccount().First(a => a.AccNo == 1234).Address);
        }

        [TestMethod()]
        public void DepositTest()
        {
            AccountModel account = new AccountModel
            {
                AccNo = 1234,
                Name = "Anamika",
                Balance = 0,
                AccType = "savings",
                Email = "anamika@gmail.com",
                PhNo = "789456123",
                Address = "Address",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            };

            _repo.Deposit(account.AccNo, 2000);
            Assert.AreEqual(2000, _repo.ReadAllAccount().First(ac => ac.AccNo == account.AccNo).Balance);
        }

        [TestMethod()]
        public void WithdrawTest()
        {
            var account = new AccountModel()
            {
                AccNo = 4567,
                Name = "Paru",
                Balance = 0,
                AccType = "current",
                Email = "paru@gmail.com",
                PhNo = "4561233",
                Address = "yyy street",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            };

            _repo.Deposit(account.AccNo, 500);
            _repo.Withdraw(account.AccNo, 200);
            Assert.AreEqual(300, _repo.ReadAllAccount().First(ac => ac.AccNo == account.AccNo).Balance);
        }

        [TestMethod()]
        public void ReadAllAccountTest()
        {
            _repo = AccountMemoryRepo.Instance;
            var accounts = _repo.ReadAllAccount();

            Assert.AreEqual(2, accounts.Count);
            Assert.IsTrue(accounts.Any(a => a.AccNo == 1234));
            Assert.IsTrue(accounts.Any(a => a.AccNo == 4567));
        }
    }
}