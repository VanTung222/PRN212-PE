using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// FUMiniHotelSystem.DAL/Models/RoomInformation.cs
using System.ComponentModel.DataAnnotations;

namespace FUMiniHotelSystem.DAL.Models
{
    public class RoomInformation
    {
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Room number is required")]
        [StringLength(50, ErrorMessage = "Room number cannot exceed 50 characters")]
        public string RoomNumber { get; set; }

        [StringLength(220, ErrorMessage = "Description cannot exceed 220 characters")]
        public string RoomDescription { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Max capacity must be greater than 0")]
        public int RoomMaxCapacity { get; set; }

        public int RoomStatus { get; set; } // 1 = Active, 2 = Deleted

        [Range(0, double.MaxValue, ErrorMessage = "Price must be non-negative")]
        public decimal RoomPricePerDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Room type ID must be valid")]
        public int RoomTypeID { get; set; }
    }
}