using System;
using System.ComponentModel.DataAnnotations;

namespace FUMiniHotelSystem.DAL.Models
{
    public class BookingDetail
    {
        public int BookingReservationID { get; set; }

        public int RoomID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal ActualPrice { get; set; }

        // Navigation properties
        public BookingReservation? BookingReservation { get; set; }
        public RoomInformation? RoomInformation { get; set; }
    }
}
