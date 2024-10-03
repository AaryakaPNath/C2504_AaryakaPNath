using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ItenaryProject;

namespace CounterProject
{
    public class CounterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private CounterModel _newCounter;
        public CounterModel NewCounter
        {
            get => _newCounter;
            set { _newCounter = value; OnPropertyChanged(nameof(NewCounter)); }
        }
        public ICommand PlusCommand { get; }
        public ICommand MinusCommand { get; }
        public CounterViewModel()
        {
            NewCounter = new CounterModel {Number = 0 };

            PlusCommand = new RelayCommand(Plus);
            MinusCommand = new RelayCommand(Minus);
        }
        public void Plus()
        {
            NewCounter.Number++;
            NewCounter = NewCounter;

        }
        public void Minus()
        {
            NewCounter.Number--;
            NewCounter = NewCounter;

        }
    }
}
