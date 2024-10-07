using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementProject
{
    public interface IAccountRepo
    {
        void Create(AccountModel accModel);

        void UpdateAccount(AccountModel accModel);

        void DeleteAccount(AccountModel account);
        void Deposit(int acNo, int Amount);
        void Withdraw(int acNo, int Amount);
        void CalculateInterestAndUpdateBalance();
        ObservableCollection<AccountModel> ReadAllAccount();

    }
}