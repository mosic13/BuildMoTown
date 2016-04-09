using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameSimulationN.Models
{
    public class BuildingRepository : IBuilding
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




            //select cb.*, c.cityid, c.cityname, c.goldcoins, bt.buildingname from CityBuilding cb
            //Inner join City c on c.CityId = cb.cityid
            //Inner join BuildingType bt on bt.buildingId = cb.BuildingId
            //where cb.cityid = 4



            return a.ToList();//
            //_context.CityBuildings.

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Create(BuildingType Building, int CityId)
        {
            var city  = _cityRepo.GetCityByID(CityId);
            //BuildingType bt = new BuildingType();
            //bt.BuildingName = Building.BuildingName;
            //bt.CreateDate = DateTime.Now;
            //bt.ModifyDate = DateTime.Now;
            //bt.IsDefault = false;
            Building.CreateDate = DateTime.Now;
            Building.ModifyDate = DateTime.Now;
            Building.IsDefault = false;
            ////city.CityBuildings.Add(Building);

            if (Building.BuildingId > 0)
            {
                _context.Entry(Building).State = EntityState.Modified;
            }
            else {
                _context.BuildingTypes.Add(Building);
            }
           // _context.SaveChanges();

            if (Building.BuildingId < 1)
            {
                int buildingTypeId = Building.BuildingId;

                CityBuilding cb = new CityBuilding();
                cb.BuildingId = buildingTypeId;
                cb.CityId = CityId;
                cb.Levels = 0;
                cb.CreateDate = DateTime.Now;
                cb.ModifyDate = DateTime.Now;
                _context.CityBuildings.Add(cb);
               // _context.SaveChanges();

                
                UpdateCoin_Create(CityId);

                //UpdateCoin(cb);
            }
            _context.SaveChanges();
        }

        public void UpgradeLevel(int CityId, int BuildingId)
        {
            //CityBuilding CB = new CityBuilding() { CityId = CityId, BuildingId = BuildingId };
            // Get Object to update the Level by CIty and Bldg Id
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
            _context.Entry(cBld.City).State = EntityState.Modified; //---Monali Today
            _context.SaveChanges(); //---Monali Today
        }

        public void UpdateCoin_Create(int CityID)
        {

            CityRepository cr = new CityRepository();
            City c = new City();
           
            c = cr.GetCityByID(CityID);
            c = cr.CityCoinUpdate(c, false);
            //_context.Cities.Attach(c);
            _context.Entry(c).State = EntityState.Modified; //---Monali Today
            //_context.SaveChanges(); //---Monali Today
        }



        private CityBuilding GetCityBuildingByCBId(int CityId, int BldgId)
        {
            CityBuilding cb = new CityBuilding();
            //_context.CityBuildings.(;


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