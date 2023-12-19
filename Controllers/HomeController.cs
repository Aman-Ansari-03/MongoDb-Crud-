using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoCrud.Models;
using MongoCrud.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoCrud.Controllers
{
    public class HomeController : Controller
    {

        private readonly StudentRepo _repo;
        public HomeController(StudentRepo studentRepo)
        {
            _repo = studentRepo;
        }

        public IActionResult Index()
        {
            var allCar = _repo.Show();
            return View(allCar);
        }

        public IActionResult Create()
        {
            return View();
        }        
        
        [HttpPost]
        public IActionResult Create(CarModel carModel)
        {
            _repo.insert(carModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            if (ModelState.IsValid)
            {
               var collection =  _repo.search(id);
                return View(collection);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(CarModel carModel)
        {
            _repo.update(carModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string Id)
        {
            _repo.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
