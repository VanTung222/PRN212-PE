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
using Microsoft.Extensions.Configuration;
using System.IO;
using FluentNHibernate;

namespace TranVanTungWPF.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly ICustomerService _customerService;
        private string _email;
        private string _password;
        private string _errorMessage;

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _customerService = new CustomerService();
            LoginCommand = new RelayCommand(ExecuteLogin);
        }

        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // path đến thư mục chạy
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }

        private void ExecuteLogin(object parameter)
        {
            //IConfiguration config = ConfigurationHelper.LoadConfiguration();

            // With this corrected implementation:
            IConfiguration config = LoadConfiguration();

            //IConfiguration config = ConfigurationHelper.LoadConfiguration();
            string adminEmail = config["AdminAccount:Email"];
            string adminPassword = config["AdminAccount:Password"];

            if (Email == adminEmail && Password == adminPassword)
            {
                var adminDashboard = new AdminDashboard();
                adminDashboard.Show();
                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = adminDashboard;
                return;
            }

            var customer = _customerService.GetCustomerByEmail(Email);
            if (customer != null && customer.Password == Password && customer.CustomerStatus == 1)
            {
                var customerDashboard = new CustomerDashboard(customer);
                customerDashboard.Show();
                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = customerDashboard;
            }
            else
            {
                ErrorMessage = "Invalid email or password.";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
        public void Execute(object parameter) => _execute(parameter);
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
