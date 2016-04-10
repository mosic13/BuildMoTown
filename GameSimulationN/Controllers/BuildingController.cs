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
        private IBuildingRepository _repo;
        public BuildingController(IBuildingRepository repo)
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
        public ActionResult Create(BuildingType buildingType)
        {
            _repo.Create(buildingType, Convert.ToInt16(TempData.Peek("CityId")));

            return RedirectToAction("List", new { id = Convert.ToInt16(TempData.Peek("CityId")) });

        }
        
        [HttpPost]
        public ActionResult Edit(BuildingType buildingType)
        {
            _repo.Create(buildingType, Convert.ToInt16(TempData["CityId"]));

            return RedirectToAction("List", new { id = Convert.ToInt16(TempData["CityId"]) });

        }

        public ActionResult UpgradeLevel(int CityId, int BuildingId)
        {
            bool t = _repo.UpgradeLevel(CityId, BuildingId);
            if (t)
            {
                BuildingRepository br = new BuildingRepository();
                List<Building> b = new List<Building>();
                Building b1 = br.GetBuildingByCity(CityId).Where(x => x.BuildingId == BuildingId).Single();

                return Json(b1, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCoin(int CityId)
        {
           
            CityRepository cr = new CityRepository();
            City c = new City();c = cr.GetCityByID(CityId);

            return Content(c.GoldCoins.ToString(), "text/plain");


        }
    }
}