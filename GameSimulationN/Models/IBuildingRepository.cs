using System.Collections.Generic;
namespace GameSimulationN.Models
{
    public interface IBuildingRepository
    {
        List<Building> GetBuildingByCity(int CityId);
        void Create(BuildingType Building, int CityId);
        void UpgradeLevel(int CityId, int BuildingId);

    }
}
