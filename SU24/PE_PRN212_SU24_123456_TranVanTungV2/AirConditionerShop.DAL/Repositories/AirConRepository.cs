using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirConditionerShop.DAL.Repositories
{
    //GUI-UI <--> service <--> repository <--> database(DAL)
    // L1           L2            L3
    // UI           BLL           DAL (CRUD TABLE)
    public class AirConRepository
    {
        private AirConditionerShop2024DbContext _context; //khi dùng mới new()

        public List<AirConditioner> GetAll()
        {
            _context = new();
            //return _context.AirConditioners.ToList();
            return _context.AirConditioners.Include("Supplier").ToList();
            //JOIM và lấy hết các thông tin của SupplierCompany
        }

        public void Add(AirConditioner x)
        {
            _context = new();
            _context.AirConditioners.Add(x);
            _context.SaveChanges(); //lưu xuống database
        }

        public void Update(AirConditioner x)
        {
            _context = new();
            _context.AirConditioners.Update(x);
            _context.SaveChanges(); //lưu xuống database
        }

        public void Delete(int id)
        {
            _context = new();
            var airCon = _context.AirConditioners.Find(id);
            if (airCon != null)
            {
                _context.AirConditioners.Remove(airCon);
                _context.SaveChanges(); //lưu xuống database
            }
        }

    }
}
