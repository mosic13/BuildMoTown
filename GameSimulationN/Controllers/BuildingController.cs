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



        //[HttpPost]
        //[AsyncTimeout(10000)]
        //public ActionResult Create(BuildingType buildingType)
        //{
        //    //await Task.Run(() => Thread.Sleep(10000))
        //    //await Task.Delay(3000);

        //    _repo.Create(buildingType, Convert.ToInt16(TempData.Peek("CityId")));

        //    return RedirectToAction("List", new {id= Convert.ToInt16(TempData.Peek("CityId")) });

        //}
        //public async void CallMyProcess()
        //{
        //    await TimeconsumingProcess();
        //    Console.WriteLine("Time Consuming Process end");
        //}

        //public async void CallMe()
        //{
        //    CallMyProcess();
        //    Console.WriteLine("Program execution completed");
        //}

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
            //return Json("List", new { id = CityId });
            // return Json(,)


        }

        public ActionResult GetCoin(int CityId)
        {
           
            CityRepository cr = new CityRepository();
            City c = new City();c = cr.GetCityByID(CityId);

            return Content(c.GoldCoins.ToString(), "text/plain");


        }
    }
}