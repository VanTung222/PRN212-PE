using FUMiniHotelSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FUMiniHotelSystem.BLL.Validators
{
    public class CustomerValidator
    {
        public bool Validate(Customer customer, out List<string> errors)
        {
            errors = new List<string>();

            // Validate CustomerFullName
            if (string.IsNullOrWhiteSpace(customer.CustomerFullName))
                errors.Add("Customer full name is required.");
            else if (customer.CustomerFullName.Length > 50)
                errors.Add("Customer full name cannot exceed 50 characters.");

            // Validate EmailAddress
            if (string.IsNullOrWhiteSpace(customer.EmailAddress))
                errors.Add("Email address is required.");
            else if (customer.EmailAddress.Length > 50)
                errors.Add("Email address cannot exceed 50 characters.");
            else if (!IsValidEmail(customer.EmailAddress))
                errors.Add("Email address format is invalid.");

            // Validate Telephone
            if (!string.IsNullOrWhiteSpace(customer.Telephone) && customer.Telephone.Length > 12)
                errors.Add("Telephone cannot exceed 12 characters.");

            // Validate Password
            if (string.IsNullOrWhiteSpace(customer.Password))
                errors.Add("Password is required.");
            else if (customer.Password.Length > 50)
                errors.Add("Password cannot exceed 50 characters.");

            // Validate CustomerBirthday
            if (customer.CustomerBirthday > DateTime.Now)
                errors.Add("Birthday cannot be in the future.");

            return errors.Count == 0;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }
    }
}
