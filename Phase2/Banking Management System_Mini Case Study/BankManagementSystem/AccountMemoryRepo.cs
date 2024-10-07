using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace BankManagementProject
{
    public class AccountMemoryRepo : IAccountRepo
    {
        private static AccountMemoryRepo _instance;
        public ObservableCollection<AccountModel> accounts = new ObservableCollection<AccountModel>()
        {
            new AccountModel
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


            },
            new AccountModel
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


            }
        };
        public static AccountMemoryRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountMemoryRepo();
                }
                return _instance;
            }
        }

        public void Create(AccountModel accModel)
        {
            try
            {
                accounts.Add(accModel);
            }
            catch (AccountException ae)
            {
                throw new AccountException("Error in creating account");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateAccount(AccountModel accModel)
        {
            try
            {
                var existingAccount = accounts.FirstOrDefault(a => a.AccNo == accModel.AccNo);
                if (existingAccount != null)
                {
                    existingAccount.Address = accModel.Address;
                }
                else
                {
                    throw new AccountException("Account doesn't exists");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ObservableCollection<AccountModel> ReadAllAccount()
        {
            try
            {
                return accounts;
            }
            catch (AccountException ae)
            {
                throw new AccountException("Error reading accounts");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteAccount(AccountModel accModel)
        {

            foreach (var ac in accounts)
            {
                if (ac.AccNo == accModel.AccNo)
                {
                    ac.Address = accModel.Address;
                }
            }
        }

        public void Deposit(int acNo, int Amount)
        {
            try
            {
                var account = accounts.FirstOrDefault(a => a.AccNo == acNo);
                if (account != null)
                {
                    account.Balance = account.Balance + Amount;
                    account.LastTransactionDate = DateTime.Now;
                    account.TransactionCount = account.TransactionCount + 1;

                }
                else
                {
                    throw new AccountException("Account Not Found , Please input valid account number");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Withdraw(int acNo, int Amount)
        {
            try
            {
                var account = accounts.FirstOrDefault(a => a.AccNo == acNo);
                if (account != null)
                {
                    if (account.Balance < Amount)
                    {
                        throw new AccountException("Insufficient balance");

                    }
                    account.Balance = account.Balance - Amount;
                    account.LastTransactionDate = DateTime.Now;
                    account.TransactionCount = account.TransactionCount + 1;

                }
                else
                {
                    throw new AccountException("Account Not Found , Please input valid account number");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CalculateInterestAndUpdateBalance()
        {
            throw new NotImplementedException();
        }

        
    }
}
