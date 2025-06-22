using FUMiniHotelSystem.BLL.Services;
using FUMiniHotelSystem.DAL.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TranVanTungWPF.Commands;

namespace TranVanTungWPF.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        private readonly ICustomerService _customerService;
        private readonly IRoomService _roomService;
        private string _customerSearchText = string.Empty;
        private string _roomSearchText = string.Empty;
        private Customer? _selectedCustomer;
        private RoomInformation? _selectedRoom;

        public AdminViewModel(ICustomerService customerService, IRoomService roomService)
        {
            _customerService = customerService;
            _roomService = roomService;

            Customers = new ObservableCollection<Customer>();
            Rooms = new ObservableCollection<RoomInformation>();

            LoadCustomers();
            LoadRooms();

            // Customer commands
            AddCustomerCommand = new RelayCommand(ExecuteAddCustomer);
            EditCustomerCommand = new RelayCommand(ExecuteEditCustomer, CanExecuteEditCustomer);
            DeleteCustomerCommand = new RelayCommand(ExecuteDeleteCustomer, CanExecuteDeleteCustomer);
            SearchCustomersCommand = new RelayCommand(ExecuteSearchCustomers);

            // Room commands
            AddRoomCommand = new RelayCommand(ExecuteAddRoom);
            EditRoomCommand = new RelayCommand(ExecuteEditRoom, CanExecuteEditRoom);
            DeleteRoomCommand = new RelayCommand(ExecuteDeleteRoom, CanExecuteDeleteRoom);
            SearchRoomsCommand = new RelayCommand(ExecuteSearchRooms);
        }

        public ObservableCollection<Customer> Customers { get; }
        public ObservableCollection<RoomInformation> Rooms { get; }

        public string CustomerSearchText
        {
            get => _customerSearchText;
            set => SetProperty(ref _customerSearchText, value);
        }

        public string RoomSearchText
        {
            get => _roomSearchText;
            set => SetProperty(ref _roomSearchText, value);
        }

        public Customer? SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetProperty(ref _selectedCustomer, value);
        }

        public RoomInformation? SelectedRoom
        {
            get => _selectedRoom;
            set => SetProperty(ref _selectedRoom, value);
        }

        // Customer Commands
        public ICommand AddCustomerCommand { get; }
        public ICommand EditCustomerCommand { get; }
        public ICommand DeleteCustomerCommand { get; }
        public ICommand SearchCustomersCommand { get; }

        // Room Commands
        public ICommand AddRoomCommand { get; }
        public ICommand EditRoomCommand { get; }
        public ICommand DeleteRoomCommand { get; }
        public ICommand SearchRoomsCommand { get; }

        private void LoadCustomers()
        {
            Customers.Clear();
            var customers = _customerService.GetAllCustomers();
            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
        }

        private void LoadRooms()
        {
            Rooms.Clear();
            var rooms = _roomService.GetAllRooms();
            foreach (var room in rooms)
            {
                Rooms.Add(room);
            }
        }

        // Customer Methods
        private void ExecuteAddCustomer(object? parameter)
        {
            var dialog = new Views.CustomerDialog();
            if (dialog.ShowDialog() == true && dialog.Customer != null)
            {
                if (_customerService.AddCustomer(dialog.Customer))
                {
                    LoadCustomers();
                    MessageBox.Show("Customer added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to add customer. Please check the information.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool CanExecuteEditCustomer(object? parameter)
        {
            return SelectedCustomer != null;
        }

        private void ExecuteEditCustomer(object? parameter)
        {
            if (SelectedCustomer == null) return;

            var dialog = new Views.CustomerDialog(SelectedCustomer);
            if (dialog.ShowDialog() == true && dialog.Customer != null)
            {
                if (_customerService.UpdateCustomer(dialog.Customer))
                {
                    LoadCustomers();
                    MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update customer. Please check the information.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool CanExecuteDeleteCustomer(object? parameter)
        {
            return SelectedCustomer != null;
        }

        private void ExecuteDeleteCustomer(object? parameter)
        {
            if (SelectedCustomer == null) return;

            var result = MessageBox.Show($"Are you sure you want to delete customer '{SelectedCustomer.CustomerFullName}'?",
                "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                if (_customerService.DeleteCustomer(SelectedCustomer.CustomerID))
                {
                    LoadCustomers();
                    MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete customer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ExecuteSearchCustomers(object? parameter)
        {
            Customers.Clear();
            var customers = _customerService.SearchCustomers(CustomerSearchText);
            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
        }

        // Room Methods
        private void ExecuteAddRoom(object? parameter)
        {
            var dialog = new Views.RoomDialog(_roomService);
            if (dialog.ShowDialog() == true && dialog.Room != null)
            {
                if (_roomService.AddRoom(dialog.Room))
                {
                    LoadRooms();
                    MessageBox.Show("Room added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to add room. Please check the information.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool CanExecuteEditRoom(object? parameter)
        {
            return SelectedRoom != null;
        }

        private void ExecuteEditRoom(object? parameter)
        {
            if (SelectedRoom == null) return;

            var dialog = new Views.RoomDialog(_roomService, SelectedRoom);
            if (dialog.ShowDialog() == true && dialog.Room != null)
            {
                if (_roomService.UpdateRoom(dialog.Room))
                {
                    LoadRooms();
                    MessageBox.Show("Room updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update room. Please check the information.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool CanExecuteDeleteRoom(object? parameter)
        {
            return SelectedRoom != null;
        }

        private void ExecuteDeleteRoom(object? parameter)
        {
            if (SelectedRoom == null) return;

            var result = MessageBox.Show($"Are you sure you want to delete room '{SelectedRoom.RoomNumber}'?",
                "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                if (_roomService.DeleteRoom(SelectedRoom.RoomID))
                {
                    LoadRooms();
                    MessageBox.Show("Room deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete room.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ExecuteSearchRooms(object? parameter)
        {
            Rooms.Clear();
            var rooms = _roomService.SearchRooms(RoomSearchText);
            foreach (var room in rooms)
            {
                Rooms.Add(room);
            }
        }
    }
}
