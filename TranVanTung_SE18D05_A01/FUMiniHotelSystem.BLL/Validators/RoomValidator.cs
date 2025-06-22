using FUMiniHotelSystem.DAL.Models;
using System.Collections.Generic;

namespace FUMiniHotelSystem.BLL.Validators
{
    public class RoomValidator
    {
        public bool Validate(RoomInformation room, out List<string> errors)
        {
            errors = new List<string>();

            // Validate RoomNumber
            if (string.IsNullOrWhiteSpace(room.RoomNumber))
                errors.Add("Room number is required.");
            else if (room.RoomNumber.Length > 50)
                errors.Add("Room number cannot exceed 50 characters.");

            // Validate RoomDescription
            if (!string.IsNullOrWhiteSpace(room.RoomDescription) && room.RoomDescription.Length > 220)
                errors.Add("Room description cannot exceed 220 characters.");

            // Validate RoomMaxCapacity
            if (room.RoomMaxCapacity <= 0)
                errors.Add("Room max capacity must be greater than 0.");

            // Validate RoomPricePerDate
            if (room.RoomPricePerDate <= 0)
                errors.Add("Room price per date must be greater than 0.");

            // Validate RoomTypeID
            if (room.RoomTypeID <= 0)
                errors.Add("Room type is required.");

            return errors.Count == 0;
        }
    }
}
