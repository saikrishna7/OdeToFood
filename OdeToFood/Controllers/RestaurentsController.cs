using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class RestaurentsController : Controller
    {
        private OdeToFoodDb db = new OdeToFoodDb();

        // GET: Restaurents
        public ActionResult Index()
        {
            return View(db.Restaurents.ToList());
        }

        
        [Authorize(Roles ="admin")]
        // GET: Restaurents/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Restaurents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,City,Country")] Restaurent restaurent)
        {
            if (ModelState.IsValid)
            {
                db.Restaurents.Add(restaurent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurent);
        }

        // GET: Restaurents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurent restaurent = db.Restaurents.Find(id);
            if (restaurent == null)
            {
                return HttpNotFound();
            }
            return View(restaurent);
        }

        // POST: Restaurents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,City,Country")] Restaurent restaurent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurent);
        }

        // GET: Restaurents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurent restaurent = db.Restaurents.Find(id);
            if (restaurent == null)
            {
                return HttpNotFound();
            }
            return View(restaurent);
        }

        // POST: Restaurents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurent restaurent = db.Restaurents.Find(id);
            db.Restaurents.Remove(restaurent);
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
