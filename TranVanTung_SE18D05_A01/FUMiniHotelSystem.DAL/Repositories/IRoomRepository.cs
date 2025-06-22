using FUMiniHotelSystem.DAL.Models;
using System.Collections.Generic;

namespace FUMiniHotelSystem.DAL.Repositories
{
    public interface IRoomRepository
    {
        IEnumerable<RoomInformation> GetAll();
        RoomInformation? GetById(int id);
        void Add(RoomInformation room);
        void Update(RoomInformation room);
        void Delete(int id);
        IEnumerable<RoomInformation> Search(string searchTerm);
        IEnumerable<RoomType> GetAllRoomTypes();
    }
}
