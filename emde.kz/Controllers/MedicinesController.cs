using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using emde.kz.DAL;
using emde.kz.Models;

namespace emde.kz.Controllers
{
    public class MedicinesController : Controller
    {
        private MedicinesContext db = new MedicinesContext();

        // GET: Medicines
        public ActionResult Index(string sortOrder, string searchMedicine, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            if (searchMedicine != null)
            {
                page = 1;
            }
            else
            {
                searchMedicine = currentFilter;
            }

            ViewBag.CurrentFilter = searchMedicine;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var medicines = from s in db.Medicines
                            select s;

            if (!String.IsNullOrEmpty(searchMedicine))
            {
                medicines = medicines.Where(s => s.Name.Contains(searchMedicine)
                                                || s.InternationalName.Contains(searchMedicine));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    medicines = medicines.OrderByDescending(s => s.Name);
                    break;
                default:
                    medicines = medicines.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(medicines.ToPagedList(pageNumber, pageSize));
        }

        // GET: Medicines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }

            return View(medicine);
        }

        // GET: Medicines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Type,Country,Company,InternationalName,Component,PharmaAction,Contrindiction,Effect,MethodsOfUse,StorageCondition,Image,Dosage,Recipe")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.Medicines.Add(medicine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicine);
        }

        // GET: Medicines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Type,Country,Company,InternationalName,Component,PharmaAction,Contrindiction,Effect,MethodsOfUse,StorageCondition,Image,Dosage,Recipe")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicine);
        }

        // GET: Medicines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicine medicine = db.Medicines.Find(id);
            db.Medicines.Remove(medicine);
            db.SaveChanges();
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
