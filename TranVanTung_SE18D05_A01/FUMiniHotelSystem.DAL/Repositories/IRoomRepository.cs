using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FUMiniHotelSystem.DAL.Models;

namespace FUMiniHotelSystem.DAL.Repositories
{
    public interface IRoomRepository
    {
        void AddRoom(RoomInformation room);
        void UpdateRoom(RoomInformation room);
        void DeleteRoom(int roomId);
        RoomInformation GetRoomById(int roomId);
        List<RoomInformation> GetAllRooms();
        List<RoomInformation> SearchRooms(string searchTerm);
        List<RoomType> GetAllRoomTypes();
    }
}
