using System.Collections.Generic;
namespace GameSimulationN.Models
{
    public interface IBuilding
    {
        List<Building> GetBuildingByCity(int CityId);
        void Create(BuildingType Building, int CityId);
        

    }
}
