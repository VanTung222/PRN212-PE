using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FUMiniHotelSystem.DAL.Models;

namespace FUMiniHotelSystem.DAL.Repositories
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        Customer GetCustomerById(int customerId);
        Customer GetCustomerByEmail(string email);
        List<Customer> GetAllCustomers();
        List<Customer> SearchCustomers(string searchTerm);
    }
}
