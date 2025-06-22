using System.Windows;
using TranVanTungWPF.ViewModels;
using FUMiniHotelSystem.BLL.Services;
using FUMiniHotelSystem.DAL.Repositories;

namespace TranVanTungWPF.Views
{
    public partial class AdminDashboard : Window
    {
        public AdminDashboard()
        {
            InitializeComponent();

            // Setup services
            var customerRepository = new CustomerRepository();
            var customerService = new CustomerService(customerRepository);
            var roomRepository = new RoomRepository();
            var roomService = new RoomService(roomRepository);

            DataContext = new AdminViewModel(customerService, roomService);
        }
    }
}
