using FUMiniHotelSystem.DAL.Data;
using FUMiniHotelSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace FUMiniHotelSystem.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository()
        {
            _context = DataContext.Instance;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.Where(c => c.CustomerStatus == 1).OrderByDescending(c => c.CustomerID);
        }

        public Customer? GetById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerID == id && c.CustomerStatus == 1);
        }

        public Customer? GetByEmail(string email)
        {
            return _context.Customers.FirstOrDefault(c => c.EmailAddress == email && c.CustomerStatus == 1);
        }

        public void Add(Customer customer)
        {
            customer.CustomerID = _context.GetNextCustomerId();
            customer.CustomerStatus = 1;
            _context.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            var existingCustomer = _context.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (existingCustomer != null)
            {
                existingCustomer.CustomerFullName = customer.CustomerFullName;
                existingCustomer.Telephone = customer.Telephone;
                existingCustomer.EmailAddress = customer.EmailAddress;
                existingCustomer.CustomerBirthday = customer.CustomerBirthday;
                existingCustomer.Password = customer.Password;
            }
        }

        public void Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerID == id);
            if (customer != null)
            {
                customer.CustomerStatus = 2; // Soft delete
            }
        }

        public IEnumerable<Customer> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return GetAll();

            return _context.Customers
                .Where(c => c.CustomerStatus == 1 &&
                           (c.CustomerFullName.Contains(searchTerm) ||
                            c.EmailAddress.Contains(searchTerm) ||
                            c.Telephone.Contains(searchTerm)))
                .OrderByDescending(c => c.CustomerID);
        }
    }
}
