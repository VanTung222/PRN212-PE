using FUMiniHotelSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace FUMiniHotelSystem.DAL.Data
{
    public class DataContext
    {
        private static DataContext? _instance;
        private static readonly object _lock = new object();

        public List<Customer> Customers { get; set; }
        public List<RoomType> RoomTypes { get; set; }
        public List<RoomInformation> Rooms { get; set; }

        private DataContext()
        {
            InitializeData();
        }

        public static DataContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new DataContext();
                    }
                }
                return _instance;
            }
        }

        private void InitializeData()
        {
            // Initialize Room Types
            RoomTypes = new List<RoomType>
            {
                new RoomType { RoomTypeID = 1, RoomTypeName = "Standard", TypeDescription = "Standard room with basic amenities", TypeNote = "Budget-friendly option" },
                new RoomType { RoomTypeID = 2, RoomTypeName = "Deluxe", TypeDescription = "Deluxe room with premium amenities", TypeNote = "Mid-range option" },
                new RoomType { RoomTypeID = 3, RoomTypeName = "Suite", TypeDescription = "Luxury suite with all amenities", TypeNote = "Premium option" }
            };

            // Initialize Rooms
            Rooms = new List<RoomInformation>
            {
                new RoomInformation { RoomID = 1, RoomNumber = "101", RoomDescription = "Standard room on first floor", RoomMaxCapacity = 2, RoomStatus = 1, RoomPricePerDate = 500000, RoomTypeID = 1 },
                new RoomInformation { RoomID = 2, RoomNumber = "102", RoomDescription = "Standard room with city view", RoomMaxCapacity = 2, RoomStatus = 1, RoomPricePerDate = 550000, RoomTypeID = 1 },
                new RoomInformation { RoomID = 3, RoomNumber = "201", RoomDescription = "Deluxe room with balcony", RoomMaxCapacity = 4, RoomStatus = 1, RoomPricePerDate = 800000, RoomTypeID = 2 },
                new RoomInformation { RoomID = 4, RoomNumber = "301", RoomDescription = "Luxury suite with ocean view", RoomMaxCapacity = 6, RoomStatus = 1, RoomPricePerDate = 1200000, RoomTypeID = 3 }
            };

            // Initialize Customers
            Customers = new List<Customer>
            {
                new Customer { CustomerID = 1, CustomerFullName = "Nguyen Van A", Telephone = "0123456789", EmailAddress = "nguyenvana@email.com", CustomerBirthday = new DateTime(1990, 1, 1), CustomerStatus = 1, Password = "123456" },
                new Customer { CustomerID = 2, CustomerFullName = "Tran Thi B", Telephone = "0987654321", EmailAddress = "tranthib@email.com", CustomerBirthday = new DateTime(1985, 5, 15), CustomerStatus = 1, Password = "123456" }
            };
        }

        public int GetNextCustomerId()
        {
            return Customers.Any() ? Customers.Max(c => c.CustomerID) + 1 : 1;
        }

        public int GetNextRoomId()
        {
            return Rooms.Any() ? Rooms.Max(r => r.RoomID) + 1 : 1;
        }

        public int GetNextRoomTypeId()
        {
            return RoomTypes.Any() ? RoomTypes.Max(rt => rt.RoomTypeID) + 1 : 1;
        }
    }
}
