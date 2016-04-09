using GameSimulationN.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameSimulationN.Models
{
    public class CityRepository : ICityRepository
    {
        CitySimulationGameEntities _context;

        public CityRepository()
        {
            _context = new CitySimulationGameEntities();
        }

        public City Create(City city)
        {
            city.CreateDate = DateTime.Now;
            city.ModifyDate = DateTime.Now;
            _context.Cities.Add(city);
            _context.SaveChanges();

            int CityId = city.CityId;

            BuildingTypeRepository bt = new BuildingTypeRepository();
            bt.Insert(CityId);

            return city;
        }

        public int Save()
        {
            return _context.SaveChanges();

        }
        public List<CityViewModel> GetCities()
        {
            //var a = from c in _context.Cities
            //        join cb in _context.CityBuildings on c.CityId equals cb.CityId
            //        select new { c.CityId, c.CityName, c.GoldCoins } into x
            //        group x by new { x.CityId, x.CityName, x.GoldCoins } into g
            //        select new CityBuildingNew
            //        {
            //            CityId = g.Key.CityId,
            //            CityName = g.Key.CityName,
            //            GoldCoin = g.Key.GoldCoins,
            //            Count = g.Count()
            //        };

            List<City> city = _context.Cities.Include(x => x.CityBuildings).ToList();
            List<CityViewModel> lstCityVM = new List<CityViewModel>();
            CityViewModel CityVM = null;

            foreach (City item in city)
            {
                CityVM = new CityViewModel();

                CityVM.CityId = item.CityId;
                CityVM.CityName = item.CityName;
                CityVM.GoldCoins = item.GoldCoins;
                CityVM.Count = item.CityBuildings.Count;
                lstCityVM.Add(CityVM);

            }

            //var a = from c in _context.Cities
            //        join cb in _context.CityBuildings on c.CityId equals cb.CityId into t
            //        //from rt in t.DefaultIfEmpty()
            //        select new { c.CityId, c.CityName, c.GoldCoins } into x
            //        group x by new { x.CityId, x.CityName, x.GoldCoins } into g
            //        select new CityBuildingNew
            //        {
            //            CityId = g.Key.CityId,
            //            CityName = g.Key.CityName,
            //            GoldCoin = g.Key.GoldCoins,
            //            Count = g.Count()
            //        };



            //return _context.Cities.ToList();



            return lstCityVM;//
            //_context.CityBuildings.

        }

        public City GetCityByID(int CityId)
        {

            City ObjCity = new City();

            ObjCity = (from c in _context.Cities
                       select c).Include(x => x.CityBuildings)
                    .Where(x => x.CityId == CityId).FirstOrDefault();

            return ObjCity;
        }

        public City CityCoinUpdate(City objCIty, bool toBeAdded)
        {

            if (toBeAdded)
                objCIty.GoldCoins = objCIty.GoldCoins + 1;
            else
                objCIty.GoldCoins = objCIty.GoldCoins - 1;

            //_context.Entry(objCIty).State = EntityState.Modified;
            //_context.SaveChanges();

            return objCIty;

        }

        public void Create(BuildingType building)
        {
            throw new NotImplementedException();
        }

        //public void Create(BuildingType building)
        //{
        //    throw new NotImplementedException();
        //}
    }
}