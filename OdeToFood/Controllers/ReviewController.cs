using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Index([Bind(Prefix ="id")]int restaurentId)
        {
            var restaurent = _db.Restaurents.Find(restaurentId);
            if (restaurent != null)
            {
                return View(restaurent);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int restaurentId)
        {
            return View();

        }

        [HttpPost]
        public ActionResult Edit([Bind(Exclude ="ReviewerName")] RestaurentReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurentId });
            }
            return View(review);
        }

        public ActionResult Create(RestaurentReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurentId });
            }
            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Reviews.Find(id);

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
