using FUMiniHotelSystem.BLL.Validators;
using FUMiniHotelSystem.DAL.Models;
using FUMiniHotelSystem.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FUMiniHotelSystem.BLL.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly RoomValidator _validator;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
            _validator = new RoomValidator();
        }

        public IEnumerable<RoomInformation> GetAllRooms()
        {
            return _roomRepository.GetAll();
        }

        public RoomInformation? GetRoomById(int id)
        {
            return _roomRepository.GetById(id);
        }

        public bool AddRoom(RoomInformation room)
        {
            if (!ValidateRoom(room, out var errors))
                return false;

            // Check if room number already exists
            if (_roomRepository.GetAll().Any(r => r.RoomNumber == room.RoomNumber))
                return false;

            _roomRepository.Add(room);
            return true;
        }

        public bool UpdateRoom(RoomInformation room)
        {
            if (!ValidateRoom(room, out var errors))
                return false;

            // Check if room number already exists for another room
            var existingRoom = _roomRepository.GetAll().FirstOrDefault(r => r.RoomNumber == room.RoomNumber);
            if (existingRoom != null && existingRoom.RoomID != room.RoomID)
                return false;

            _roomRepository.Update(room);
            return true;
        }

        public bool DeleteRoom(int id)
        {
            var room = _roomRepository.GetById(id);
            if (room == null)
                return false;

            _roomRepository.Delete(id);
            return true;
        }

        public IEnumerable<RoomInformation> SearchRooms(string searchTerm)
        {
            return _roomRepository.Search(searchTerm);
        }

        public IEnumerable<RoomType> GetAllRoomTypes()
        {
            return _roomRepository.GetAllRoomTypes();
        }

        public bool ValidateRoom(RoomInformation room, out List<string> errors)
        {
            return _validator.Validate(room, out errors);
        }
    }
}
