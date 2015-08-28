using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//added more using in HomeController
using System.Data;
using Garage.DB;
using Garage.Models;
using System.Data.Entity;


namespace Garage.Controllers
{
    public class HomeController : Controller
    {
        //create new obj Databas
        private Databas db = new Databas();

        public ActionResult Index()
        {
            MainModel viewModel = new MainModel(); //initialize it

            viewModel.Nyhet = db.Nyheter.OrderByDescending(i => i.Skapad).Take(3).ToList();
            viewModel.Fordon = db.Fordon.Where(i => i.Parkerad.Day <= DateTime.Now.Day - 4).ToList();
            //return model obj to the index homepage
            //var model1 =
            //db.Fordon.Where(i =>i.Regnr.Contains("z")).OrderBy(i => i.Fordontyp).ThenBy(f => f.Parkerad).ToList();
            //db.Fordon.Where(i => i.Parkerad.Day <= DateTime.Now.Day - 4).ToList();
            //db.Nyheter.OrderByDescending(i => i.Skapad).Take(3).ToList();

            //var model2 = db.Fordon.Where(i => i.Parkerad.Day <= DateTime.Now.Day - 4).ToList();

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "About us.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us.";

            return View();
        }

        public ActionResult CreateNyhet()
        {
            ViewBag.Message = "Create Nyhet";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNyhet([Bind(Include = "Ämne,Innehåll")] NyhetModel model)
        {
            if (ModelState.IsValid)
            {
                db.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}