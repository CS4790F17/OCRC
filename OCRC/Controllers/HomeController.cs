using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCRC.Models;
using System.Web.Security;

namespace OCRC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Yi Lao (Ming)-------------------------
        public ActionResult Result()
        {
            
            var allSports = OCRC_API.getAllSports();


            return View(allSports);
        }
    }
}