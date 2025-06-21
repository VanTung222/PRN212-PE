using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FUMiniHotelSystem.DAL.Models;

namespace FUMiniHotelSystem.BLL.Services
{
    public interface IRoomService
    {
        void AddRoom(RoomInformation room);
        void UpdateRoom(RoomInformation room);
        void DeleteRoom(int roomId);
        RoomInformation GetRoomById(int roomId);
        List<RoomInformation> GetAllRooms();
        List<RoomInformation> SearchRooms(string searchTerm);
        List<RoomType> GetAllRoomTypes();
        bool ValidateRoom(RoomInformation room, out List<string> errors);
    }
}