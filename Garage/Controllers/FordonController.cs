using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage.DB;
using Garage.Models;
using PagedList;
using System.Collections;

namespace Garage.Controllers
{
    public class FordonController : Controller
    {
        private Databas db = new Databas();

        // GET: FordonModels
        public ActionResult Index(string searchString, string sortOrder, string currentFilter, int? page, string typeFilter)
        {




            // SIDOHANTERING
            ViewBag.CurrentSort = sortOrder;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;


            var bilar = from s in db.Fordon
                        select s;





            // SÖK
            if (!String.IsNullOrEmpty(searchString) || !String.IsNullOrEmpty(typeFilter))
            {
                if (typeFilter != "Alla" && !String.IsNullOrEmpty(searchString))
                {
                    bilar = bilar.Where(s =>
                        s.Regnr.Contains(searchString)
                        || s.Ägare.Contains(searchString)
                        && s.Fordontyp.ToString().Contains(typeFilter));
                }
                else if (String.IsNullOrEmpty(typeFilter) || typeFilter == "Alla")
                {
                    bilar = bilar.Where(s =>
                    s.Regnr.Contains(searchString)
                    || s.Ägare.Contains(searchString));
                }
                else
                    bilar = bilar.Where(s => s.Fordontyp.ToString().Contains(typeFilter));
            }





            // SORTERING
            ViewBag.FärgSortParm = String.IsNullOrEmpty(sortOrder) ? "färg_desc" : "";
            ViewBag.MärkeSortParm = String.IsNullOrEmpty(sortOrder) ? "märke_desc" : "";
            ViewBag.ModellSortParm = String.IsNullOrEmpty(sortOrder) ? "modell_desc" : "";
            ViewBag.ÄgareSortParm = String.IsNullOrEmpty(sortOrder) ? "ägare_desc" : "";
            ViewBag.TypSortParm = String.IsNullOrEmpty(sortOrder) ? "typ_desc" : "";
            ViewBag.RegnrSortParm = String.IsNullOrEmpty(sortOrder) ? "regnr_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Parkerad" ? "park_desc" : "Parkerad";


            // sorterar de klickbara tabellrubrikerna från störst till minst
            switch (sortOrder)
            {
                case "märke_desc":
                    bilar = bilar.OrderByDescending(s => s.Märke);
                    break;
                case "regnr_desc":
                    bilar = bilar.OrderByDescending(s => s.Regnr);
                    break;
                case "modell_desc":
                    bilar = bilar.OrderByDescending(s => s.Modell);
                    break;
                case "ägare_desc":
                    bilar = bilar.OrderByDescending(s => s.Ägare);
                    break;
                case "typ_desc":
                    bilar = bilar.OrderByDescending(s => s.Fordontyp);
                    break;
                case "färg_desc":
                    bilar = bilar.OrderByDescending(s => s.Färg);
                    break;
                case "Parkerad":
                    bilar = bilar.OrderBy(s => s.Parkerad);
                    break;
                case "park_desc":
                    bilar = bilar.OrderByDescending(s => s.Parkerad);
                    break;
                default:
                    bilar = bilar.OrderBy(s => s.Fordontyp).ThenBy(s => s.Parkerad);
                    break;
            
            }



            
            int pageSize = 5; 

            int pageNumber = (page ?? 1); 

            var model = new Garage.Models.FordonModelPagedList();

            model.list = bilar.ToPagedList(pageNumber, pageSize);


            return View(model);

        }



//________________________________________________________________





        // GET: FordonModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FordonModel fordonModel = db.Find(id);
            if (fordonModel == null)
            {
                return HttpNotFound();
            }
            return View(fordonModel);
        }


        // GET: FordonModels/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: FordonModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fordontyp,Färg,Regnr,Märke,Modell,Ägare,Parkerad")] FordonModel fordonModel)
        {
            if (ModelState.IsValid)
            {
                db.Add(fordonModel);
                return RedirectToAction("Index");
            }

            return View(fordonModel);
        }


        // GET: FordonModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FordonModel fordonModel = db.Find(id);
            if (fordonModel == null)
            {
                return HttpNotFound();
            }
            return View(fordonModel);
        }


        // POST: FordonModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fordontyp,Färg,Regnr,Märke,Modell,Ägare,Parkerad")] FordonModel fordonModel)
        {
            if (ModelState.IsValid)
            {
                db.Edit(fordonModel);
                return RedirectToAction("Index");
            }
            return View(fordonModel);
        }


        // GET: FordonModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FordonModel fordonModel = db.Find(id);
            if (fordonModel == null)
            {
                return HttpNotFound();
            }
            return View(fordonModel);
        }


        // POST: FordonModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
