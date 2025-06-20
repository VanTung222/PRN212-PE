using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL.Entities;

namespace AirConditionerShop.DAL.Repositories
{
    public class SupplierRepository
    {

        private AirConditionerShop2024DbContext _context; //khi dùng mới new()

        public List<SupplierCompany> GetAll()
        {
            _context = new();
            return _context.SupplierCompanies.ToList();
        }
    }
}
