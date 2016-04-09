using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameSimulationN.Models.ViewModel
{
    public class CityViewModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int GoldCoins { get; set; }
       
        public int Count { get; set; }
    }
}