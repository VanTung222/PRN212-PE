using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL.Entities;
using AirConditionerShop.DAL.Repositories;

namespace AirConditionerShop.BLL.Services
{
    public class SupplierService
    {
        SupplierRepository repo = new();

        public List<SupplierCompany> GetAllSuppliers()
        {
            return repo.GetAll();
        }

    }
}
