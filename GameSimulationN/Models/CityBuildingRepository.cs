using System;

namespace GameSimulationN.Models
{
    public class CityBuildingRepository //: ICityBuildingRepository
    {
        CitySimulationGameEntities _context;

        public CityBuildingRepository()
        {
            _context = new CitySimulationGameEntities();
        }


        public void Create(CityBuilding cityBuilding )
        {
            _context.CityBuildings.Add(cityBuilding);
            _context.SaveChanges();

        }

        public void GetLevelValue(int CityId, int BuildingID)
        {
        

        }

        
    }
}