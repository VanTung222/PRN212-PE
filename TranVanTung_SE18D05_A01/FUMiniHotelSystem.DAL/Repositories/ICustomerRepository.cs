using FUMiniHotelSystem.DAL.Models;
using System.Collections.Generic;

namespace FUMiniHotelSystem.DAL.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer? GetById(int id);
        Customer? GetByEmail(string email);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
        IEnumerable<Customer> Search(string searchTerm);
    }
}
