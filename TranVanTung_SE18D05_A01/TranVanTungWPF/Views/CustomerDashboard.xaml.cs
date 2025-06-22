using System.Windows;
using TranVanTungWPF.ViewModels;
using FUMiniHotelSystem.DAL.Models;
using FUMiniHotelSystem.BLL.Services;
using FUMiniHotelSystem.DAL.Repositories;

namespace TranVanTungWPF.Views
{
    public partial class CustomerDashboard : Window
    {
        public CustomerDashboard(Customer customer)
        {
            InitializeComponent();

            // Setup services
            var customerRepository = new CustomerRepository();
            var customerService = new CustomerService(customerRepository);

            DataContext = new CustomerViewModel(customer, customerService);
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
