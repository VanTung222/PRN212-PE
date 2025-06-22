using Microsoft.Extensions.Configuration;
using System.Windows;
using System.Windows.Input;
using TranVanTungWPF.Commands;
using TranVanTungWPF.Models;
using FUMiniHotelSystem.BLL.Services;

namespace TranVanTungWPF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ICustomerService _customerService;
        private readonly IConfiguration _configuration;
        private string _email = string.Empty;
        private string _password = string.Empty;
        private string _errorMessage = string.Empty;

        public LoginViewModel(ICustomerService customerService, IConfiguration configuration)
        {
            _customerService = customerService;
            _configuration = configuration;
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public ICommand LoginCommand { get; }

        private bool CanExecuteLogin(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
        }

        private void ExecuteLogin(object? parameter)
        {
            ErrorMessage = string.Empty;

            // Check admin credentials
            var adminEmail = _configuration["AdminAccount:Email"];
            var adminPassword = _configuration["AdminAccount:Password"];

            if (Email == adminEmail && Password == adminPassword)
            {
                // Open Admin Dashboard
                var adminWindow = new Views.AdminDashboard();
                adminWindow.Show();

                // Close login window
                if (parameter is Window loginWindow)
                {
                    loginWindow.Close();
                }
                return;
            }

            // Check customer credentials
            var customer = _customerService.GetCustomerByEmail(Email);
            if (customer != null && customer.Password == Password)
            {
                // Open Customer Dashboard
                var customerWindow = new Views.CustomerDashboard(customer);
                customerWindow.Show();

                // Close login window
                if (parameter is Window loginWindow)
                {
                    loginWindow.Close();
                }
                return;
            }

            ErrorMessage = "Invalid email or password.";
        }
    }
}
