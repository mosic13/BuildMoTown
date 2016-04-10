using GameSimulationN.Models.ViewModel;
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
        List<CityViewModel> GetCities();
        void Create(BuildingType building);
        City CityCoinUpdate(City objCIty, bool toBeAdded);
        int GetCoin(int CityId);
    }
}
