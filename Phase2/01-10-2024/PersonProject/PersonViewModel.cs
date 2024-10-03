using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ItenaryProject;

namespace PersonProject
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //
        private PersonModel _displayPerson;
        public PersonModel DisplayPerson
        {
            get => _displayPerson;
            set { _displayPerson = value; OnPropertyChanged(nameof(DisplayPerson)); }
        }
        private PersonModel _editablePerson;
        public PersonModel EditablePerson
        {
            get => _editablePerson;
            set { _editablePerson = value; OnPropertyChanged(nameof(EditablePerson)); }
        }
        public ICommand UpdateCommand { get; }
        //
        public PersonViewModel()
        {
            DisplayPerson = new PersonModel { FirstName = "Aaryaka", LastName = "P Nath" };
            EditablePerson = new PersonModel { FirstName = "", LastName = "" };
            UpdateCommand = new RelayCommand(Update);
        }
        //
        public void Update()
        {
            var result = MessageBox.Show(messageBoxText: "Are you sure to update?",
                     caption: "Confirm",
                     button: MessageBoxButton.YesNo,
                     icon: MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            DisplayPerson.FirstName = EditablePerson.FirstName;
            DisplayPerson.LastName = EditablePerson.LastName;
            DisplayPerson = DisplayPerson;
            result = MessageBox.Show(messageBoxText: "Updated Successfully",
                     caption: "Alert",
                     button: MessageBoxButton.OK,
                     icon: MessageBoxImage.Information);
            if (EditClose != null) { EditClose(); }

        }
        public DClose EditClose;
        public void Edit()
        {
            EditablePerson.FirstName = DisplayPerson.FirstName;
            EditablePerson.LastName = DisplayPerson.LastName;
            EditablePerson = EditablePerson;
        }
    }
}
