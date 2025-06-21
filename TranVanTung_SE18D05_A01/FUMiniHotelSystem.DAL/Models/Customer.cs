// FUMiniHotelSystem.DAL/Models/Customer.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace FUMiniHotelSystem.DAL.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(50, ErrorMessage = "Full name cannot exceed 50 characters")]
        public string CustomerFullName { get; set; }

        [Required(ErrorMessage = "Telephone is required")]
        [StringLength(12, ErrorMessage = "Telephone cannot exceed 12 characters")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Telephone must contain only digits")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, ErrorMessage = "Email cannot exceed 50 characters")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        public DateTime CustomerBirthday { get; set; }

        public int CustomerStatus { get; set; } // 1 = Active, 2 = Deleted

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Password cannot exceed 50 characters")]
        public string Password { get; set; }
    }
}