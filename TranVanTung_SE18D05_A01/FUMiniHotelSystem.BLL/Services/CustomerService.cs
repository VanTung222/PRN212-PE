using FUMiniHotelSystem.BLL.Validators;
using FUMiniHotelSystem.DAL.Models;
using FUMiniHotelSystem.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FUMiniHotelSystem.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerValidator _validator;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _validator = new CustomerValidator();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer? GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public Customer? GetCustomerByEmail(string email)
        {
            return _customerRepository.GetByEmail(email);
        }

        public bool AddCustomer(Customer customer)
        {
            if (!ValidateCustomer(customer, out var errors))
                return false;

            // Check if email already exists
            if (_customerRepository.GetByEmail(customer.EmailAddress) != null)
                return false;

            _customerRepository.Add(customer);
            return true;
        }

        public bool UpdateCustomer(Customer customer)
        {
            if (!ValidateCustomer(customer, out var errors))
                return false;

            // Check if email already exists for another customer
            var existingCustomer = _customerRepository.GetByEmail(customer.EmailAddress);
            if (existingCustomer != null && existingCustomer.CustomerID != customer.CustomerID)
                return false;

            _customerRepository.Update(customer);
            return true;
        }

        public bool DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
                return false;

            _customerRepository.Delete(id);
            return true;
        }

        public IEnumerable<Customer> SearchCustomers(string searchTerm)
        {
            return _customerRepository.Search(searchTerm);
        }

        public bool ValidateCustomer(Customer customer, out List<string> errors)
        {
            return _validator.Validate(customer, out errors);
        }
    }
}
