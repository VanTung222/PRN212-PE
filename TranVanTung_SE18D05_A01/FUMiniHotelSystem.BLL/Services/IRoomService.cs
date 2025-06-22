using FUMiniHotelSystem.DAL.Models;
using System.Collections.Generic;

namespace FUMiniHotelSystem.BLL.Services
{
    public interface IRoomService
    {
        IEnumerable<RoomInformation> GetAllRooms();
        RoomInformation? GetRoomById(int id);
        bool AddRoom(RoomInformation room);
        bool UpdateRoom(RoomInformation room);
        bool DeleteRoom(int id);
        IEnumerable<RoomInformation> SearchRooms(string searchTerm);
        IEnumerable<RoomType> GetAllRoomTypes();
        bool ValidateRoom(RoomInformation room, out List<string> errors);
    }
}
