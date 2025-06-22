using FUMiniHotelSystem.DAL.Models;
using System.Collections.Generic;

namespace FUMiniHotelSystem.BLL.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer? GetCustomerById(int id);
        Customer? GetCustomerByEmail(string email);
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);
        IEnumerable<Customer> SearchCustomers(string searchTerm);
        bool ValidateCustomer(Customer customer, out List<string> errors);
    }
}
