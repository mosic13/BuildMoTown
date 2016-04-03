using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulationN.Models
{
   public interface IBuildingType
    {
        BuildingType Create(BuildingType buildingType);
    }
}
