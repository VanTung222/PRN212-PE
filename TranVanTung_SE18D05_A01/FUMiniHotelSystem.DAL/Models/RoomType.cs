using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// FUMiniHotelSystem.DAL/Models/RoomType.cs
using System.ComponentModel.DataAnnotations;

namespace FUMiniHotelSystem.DAL.Models
{
    public class RoomType
    {
        public int RoomTypeID { get; set; }

        [Required(ErrorMessage = "Room type name is required")]
        [StringLength(50, ErrorMessage = "Room type name cannot exceed 50 characters")]
        public string RoomTypeName { get; set; }

        [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public string TypeDescription { get; set; }

        [StringLength(250, ErrorMessage = "Note cannot exceed 250 characters")]
        public string TypeNote { get; set; }
    }
}
