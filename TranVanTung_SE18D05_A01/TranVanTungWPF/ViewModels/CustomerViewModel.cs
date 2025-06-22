using FUMiniHotelSystem.BLL.Services;
using FUMiniHotelSystem.DAL.Models;
using FUMiniHotelSystem.DAL.Data;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TranVanTungWPF.Commands;
using System;

namespace TranVanTungWPF.ViewModels
{
    public class CustomerBookingHistory
    {
        public int BookingReservationID { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string StatusText { get; set; } = string.Empty;
        public string RoomDetails { get; set; } = string.Empty;
    }

    public class CustomerViewModel : BaseViewModel
    {
        private readonly ICustomerService _customerService;
        private Customer _customer;

        public CustomerViewModel(Customer customer, ICustomerService customerService)
        {
            _customer = customer;
            _customerService = customerService;

            BookingHistory = new ObservableCollection<CustomerBookingHistory>();
            LoadBookingHistory();

            UpdateProfileCommand = new RelayCommand(ExecuteUpdateProfile);
        }

        public Customer Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        public ObservableCollection<CustomerBookingHistory> BookingHistory { get; }

        public ICommand UpdateProfileCommand { get; }

        private void LoadBookingHistory()
        {
            BookingHistory.Clear();
            var context = DataContext.Instance;

            var bookings = context.BookingReservations
                .Where(br => br.CustomerID == Customer.CustomerID)
                .OrderByDescending(br => br.BookingDate)
                .ToList();

            foreach (var booking in bookings)
            {
                var details = context.BookingDetails
                    .Where(bd => bd.BookingReservationID == booking.BookingReservationID)
                    .ToList();

                var roomDetails = string.Join(", ", details.Select(d =>
                {
                    var room = context.Rooms.FirstOrDefault(r => r.RoomID == d.RoomID);
                    return $"Room {room?.RoomNumber} ({d.StartDate:dd/MM} - {d.EndDate:dd/MM})";
                }));

                var statusText = booking.BookingStatus switch
                {
                    1 => "Active",
                    2 => "Cancelled",
                    3 => "Completed",
                    _ => "Unknown"
                };

                BookingHistory.Add(new CustomerBookingHistory
                {
                    BookingReservationID = booking.BookingReservationID,
                    BookingDate = booking.BookingDate,
                    TotalPrice = booking.TotalPrice,
                    StatusText = statusText,
                    RoomDetails = roomDetails
                });
            }
        }

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
