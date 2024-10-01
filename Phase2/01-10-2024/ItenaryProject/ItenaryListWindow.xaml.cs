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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ItenaryProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ItenaryListWindow : Window
    {
        public ItenaryListWindow()
        {
            InitializeComponent();
            this.DataContext = ItenaryConfig.VueModel;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ItenaryConfig.FrmNewIternary.Show();
            NewIternaryWindow newIternaryWindow = (NewIternaryWindow)ItenaryConfig.FrmNewIternary;
            ItenaryConfig.VueModel.NewWindowClose = newIternaryWindow.WindowClose;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (grdIternaries.SelectedIndex == -1)
            {
                var result = MessageBox.Show(messageBoxText: "Please select iternary to edit",
                    caption: "Alert",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Information);
                return;
            }
            ItenaryConfig.FrmEditIternary.Show();
            EditItenaryWindow editIternaryWindow = (EditItenaryWindow)ItenaryConfig.FrmEditIternary;
            ItenaryConfig.VueModel.EditWindowClose = editIternaryWindow.WindowClose;
        }
    }
}

