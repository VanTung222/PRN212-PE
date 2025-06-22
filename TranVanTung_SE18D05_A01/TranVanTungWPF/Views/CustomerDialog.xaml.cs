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
using FUMiniHotelSystem.DAL.Models;
using FUMiniHotelSystem.BLL.Services;
using FUMiniHotelSystem.DAL.Models;
using System.ComponentModel;
using TranVanTungWPF.ViewModels;

namespace TranVanTungWPF.Views
{
    public partial class CustomerDialog : Window
    {
        public class CustomerDialogViewModel : INotifyPropertyChanged
        {
            private readonly ICustomerService _customerService;
            private Customer _customer;
            private string _errorMessage;

            public Customer Customer
            {
                get => _customer;
                set { _customer = value; OnPropertyChanged(nameof(Customer)); }
            }

            public string ErrorMessage
            {
                get => _errorMessage;
                set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
            }

            public string Title => Customer.CustomerID == 0 ? "Add Customer" : "Edit Customer";

            public ICommand SaveCommand { get; }
            public ICommand CancelCommand { get; }

            public CustomerDialogViewModel(Customer customer)
            {
                _customerService = new CustomerService();
                Customer = customer != null ? new Customer
                {
                    CustomerID = customer.CustomerID,
                    CustomerFullName = customer.CustomerFullName,
                    Telephone = customer.Telephone,
                    EmailAddress = customer.EmailAddress,
                    CustomerBirthday = customer.CustomerBirthday,
                    CustomerStatus = customer.CustomerStatus,
                    Password = customer.Password
                } : new Customer { CustomerStatus = 1 };
                SaveCommand = new RelayCommand(ExecuteSave);
                CancelCommand = new RelayCommand(_ => ((Window)Application.Current.Windows.OfType<CustomerDialog>().First()).DialogResult = false);
            }

            private void ExecuteSave(object parameter)
            {
                Customer.Password = parameter as string;
                if (_customerService.ValidateCustomer(Customer, out var errors))
                {
                    ((Window)Application.Current.Windows.OfType<CustomerDialog>().First()).DialogResult = true;
                }
                else
                {
                    ErrorMessage = string.Join("\n", errors);
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Customer Customer => ((CustomerDialogViewModel)DataContext).Customer;

        public CustomerDialog(Customer customer)
        {
            InitializeComponent();
            DataContext = new CustomerDialogViewModel(customer);
        }
    }
}