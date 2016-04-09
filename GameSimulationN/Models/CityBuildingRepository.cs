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

        //CityBuilding ICityBuildingRepository.Create()
        //{
        //    throw new NotImplementedException();
        //}


        public void Create(CityBuilding cityBuilding )
        {
            _context.CityBuildings.Add(cityBuilding);
            _context.SaveChanges();

        }

        public void GetLevelValue(int CityId, int BuildingID)
        {
           
            //var a = from bt in _context.CityBuildings
            //        where bt.CityId = CityId and 
            //        from b in context.Blogs
            //        where b.Name.StartsWith("B")
            //        select b;


        }

        
    }
}