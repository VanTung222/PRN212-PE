using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FUMiniHotelSystem.DAL.Models;
using FUMiniHotelSystem.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace FUMiniHotelSystem.BLL.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService()
        {
            _roomRepository = RoomRepository.Instance;
        }

        public void AddRoom(RoomInformation room)
        {
            _roomRepository.AddRoom(room);
        }

        public void UpdateRoom(RoomInformation room)
        {
            _roomRepository.UpdateRoom(room);
        }

        public void DeleteRoom(int roomId)
        {
            _roomRepository.DeleteRoom(roomId);
        }

        public RoomInformation GetRoomById(int roomId)
        {
            return _roomRepository.GetRoomById(roomId);
        }

        public List<RoomInformation> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public List<RoomInformation> SearchRooms(string searchTerm)
        {
            return _roomRepository.SearchRooms(searchTerm);
        }

        public List<RoomType> GetAllRoomTypes()
        {
            return _roomRepository.GetAllRoomTypes();
        }

        public bool ValidateRoom(RoomInformation room, out List<string> errors)
        {
            errors = new List<string>();
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(room);
            bool isValid = Validator.TryValidateObject(room, context, validationResults, true);

            if (!isValid)
            {
                errors.AddRange(validationResults.Select(r => r.ErrorMessage));
            }

            // Additional business rules
            if (_roomRepository.GetAllRooms().Any(r => r.RoomNumber == room.RoomNumber && r.RoomID != room.RoomID))
            {
                errors.Add("Room number already exists.");
            }

            if (!_roomRepository.GetAllRoomTypes().Any(rt => rt.RoomTypeID == room.RoomTypeID))
            {
                errors.Add("Invalid room type ID.");
            }

            return errors.Count == 0;
        }
    }
}
