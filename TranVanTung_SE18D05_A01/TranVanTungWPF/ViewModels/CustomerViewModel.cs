using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FUMiniHotelSystem.BLL.Services;
using FUMiniHotelSystem.DAL.Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using TranVanTungWPF.Views;

namespace TranVanTungWPF.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private readonly ICustomerService _customerService;
        private Customer _customer;

        public Customer Customer
        {
            get => _customer;
            set { _customer = value; OnPropertyChanged(nameof(Customer)); }
        }

        public ICommand UpdateProfileCommand { get; }

        public CustomerViewModel(Customer customer)
        {
            _customerService = new CustomerService();
            Customer = customer;
            UpdateProfileCommand = new RelayCommand(_ => UpdateProfile());
        }

        private void UpdateProfile()
        {
            var dialog = new CustomerDialog(Customer);
            if (dialog.ShowDialog() == true)
            {
                _customerService.UpdateCustomer(dialog.Customer);
                Customer = _customerService.GetCustomerById(dialog.Customer.CustomerID);
                MessageBox.Show("Profile updated successfully.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
