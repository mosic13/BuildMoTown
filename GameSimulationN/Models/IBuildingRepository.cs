using System.Collections.Generic;
namespace GameSimulationN.Models
{
    public interface IBuildingRepository
    {
        List<Building> GetBuildingByCity(int CityId);
        //void Create(string BuildingName, int CityId);
        void Create(BuildingType Building, int CityId);
        bool UpgradeLevel(int CityId, int BuildingId);

    }
}
