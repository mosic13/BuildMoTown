using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSimulationN.Models
{
    public class BuildingRepository : IBuildingRepository
    {
        CitySimulationGameEntities _context;
        CityRepository _cityRepo;
        public BuildingRepository()
        {
            _context = new CitySimulationGameEntities();
            _cityRepo = new CityRepository();
        }



        public List<Building> GetBuildingByCity(int CityId)
        {
            var a = (from cb in _context.CityBuildings
                     join c in _context.Cities on cb.CityId equals c.CityId
                     join bt in _context.BuildingTypes on cb.BuildingId equals bt.BuildingId
                     select new Building
                     {
                         CityId = c.CityId,
                         CityName = c.CityName,
                         BuildingId = bt.BuildingId,
                         BuildingName = bt.BuildingName,
                         Levels = cb.Levels,
                         GoldCoins = c.GoldCoins,
                         IsDefault = bt.IsDefault
                     }).Where(x => x.CityId == CityId);
            

            return a.ToList();//

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        //[AsyncTimeout(6000)]
        public void Create(BuildingType Building, int CityId)
        {
            var city = _cityRepo.GetCityByID(CityId);
            BuildingType bt = new BuildingType();
            bt.BuildingName = Building.BuildingName;
            bt.CreateDate = DateTime.Now;
            bt.ModifyDate = DateTime.Now;
            bt.IsDefault = false;


            if (Building.BuildingId > 0)
            {
                _context.Entry(Building).State = EntityState.Modified;
            }
            else {
                _context.BuildingTypes.Add(bt);
            }
            _context.SaveChanges();

            if (Building.BuildingId < 1)
            {
                int buildingTypeId = bt.BuildingId;

                CityBuilding cb = new CityBuilding();
                cb.BuildingId = buildingTypeId;
                cb.CityId = CityId;
                cb.Levels = 0;
                cb.CreateDate = DateTime.Now;
                cb.ModifyDate = DateTime.Now;
                _context.CityBuildings.Add(cb);
                _context.SaveChanges();


                UpdateCoin_Create(CityId);

          
            }

        }

        public void UpgradeLevel(int CityId, int BuildingId)
        {
            CityBuilding cBld = new CityBuilding();
            cBld = GetCityBuildingByCBId(CityId, BuildingId);
            cBld.Levels = cBld.Levels + 1;
            _context.Entry(cBld).State = EntityState.Modified;
            _context.SaveChanges();
            UpdateCoin(cBld);
        }

        public void UpdateCoin(CityBuilding cBld)
        {
            CityRepository cr = new CityRepository();
            cBld.City = cr.CityCoinUpdate(cBld.City, false);
            _context.Cities.Attach(cBld.City);
            _context.Entry(cBld.City).State = EntityState.Modified; 
            _context.SaveChanges(); 
        }

        public void UpdateCoin_Create(int CityID)
        {

            CityRepository cr = new CityRepository();
            City c;

            c = (from cx in _context.Cities
                 select cx).Include(x => x.CityBuildings)
                    .Where(x => x.CityId == CityID).FirstOrDefault();
            c = cr.CityCoinUpdate(c, false);
            _context.Entry(c).State = EntityState.Modified;
            _context.SaveChanges(); 
        }



        private CityBuilding GetCityBuildingByCBId(int CityId, int BldgId)
        {
            CityBuilding cb = new CityBuilding();
            cb = (from cb1 in _context.CityBuildings
                  select cb1)
                    .Where(x => x.CityId == CityId).Where(b => b.BuildingId == BldgId).FirstOrDefault();

            return cb;

        }
    }
    public class Building
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public Nullable<int> Levels { get; set; }
        public int GoldCoins { get; set; }
        public bool IsDefault { get; set; }
    }
}