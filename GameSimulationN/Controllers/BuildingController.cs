using GameSimulationN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSimulationN.Controllers
{
    public class BuildingController : Controller
    {
        private IBuilding _repo;
        public BuildingController(IBuilding repo)
        {
            _repo = repo;
        }

        // GET: Building
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int id)
        {
            BuildingRepo br = new BuildingRepo();
            List<Building> b = new List<Building>();
            b = br.GetBuildingByCity(id);


            return View("Index", b);
        }
        public ActionResult Create()
        {
            int i = Convert.ToInt16( ViewBag.CityId);

            return View();

        }
        [HttpPost]
        public ActionResult Create(BuildingType buildingType)
        {
            _repo.Create(buildingType, Convert.ToInt16(ViewBag.CityId));

            return RedirectToAction("Index", ViewBag.CityId);

        }
    }
}