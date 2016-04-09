using System.Collections.Generic;

namespace GameSimulationN.Models
{
    public interface IBuildingTypeRepository
    {
        void Create(Building building);
        List<BuildingType> GetBuildingType();
        void Insert(int CityId);
    }
}