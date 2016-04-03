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
           
            return View();

        }
        [HttpPost]
        public ActionResult Create(Building building)
        {

            _repo.Create(building);


            return RedirectToAction("Index");

        }
    }
}