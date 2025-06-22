using FUMiniHotelSystem.DAL.Data;
using FUMiniHotelSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace FUMiniHotelSystem.DAL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext _context;

        public RoomRepository()
        {
            _context = DataContext.Instance;
        }

        public IEnumerable<RoomInformation> GetAll()
        {
            return _context.Rooms
                .Where(r => r.RoomStatus == 1)
                .Select(r => new RoomInformation
                {
                    RoomID = r.RoomID,
                    RoomNumber = r.RoomNumber,
                    RoomDescription = r.RoomDescription,
                    RoomMaxCapacity = r.RoomMaxCapacity,
                    RoomStatus = r.RoomStatus,
                    RoomPricePerDate = r.RoomPricePerDate,
                    RoomTypeID = r.RoomTypeID,
                    RoomType = _context.RoomTypes.FirstOrDefault(rt => rt.RoomTypeID == r.RoomTypeID)
                })
                .OrderByDescending(r => r.RoomID);
        }

        public RoomInformation? GetById(int id)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.RoomID == id && r.RoomStatus == 1);
            if (room != null)
            {
                room.RoomType = _context.RoomTypes.FirstOrDefault(rt => rt.RoomTypeID == room.RoomTypeID);
            }
            return room;
        }

        public void Add(RoomInformation room)
        {
            room.RoomID = _context.GetNextRoomId();
            room.RoomStatus = 1;
            _context.Rooms.Add(room);
        }

        public void Update(RoomInformation room)
        {
            var existingRoom = _context.Rooms.FirstOrDefault(r => r.RoomID == room.RoomID);
            if (existingRoom != null)
            {
                existingRoom.RoomNumber = room.RoomNumber;
                existingRoom.RoomDescription = room.RoomDescription;
                existingRoom.RoomMaxCapacity = room.RoomMaxCapacity;
                existingRoom.RoomPricePerDate = room.RoomPricePerDate;
                existingRoom.RoomTypeID = room.RoomTypeID;
            }
        }

        public void Delete(int id)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.RoomID == id);
            if (room != null)
            {
                room.RoomStatus = 2; // Soft delete
            }
        }

        public IEnumerable<RoomInformation> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return GetAll();

            return _context.Rooms
                .Where(r => r.RoomStatus == 1 &&
                           (r.RoomNumber.Contains(searchTerm) ||
                            r.RoomDescription.Contains(searchTerm)))
                .Select(r => new RoomInformation
                {
                    RoomID = r.RoomID,
                    RoomNumber = r.RoomNumber,
                    RoomDescription = r.RoomDescription,
                    RoomMaxCapacity = r.RoomMaxCapacity,
                    RoomStatus = r.RoomStatus,
                    RoomPricePerDate = r.RoomPricePerDate,
                    RoomTypeID = r.RoomTypeID,
                    RoomType = _context.RoomTypes.FirstOrDefault(rt => rt.RoomTypeID == r.RoomTypeID)
                })
                .OrderByDescending(r => r.RoomID);
        }

        public IEnumerable<RoomType> GetAllRoomTypes()
        {
            return _context.RoomTypes;
        }
    }
}
