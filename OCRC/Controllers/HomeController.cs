using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCRC.Models;

namespace OCRC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        

        public ActionResult UserList()
        {
            ViewBag.Message = "UserList";

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

        //Yi Lao (Ming)-------------------------
        public ActionResult Result()
        {
            ViewBag.Message = "this is the result page";
            //DummyDate data = new DummyDate();
            return View();
        }
    }
}