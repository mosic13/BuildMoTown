using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameSimulationN.Models
{
    public class CityRepo : ICityRepository
    {
        CitySimulationGameEntities _context;

        public CityRepo()
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

            BuildingTypeRepo bt = new BuildingTypeRepo();
            bt.Insert(CityId);

            return city;
        }

        public int Save()
        {
            return _context.SaveChanges();

        }
        public List<CityBuildingNew> GetCities()
        {
            var a = from c in _context.Cities
                    join cb in _context.CityBuildings on c.CityId equals cb.CityId
                    select new { c.CityId, c.CityName, c.GoldCoins } into x
                    group x by new { x.CityId, x.CityName, x.GoldCoins } into g
                    select new CityBuildingNew
                    {
                        CityId = g.Key.CityId,
                        CityName = g.Key.CityName,
                        GoldCoin = g.Key.GoldCoins,
                        Count = g.Count()
                    };


            //return _context.Cities.ToList();



            return a.ToList();//
            //_context.CityBuildings.

        }

        public City GetCityByID(int CityId)
        {

            City ObjCity = new City();

            ObjCity = (from c in _context.Cities
                       select c)
                    .Where(x => x.CityId == CityId).FirstOrDefault();

            return ObjCity;
        }

        public City CityCoinUpdate(City objCIty, bool toBeAdded)
        {

            if (toBeAdded)
                objCIty.GoldCoins = objCIty.GoldCoins + 1;
            else
                objCIty.GoldCoins = objCIty.GoldCoins - 1;

            return objCIty;

        }

        public void Create(BuildingType building)
        {
            throw new NotImplementedException();
        }
    }
}