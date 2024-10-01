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

namespace ItenaryProject
{
    /// <summary>
    /// Interaction logic for NewIternaryWindow.xaml
    /// </summary>
    public partial class NewIternaryWindow : Window
    {
        public NewIternaryWindow()
        {
            InitializeComponent();
            this.DataContext = ItenaryConfig.VueModel;
        }
        public void WindowClose()
        {
            this.Hide();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}

