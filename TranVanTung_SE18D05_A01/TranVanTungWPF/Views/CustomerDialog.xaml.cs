using System;
using System.Windows;
using FUMiniHotelSystem.DAL.Models;
using FUMiniHotelSystem.BLL.Services;
using FUMiniHotelSystem.DAL.Repositories;

namespace TranVanTungWPF.Views
{
    public partial class CustomerDialog : Window
    {
        private readonly ICustomerService _customerService;
        public Customer? Customer { get; private set; }

        public CustomerDialog()
        {
            InitializeComponent();
            var customerRepository = new CustomerRepository();
            _customerService = new CustomerService(customerRepository);
            BirthdayDatePicker.SelectedDate = DateTime.Now.AddYears(-18);
        }

        public CustomerDialog(Customer customer) : this()
        {
            Customer = customer;
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            if (Customer != null)
            {
                FullNameTextBox.Text = Customer.CustomerFullName;
                EmailTextBox.Text = Customer.EmailAddress;
                TelephoneTextBox.Text = Customer.Telephone;
                BirthdayDatePicker.SelectedDate = Customer.CustomerBirthday;
                PasswordBox.Password = Customer.Password;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var customer = new Customer
                {
                    CustomerID = Customer?.CustomerID ?? 0,
                    CustomerFullName = FullNameTextBox.Text.Trim(),
                    EmailAddress = EmailTextBox.Text.Trim(),
                    Telephone = TelephoneTextBox.Text.Trim(),
                    CustomerBirthday = BirthdayDatePicker.SelectedDate ?? DateTime.Now,
                    Password = PasswordBox.Password,
                    CustomerStatus = 1
                };

                if (_customerService.ValidateCustomer(customer, out var errors))
                {
                    Customer = customer;
                    DialogResult = true;
                    Close();
                }
                else
                {
                    MessageBox.Show(string.Join("\n", errors), "Validation Error",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
