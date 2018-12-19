using OdeToFood.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class CuisineController : Controller
    {
        // GET: Cuisine
        //[HttpGet]  -- Action selectors
        //public ActionResult Search(string name="french")
        //{
        //    var message = Server.HtmlEncode(name);

            // Different Action Results
        //    //return RedirectToAction("Index", "Home", new { name = name });
        //    //return RedirectToRoute("default", new { controller = "Home", action = "About" });
        //    //return File("~/Content/S ite.css", "text/css");
        //    //return Json(new { Message = message, Name = name }, JsonRequestBehavior.AllowGet);

        //    return Content(message);
        //}


        //[Authorize(Roles ="Admin")]
        //[Authorize]
        [Log]
        public ActionResult Search(string name="french")
        {
            var message = Server.HtmlEncode(name);
            return Content(message);
        }
    }
}