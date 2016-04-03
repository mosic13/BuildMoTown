using GameSimulationN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSimulationN.Controllers
{
    public class CityController : Controller
    {
        private ICityRepository _repo;
        public CityController(ICityRepository repo)
        {
            _repo = repo;
        }
        //public CityController()
        //{
        //}
        public ActionResult Index()
        {
           

            return View(_repo.GetCities());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(City city)
        {
            _repo.Create(city);
            _repo.Save();

            return RedirectToAction("Index");

        }
        public ActionResult BuildingList(int CityId)
        {
            return RedirectToAction("List", "Building", new { id = CityId });
        }


    }
}