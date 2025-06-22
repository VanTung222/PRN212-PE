using System;
using System.ComponentModel.DataAnnotations;

namespace FUMiniHotelSystem.DAL.Models
{
    public class BookingReservation
    {
        public int BookingReservationID { get; set; }

        public DateTime BookingDate { get; set; }

        public decimal TotalPrice { get; set; }

        public int CustomerID { get; set; }

        public int BookingStatus { get; set; } // 1 = Active, 2 = Cancelled, 3 = Completed

        // Navigation properties
        public Customer? Customer { get; set; }
    }
}
