using Microsoft.Extensions.Configuration;
using System.Windows;
using System.Windows.Controls;
using TranVanTungWPF.ViewModels;
using FUMiniHotelSystem.BLL.Services;
using FUMiniHotelSystem.DAL.Repositories;

namespace TranVanTungWPF.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            // Setup configuration
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Setup services
            var customerRepository = new CustomerRepository();
            var customerService = new CustomerService(customerRepository);

            DataContext = new LoginViewModel(customerService, configuration);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
