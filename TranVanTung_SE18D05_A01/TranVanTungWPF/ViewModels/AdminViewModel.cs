using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FUMiniHotelSystem.BLL.Services;
using FUMiniHotelSystem.DAL.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using TranVanTungWPF.Views;

namespace TranVanTungWPF.ViewModels
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        private readonly ICustomerService _customerService;
        private readonly IRoomService _roomService;
        private ObservableCollection<Customer> _customers;
        private ObservableCollection<RoomInformation> _rooms;
        private string _customerSearchTerm;
        private string _roomSearchTerm;

        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set { _customers = value; OnPropertyChanged(nameof(Customers)); }
        }

        public ObservableCollection<RoomInformation> Rooms
        {
            get => _rooms;
            set { _rooms = value; OnPropertyChanged(nameof(Rooms)); }
        }

        public string CustomerSearchTerm
        {
            get => _customerSearchTerm;
            set
            {
                _customerSearchTerm = value;
                OnPropertyChanged(nameof(CustomerSearchTerm));
                SearchCustomers();
            }
        }

        public string RoomSearchTerm
        {
            get => _roomSearchTerm;
            set
            {
                _roomSearchTerm = value;
                OnPropertyChanged(nameof(RoomSearchTerm));
                SearchRooms();
            }
        }

        public ICommand AddCustomerCommand { get; }
        public ICommand EditCustomerCommand { get; }
        public ICommand DeleteCustomerCommand { get; }
        public ICommand AddRoomCommand { get; }
        public ICommand EditRoomCommand { get; }
        public ICommand DeleteRoomCommand { get; }

        public AdminViewModel()
        {
            _customerService = new CustomerService();
            _roomService = new RoomService();
            Customers = new ObservableCollection<Customer>(_customerService.GetAllCustomers());
            Rooms = new ObservableCollection<RoomInformation>(_roomService.GetAllRooms());

            AddCustomerCommand = new RelayCommand(_ => OpenCustomerDialog(null));
            EditCustomerCommand = new RelayCommand(param => OpenCustomerDialog(param as Customer), param => param != null);
            DeleteCustomerCommand = new RelayCommand(param => DeleteCustomer(param as Customer), param => param != null);
            AddRoomCommand = new RelayCommand(_ => OpenRoomDialog(null));
            EditRoomCommand = new RelayCommand(param => OpenRoomDialog(param as RoomInformation), param => param != null);
            DeleteRoomCommand = new RelayCommand(param => DeleteRoom(param as RoomInformation), param => param != null);
        }

        private void OpenCustomerDialog(Customer customer)
        {
            var dialog = new CustomerDialog(customer);
            if (dialog.ShowDialog() == true)
            {
                if (customer == null)
                {
                    _customerService.AddCustomer(dialog.Customer);
                }
                else
                {
                    _customerService.UpdateCustomer(dialog.Customer);
                }
                Customers = new ObservableCollection<Customer>(_customerService.GetAllCustomers());
            }
        }

        private void DeleteCustomer(Customer customer)
        {
            if (MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _customerService.DeleteCustomer(customer.CustomerID);
                Customers = new ObservableCollection<Customer>(_customerService.GetAllCustomers());
            }
        }

        private void OpenRoomDialog(RoomInformation room)
        {
            var dialog = new RoomDialog(room);
            if (dialog.ShowDialog() == true)
            {
                if (room == null)
                {
                    _roomService.AddRoom(dialog.Room);
                }
                else
                {
                    _roomService.UpdateRoom(dialog.Room);
                }
                Rooms = new ObservableCollection<RoomInformation>(_roomService.GetAllRooms());
            }
        }

        private void DeleteRoom(RoomInformation room)
        {
            if (MessageBox.Show("Are you sure you want to delete this room?", "Confirm Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _roomService.DeleteRoom(room.RoomID);
                Rooms = new ObservableCollection<RoomInformation>(_roomService.GetAllRooms());
            }
        }

        private void SearchCustomers()
        {
            Customers = new ObservableCollection<Customer>(_customerService.SearchCustomers(CustomerSearchTerm));
        }

        private void SearchRooms()
        {
            Rooms = new ObservableCollection<RoomInformation>(_roomService.SearchRooms(RoomSearchTerm));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
