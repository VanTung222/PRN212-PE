using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FUMiniHotelSystem.DAL.Models;


namespace FUMiniHotelSystem.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers;
        private static CustomerRepository _instance;

        private CustomerRepository()
        {
            _customers = new List<Customer>
            {
                new Customer { CustomerID = 1, CustomerFullName = "John Doe", Telephone = "1234567890", EmailAddress = "john@example.com", CustomerBirthday = new DateTime(1990, 1, 1), CustomerStatus = 1, Password = "password123" }
            };
        }

        public static CustomerRepository Instance
        {
            get => _instance ??= new CustomerRepository(); // Singleton Pattern
        }

        public void AddCustomer(Customer customer)
        {
            customer.CustomerID = _customers.Any() ? _customers.Max(c => c.CustomerID) + 1 : 1;
            _customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            var existing = _customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (existing != null)
            {
                existing.CustomerFullName = customer.CustomerFullName;
                existing.Telephone = customer.Telephone;
                existing.EmailAddress = customer.EmailAddress;
                existing.CustomerBirthday = customer.CustomerBirthday;
                existing.CustomerStatus = customer.CustomerStatus;
                existing.Password = customer.Password;
            }
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (customer != null)
                customer.CustomerStatus = 2; // Soft delete
        }

        public Customer GetCustomerById(int customerId)
        {
            return _customers.FirstOrDefault(c => c.CustomerID == customerId && c.CustomerStatus == 1);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _customers.FirstOrDefault(c => c.EmailAddress == email && c.CustomerStatus == 1);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers.Where(c => c.CustomerStatus == 1).ToList();
        }

        public List<Customer> SearchCustomers(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return GetAllCustomers();
            return _customers
                .Where(c => c.CustomerStatus == 1 &&
                            (c.CustomerFullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                             c.EmailAddress.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }
    }
}