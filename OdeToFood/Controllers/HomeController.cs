using OdeToFood.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();
        [System.ComponentModel.Browsable(false)]
        public bool MaintainScrollPositionOnPostBack { get; set; }

        public ActionResult Index(string searchTerm=null, int page=1)
        {
            //var model = from r in _db.Restaurents
            //            orderby r.Reviews.Average(review => review.Rating) descending
            //            select new RestaurentListViewModel
            //            {
            //                Id = r.Id,
            //                Name = r.Name,
            //                City = r.City,
            //                Country = r.Country,
            //                CountOfReviews = r.Reviews.Count()
            //            };

            var model =
                _db.Restaurents
                .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))  
                .Select(r => new RestaurentListViewModel
                        {
                            Id = r.Id,
                            Name = r.Name,
                            City = r.City,
                            Country = r.Country,
                            CountOfReviews = r.Reviews.Count()
                        }).ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurents", model);
            }

            return View(model);
        }

        public ActionResult Autocomplete(string term)
        {
            var model =
                _db.Restaurents
                .Where(r => r.Name.StartsWith(term))
                .Take(10)
                .Select(r => new
                {
                    label = r.Name
                });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            AboutModel model = new AboutModel();

            //var controller = RouteData.Values["controller"];
            //var action = RouteData.Values["action"];
            //var id = RouteData.Values["id"];

            //ViewBag.Message = String.Format("{0}::{1} {2}", controller, action, id);
            model.Name = "Sai";
            model.Location = "Columbia Missouri";
            
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}