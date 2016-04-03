using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulationN.Models
{
    public interface ICityRepository
    {
        City Create(City city);
        int Save();
        List<CityBuildingNew> GetCities();
        void Create(BuildingType building);
    }
}
