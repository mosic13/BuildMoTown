using GameSimulationN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSimulationN.Controllers
{
    public class BuildingTypeController : Controller
    {

        private IBuildingType _repo;
        public BuildingTypeController(IBuildingType repo)
        {
            _repo = repo;
        }

        // GET: BuildingType
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BuildingType BuildingType)
        {
            _repo.Create(BuildingType);

            return View();
        }
    }
}