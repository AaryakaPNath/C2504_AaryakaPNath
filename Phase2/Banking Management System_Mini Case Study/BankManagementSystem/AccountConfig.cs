using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankManagementProject
{
    public static class AccountConfig
    {   
        public static AccountManagementWindow FrmAccountManagement =null;
        public static AddAccountWindow FrmAddAccount=null;
        public static EditAccountWindow FrmEditAccount = null;
        public static DashBoardWindow FrmDashboard =null;

        public static DepositWindow FrmDepositAccount = null;

        public static WithdrawWindow FrmWithdrawWindow = null;

        public static AccountViewModel VueModel = null;
       
        static AccountConfig()
        {
            VueModel = new AccountViewModel();
            FrmAccountManagement =new AccountManagementWindow();
            FrmDepositAccount=new DepositWindow();
            FrmWithdrawWindow=new WithdrawWindow();
            FrmAddAccount = new AddAccountWindow();
            FrmEditAccount = new EditAccountWindow();
            FrmDashboard = new DashBoardWindow();
        }
    }
}