using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FUMiniHotelSystem.DAL.Models;
using FUMiniHotelSystem.BLL.Services;
using FUMiniHotelSystem.DAL.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TranVanTungWPF.ViewModels;

namespace TranVanTungWPF.Views
{
    public partial class RoomDialog : Window
    {
        public class RoomDialogViewModel : INotifyPropertyChanged
        {
            private readonly IRoomService _roomService;
            private RoomInformation _room;
            private string _errorMessage;

            public RoomInformation Room
            {
                get => _room;
                set { _room = value; OnPropertyChanged(nameof(Room)); }
            }

            public ObservableCollection<RoomType> RoomTypes { get; }

            public string ErrorMessage
            {
                get => _errorMessage;
                set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
            }

            public string Title => Room.RoomID == 0 ? "Add Room" : "Edit Room";

            public ICommand SaveCommand { get; }
            public ICommand CancelCommand { get; }

            public RoomDialogViewModel(RoomInformation room)
            {
                _roomService = new RoomService();
                RoomTypes = new ObservableCollection<RoomType>(_roomService.GetAllRoomTypes());
                Room = room != null ? new RoomInformation
                {
                    RoomID = room.RoomID,
                    RoomNumber = room.RoomNumber,
                    RoomDescription = room.RoomDescription,
                    RoomMaxCapacity = room.RoomMaxCapacity,
                    RoomStatus = room.RoomStatus,
                    RoomPricePerDate = room.RoomPricePerDate,
                    RoomTypeID = room.RoomTypeID
                } : new RoomInformation { RoomStatus = 1 };
                SaveCommand = new RelayCommand(_ => ExecuteSave());
                CancelCommand = new RelayCommand(_ => ((Window)Application.Current.Windows.OfType<RoomDialog>().First()).DialogResult = false);
            }

            private void ExecuteSave()
            {
                if (_roomService.ValidateRoom(Room, out var errors))
                {
                    ((Window)Application.Current.Windows.OfType<RoomDialog>().First()).DialogResult = true;
                }
                else
                {
                    ErrorMessage = string.Join("\n", errors);
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public RoomInformation Room => ((RoomDialogViewModel)DataContext).Room;

        public RoomDialog(RoomInformation room)
        {
            InitializeComponent();
            DataContext = new RoomDialogViewModel(room);
        }
    }
}
