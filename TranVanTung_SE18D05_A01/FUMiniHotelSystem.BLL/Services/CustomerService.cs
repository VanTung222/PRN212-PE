using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FUMiniHotelSystem.DAL.Models;
using FUMiniHotelSystem.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace FUMiniHotelSystem.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = CustomerRepository.Instance;
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.AddCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            _customerRepository.DeleteCustomer(customerId);
        }

        public Customer GetCustomerById(int customerId)
        {
            return _customerRepository.GetCustomerById(customerId);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _customerRepository.GetCustomerByEmail(email);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public List<Customer> SearchCustomers(string searchTerm)
        {
            return _customerRepository.SearchCustomers(searchTerm);
        }

        public bool ValidateCustomer(Customer customer, out List<string> errors)
        {
            errors = new List<string>();
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(customer);
            bool isValid = Validator.TryValidateObject(customer, context, validationResults, true);

            if (!isValid)
            {
                errors.AddRange(validationResults.Select(r => r.ErrorMessage));
            }

            // Additional business rules
            if (_customerRepository.GetAllCustomers().Any(c => c.EmailAddress == customer.EmailAddress && c.CustomerID != customer.CustomerID))
            {
                errors.Add("Email address already exists.");
            }

            return errors.Count == 0;
        }

        public void AddCustomer(object customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(object customer)
        {
            throw new NotImplementedException();
        }
    }
}
