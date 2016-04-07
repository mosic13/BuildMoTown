using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameSimulationN.Models
{
    public class BuildingRepo : IBuilding
    {
        CitySimulationGameEntities _context;

        public BuildingRepo()
        {
            _context = new CitySimulationGameEntities();
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
                cb.CreateDate = DateTime.Now;
                cb.ModifyDate = DateTime.Now;
                cb.Levels = 1;
                _context.CityBuildings.Add(cb);
                _context.SaveChanges();
            }
        }

        public void UpgradeLevel(int CityId, int BuildingId)
        {
            CityBuilding CB = new CityBuilding();

            int c = _context.CityBuildings.Select(x => x.Levels).FirstOrDefault().GetValueOrDefault();

            CB.Levels = c++;

            _context.CityBuildings.Add();
            _context.SaveChanges();

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