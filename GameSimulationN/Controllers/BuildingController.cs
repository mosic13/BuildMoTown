using GameSimulationN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            BuildingRepository br = new BuildingRepository();
            List<Building> b = new List<Building>();
            b = br.GetBuildingByCity(id);


            return View("Index", b);
        } 
        public ActionResult Create(int id)
        {
            TempData["CityId"]= id;
           
            return View();

        }

        [HttpPost]
        public ActionResult Create(BuildingType buildingType )
        {   
            _repo.Create(buildingType, Convert.ToInt16(TempData.Peek("CityId")));

          

            return RedirectToAction("List", new {id= Convert.ToInt16(TempData.Peek("CityId")) });

        }

        [HttpPost]
        public ActionResult Edit(BuildingType buildingType)
        {
            _repo.Create(buildingType, Convert.ToInt16(TempData["CityId"]));

            return RedirectToAction("List", new { id = Convert.ToInt16(TempData["CityId"]) });

        }

        public ActionResult UpgradeLevel(int CityId , int BuildingId)
        {
            _repo.UpgradeLevel(CityId, BuildingId);

            return RedirectToAction("List", new { id = CityId });


        }
    }
}