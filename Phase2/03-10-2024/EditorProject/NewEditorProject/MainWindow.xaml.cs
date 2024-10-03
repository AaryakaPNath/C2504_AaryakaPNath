using System;
using System.Collections.Generic;
using System.IO;
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

namespace EditorNewProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.OpenFileDialog();
            var result = dlg.ShowDialog();
            using (var fs = new FileStream(dlg.FileName, FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                   txtEditor.Text = sr.ReadToEnd();
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.SaveFileDialog();
            var result = dlg.ShowDialog();
            using (var fs = new FileStream(dlg.FileName, FileMode.Create))
            {
                using(var sw = new StreamWriter(fs))
                {
                    sw.Write(txtEditor.Text);
                }
            }
        }

        private void btnFont___Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.FontDialog();
            var result = dlg.ShowDialog();
            var font = dlg.Font;
            txtEditor.FontSize = font.Size;
            txtEditor.FontFamily = new System.Windows.Media.FontFamily(font.Name);
        }

        private void btnColor_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.ColorDialog();
            var result = dlg.ShowDialog();
            var color = dlg.Color;
            var newColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
            var brush = new SolidColorBrush(newColor);
            txtEditor.Background = brush;
        }
    }
}
