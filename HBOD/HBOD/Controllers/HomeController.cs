using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HBOD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "How the HBOD works.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Customer()
        {
            ViewBag.Message = "This will be the Customer page!";
                return View();
        }

        public ActionResult Hairstylist()
        {
            ViewBag.Message = "This will be the Hairstylist page!";
            return View();
        }

        public ActionResult Barber()
        {
            ViewBag.Message = "This will be the Barbers page!";
                return View();
        }
    }
}