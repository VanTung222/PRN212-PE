using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL.Entities;
using AirConditionerShop.DAL.Repositories;

namespace AirConditionerShop.BLL.Services
{
    //GUI-UI <--> service <--> repository <--> database(DAL)
    // L1           L2            L3
    // UI           BLL           DAL (CRUD TABLE)
    public class AirConService
    {

        private AirConRepository _repo = new(); 
        //Hàm CRUD++, tên hàm đặt dễ hiển, gắn liên với User
        public List<AirConditioner> GetAllAirCons()
        {
            return _repo.GetAll();
        }

        public void AddAirCon(AirConditioner x)
        {
            _repo.Add(x);
        }

        public void UpdateAirCon(AirConditioner x)
        {
            _repo.Update(x);
        }
        public void DeleteAirCon(int id)
        {
            _repo.Delete(id);
        }

        // hàm search sản phầm theo tiêu chí 
        public List<AirConditioner> SearchAirConsByFeatureQuantity(string fearture, int quantity)
        {
            var allAirCons = _repo.GetAll();
            return allAirCons.Where(ac => ac.FeatureFunction.Contains(fearture) && ac.Quantity >= quantity).ToList();
        }

    }
}
