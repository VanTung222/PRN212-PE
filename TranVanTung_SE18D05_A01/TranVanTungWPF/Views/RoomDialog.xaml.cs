using System;
using System.Linq;
using System.Windows;
using FUMiniHotelSystem.DAL.Models;
using FUMiniHotelSystem.BLL.Services;

namespace TranVanTungWPF.Views
{
    public partial class RoomDialog : Window
    {
        private readonly IRoomService _roomService;
        public RoomInformation? Room { get; private set; }

        public RoomDialog(IRoomService roomService)
        {
            InitializeComponent();
            _roomService = roomService;
            LoadRoomTypes();
        }

        public RoomDialog(IRoomService roomService, RoomInformation room) : this(roomService)
        {
            Room = room;
            LoadRoomData();
        }

        private void LoadRoomTypes()
        {
            var roomTypes = _roomService.GetAllRoomTypes().ToList();
            RoomTypeComboBox.ItemsSource = roomTypes;
        }

        private void LoadRoomData()
        {
            if (Room != null)
            {
                RoomNumberTextBox.Text = Room.RoomNumber;
                RoomDescriptionTextBox.Text = Room.RoomDescription;
                MaxCapacityTextBox.Text = Room.RoomMaxCapacity.ToString();
                PriceTextBox.Text = Room.RoomPricePerDate.ToString();
                RoomTypeComboBox.SelectedValue = Room.RoomTypeID;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(MaxCapacityTextBox.Text, out int maxCapacity))
                {
                    MessageBox.Show("Please enter a valid number for max capacity.", "Validation Error",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!decimal.TryParse(PriceTextBox.Text, out decimal price))
                {
                    MessageBox.Show("Please enter a valid price.", "Validation Error",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (RoomTypeComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Please select a room type.", "Validation Error",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var room = new RoomInformation
                {
                    RoomID = Room?.RoomID ?? 0,
                    RoomNumber = RoomNumberTextBox.Text.Trim(),
                    RoomDescription = RoomDescriptionTextBox.Text.Trim(),
                    RoomMaxCapacity = maxCapacity,
                    RoomPricePerDate = price,
                    RoomTypeID = (int)RoomTypeComboBox.SelectedValue,
                    RoomStatus = 1
                };

                if (_roomService.ValidateRoom(room, out var errors))
                {
                    Room = room;
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
