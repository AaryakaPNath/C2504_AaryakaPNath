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
    /// Interaction logic for LoginPageWindow.xaml
    /// </summary>
    public partial class LoginPageWindow : Window
    {
        public LoginPageWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserName.Text == "quest" && txtPassword.Password == "1234")
            {
                AccountConfig.FrmDashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(messageBoxText: $"Invalid username or password",
                   caption: "Warning",
                   button: MessageBoxButton.OK,
                   icon: MessageBoxImage.Warning);
                return;
            }
        }
    }
}
