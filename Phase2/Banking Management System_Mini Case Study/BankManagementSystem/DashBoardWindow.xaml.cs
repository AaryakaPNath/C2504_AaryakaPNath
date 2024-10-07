using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankManagementProject
{
    /// <summary>
    /// Interaction logic for DashBoardWindow.xaml
    /// </summary>
    public partial class DashBoardWindow : Window
    {
        public DashBoardWindow()
        {
            InitializeComponent();
        }

        private void btnAccMng_Click(object sender, RoutedEventArgs e)
        {
            AccountConfig.FrmAccountManagement.Show();
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            AccountConfig.FrmDepositAccount.Show();
        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            AccountConfig.FrmWithdrawWindow.Show();
        }

        private void btnBalance_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
