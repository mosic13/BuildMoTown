using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameSimulationN.Models
{
    public class BuildingTypeRepo //:IBuildingType
    {
        CitySimulationGameEntities _context;

        public BuildingTypeRepo()
        {
            _context = new CitySimulationGameEntities();
        }

        public List<BuildingType> GetBuildingType()
        {
            return _context.BuildingTypes.Where(x => x.IsDefault == true).ToList();
        }
        

        public void Insert(int CityId)
        {
            List<BuildingType> lstBldType = new List<BuildingType>();
            List<CityBuilding> lstCb = new List<CityBuilding>();
            CityBuilding cb;

            lstBldType = GetBuildingType();
            foreach (BuildingType btype in lstBldType)
            {
                cb = new CityBuilding();
                cb.CityId = CityId;
                cb.BuildingId = btype.BuildingId;
                cb.Levels = 1;
                cb.ModifyDate = DateTime.Now;
                cb.CreateDate = DateTime.Now;

                lstCb.Add(cb);

            }

            _context.CityBuildings.AddRange(lstCb);
            _context.SaveChanges();

        }

        public void Create(Building building)
        {
            BuildingType bt = new BuildingType();
            bt.BuildingName = building.BuildingName;
            bt.CreateDate = DateTime.Now;
            bt.ModifyDate = DateTime.Now;
            bt.IsDefault = false;

            _context.BuildingTypes.Add(bt);
            _context.SaveChanges();

            int buildingTypeId = bt.BuildingId;

            CityBuilding cb = new CityBuilding();
            cb.BuildingId = buildingTypeId;
            cb.CityId = building.CityId;
            cb.CreateDate = DateTime.Now;
            cb.ModifyDate = DateTime.Now;
            cb.Levels = 1;
            _context.CityBuildings.Add(cb);
            _context.SaveChanges();

        }
    }
}