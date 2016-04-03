using System.Collections.Generic;
namespace GameSimulationN.Models
{
    public interface IBuilding
    {
        List<Building> GetBuildingByCity(int CityId);
        Building Create(Building Building);
        

    }
}
