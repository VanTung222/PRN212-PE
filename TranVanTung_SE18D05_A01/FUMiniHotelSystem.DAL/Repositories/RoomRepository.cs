using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FUMiniHotelSystem.DAL.Models;


namespace FUMiniHotelSystem.DAL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly List<RoomInformation> _rooms;
        private readonly List<RoomType> _roomTypes;
        private static RoomRepository _instance;

        private RoomRepository()
        {
            _roomTypes = new List<RoomType>
            {
                new RoomType { RoomTypeID = 1, RoomTypeName = "Standard", TypeDescription = "Basic room", TypeNote = "" },
                new RoomType { RoomTypeID = 2, RoomTypeName = "Deluxe", TypeDescription = "Room with view", TypeNote = "" }
            };

            _rooms = new List<RoomInformation>
            {
                new RoomInformation { RoomID = 1, RoomNumber = "101", RoomDescription = "Standard room", RoomMaxCapacity = 2, RoomStatus = 1, RoomPricePerDate = 500000, RoomTypeID = 1 }
            };
        }

        public static RoomRepository Instance
        {
            get => _instance ??= new RoomRepository(); // Singleton Pattern
        }

        public void AddRoom(RoomInformation room)
        {
            room.RoomID = _rooms.Any() ? _rooms.Max(r => r.RoomID) + 1 : 1;
            _rooms.Add(room);
        }

        public void UpdateRoom(RoomInformation room)
        {
            var existing = _rooms.FirstOrDefault(r => r.RoomID == room.RoomID);
            if (existing != null)
            {
                existing.RoomNumber = room.RoomNumber;
                existing.RoomDescription = room.RoomDescription;
                existing.RoomMaxCapacity = room.RoomMaxCapacity;
                existing.RoomStatus = room.RoomStatus;
                existing.RoomPricePerDate = room.RoomPricePerDate;
                existing.RoomTypeID = room.RoomTypeID;
            }
        }

        public void DeleteRoom(int roomId)
        {
            var room = _rooms.FirstOrDefault(r => r.RoomID == roomId);
            if (room != null)
                room.RoomStatus = 2; // Soft delete
        }

        public RoomInformation GetRoomById(int roomId)
        {
            return _rooms.FirstOrDefault(r => r.RoomID == roomId && r.RoomStatus == 1);
        }

        public List<RoomInformation> GetAllRooms()
        {
            return _rooms.Where(r => r.RoomStatus == 1).ToList();
        }

        public List<RoomInformation> SearchRooms(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return GetAllRooms();
            return _rooms
                .Where(r => r.RoomStatus == 1 &&
                            (r.RoomNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                             r.RoomDescription.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        public List<RoomType> GetAllRoomTypes()
        {
            return _roomTypes;
        }
    }
}
