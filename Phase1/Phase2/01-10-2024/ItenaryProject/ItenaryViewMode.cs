using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ItenaryProject
{
    public delegate void DWidnowClose();
    public class IternaryViewModel : INotifyPropertyChanged
    {
        public DWidnowClose NewWindowClose;
        public DWidnowClose EditWindowClose;
        //
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        //        
        private Itenary _newItenary = null;
        public Itenary NewItenary
        {
            get => _newItenary;
            set { _newItenary = value; OnPropertyChanged(nameof(NewItenary)); }
        }
        //
        private Itenary _selectedItenary = null;
        public Itenary SelectedItenary
        {
            get => _selectedItenary;
            set { _selectedItenary = value; OnPropertyChanged(nameof(SelectedItenary)); }
        }
        //
        private ObservableCollection<Itenary> _iternaries = null;
        public ObservableCollection<Itenary> Iternaries
        {
            get => _iternaries;
            set { _iternaries = value; OnPropertyChanged(nameof(Iternaries)); }
        }
        //
        public ICommand CreateCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        //
        public IternaryViewModel()
        {
            this.NewItenary = new Itenary { Id = 0, Time = "01:00am", ItenaryName = "z", About = "z", Price = 1 };
            this.Iternaries = new ObservableCollection<Itenary>
            {
                new Itenary{Id=1,Time="09:00am",ItenaryName="a",About="a",Price=10},
                new Itenary{Id=2,Time="11:00am",ItenaryName="b",About="b",Price=20}
            };
            CreateCommand = new RelayCommand(Create);
            UpdateCommand = new RelayCommand(Update);
            DeleteCommand = new RelayCommand(Delete);
        }
        public void Create()
        {
            int id = 1;
            if (Iternaries.Count > 0)
            {
                id = Iternaries[Iternaries.Count - 1].Id + 1;
            }
            Itenary newIternary = new Itenary
            {
                Id = id,
                Time = NewItenary.Time,
                ItenaryName = NewItenary.ItenaryName,
                About = NewItenary.About,
                Price = NewItenary.Price
            };
            var result = MessageBox.Show(messageBoxText: "Are you sure to create?",
                    caption: "Confirm",
                    button: MessageBoxButton.YesNo,
                    icon: MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            Iternaries.Add(newIternary);
            this.NewItenary = new Itenary { Id = 0, Time = "01:00am", ItenaryName = "z", About = "z", Price = 1 };
            //this.NewItenary.Id = 0;
            //..
            //this.NewItenary = NewItenary;
            result = MessageBox.Show(messageBoxText: "Created Successfully",
                    caption: "Alert",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Information);
            if (NewWindowClose != null)
            {
                NewWindowClose();
            }

        }
        public void Update()
        {
            if (this.SelectedItenary == null)
            {
                return;
            }
            this.SelectedItenary = this.SelectedItenary;
            var result = MessageBox.Show(messageBoxText: "Updated Successfully",
                    caption: "Alert",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Information);
            if (EditWindowClose != null)
            {
                EditWindowClose();
            }
        }
        public void Delete()
        {
            if (this.SelectedItenary == null)
            {
                return;
            }
            this.Iternaries.Remove(this.SelectedItenary);
            this.SelectedItenary = null;
        }
    }
}
