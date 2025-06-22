using FUMiniHotelSystem.BLL.Services;
using FUMiniHotelSystem.DAL.Models;
using System.Windows;
using System.Windows.Input;
using TranVanTungWPF.Commands;

namespace TranVanTungWPF.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        private readonly ICustomerService _customerService;
        private Customer _customer;

        public CustomerViewModel(Customer customer, ICustomerService customerService)
        {
            _customer = customer;
            _customerService = customerService;

            UpdateProfileCommand = new RelayCommand(ExecuteUpdateProfile);
        }

        public Customer Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        public ICommand UpdateProfileCommand { get; }

        private void ExecuteUpdateProfile(object? parameter)
        {
            var dialog = new Views.CustomerDialog(Customer);
            if (dialog.ShowDialog() == true && dialog.Customer != null)
            {
                if (_customerService.UpdateCustomer(dialog.Customer))
                {
                    Customer = dialog.Customer;
                    MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update profile. Please check the information.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
