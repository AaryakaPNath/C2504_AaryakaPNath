using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementProject
{
    public class AccountModel : INotifyPropertyChanged
    {
        private decimal _balance;
        public int AccNo { get; set; }
        public string Name { get; set; }
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }
        public string AccType { get; set; }
        public String Email { get; set; }
        public String PhNo { get; set; }

        private string _address;

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public bool IsActive { get; set; }
        public string InterestPercentage { get; set; }

        private int _transactionCount;

        public int TransactionCount
        {
            get { return _transactionCount; }
            set
            {
                _transactionCount = value;
                OnPropertyChanged(nameof(TransactionCount));
            }
        }

        private DateTime _lastTrasnsactionDate;

        public DateTime LastTransactionDate
        {
            get { return _lastTrasnsactionDate; }
            set
            {
                _lastTrasnsactionDate = value;
                OnPropertyChanged(nameof(LastTransactionDate));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}