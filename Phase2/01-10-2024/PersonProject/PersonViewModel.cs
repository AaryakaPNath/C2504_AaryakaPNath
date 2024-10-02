using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FullNameProject
{
    public delegate void DWidnowClose();
    public class IternaryViewModel : INotifyPropertyChanged
    {
        public DWidnowClose EditWindowClose;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        private Person _selectedItenary = null;
        public Person SelectedItenary
        {
            get => _selectedItenary;
            set { _selectedItenary = value; OnPropertyChanged(nameof(SelectedItenary)); }
        }
        public ICommand UpdateCommand { get; }
    }
}
