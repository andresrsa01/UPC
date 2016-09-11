using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Innova.GMantenimiento.Domain;
using Innova.Common.Core.Entities;
using System.Web.Mvc;

namespace Innova.GMantenimiento.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



    }
}